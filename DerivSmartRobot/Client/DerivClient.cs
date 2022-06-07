using System.Security.Authentication;
using System.Text.Json;
using DerivSmartRobot.Domain.Enums;
using DerivSmartRobot.Models.DerivClasses;
using Newtonsoft.Json;
using WebSocketSharp;
using ErrorEventArgs = WebSocketSharp.ErrorEventArgs;

namespace DerivSmartRobot.Services
{

    public interface IClientDeriv
    {
        void GetMarketQuote(string market);

        void GetTransactionStream();
        void Connect();
        void GetAvailableMarkets();
        void SubscribeErroEvents();
        void SubscribeSucessEvents();
        void SetConfigurations(string appId, string token);
        void Authorize();

        void UnsubscribeErrosEvents();
        void UnsubscribeSucessEvents();

        void SendCommand(string command);
        void GetCandlesStream(string market, int granularity, bool subscribe = false);
        void GetBalanceStream();
        void Forget(string id);

        void Stop();
        void SubscribeOpenContract(ResponseMessage responseMessage);
        void Sell(long openContractContractId, double openContractBuyPrice);
    }

    public class DerivClient : IClientDeriv
    {
        const int app_id = 1089;
        private string _token { get; set; }

        private WebSocket _ws = null!;

        private readonly IServiceProvider _serviceProvider;

        public DerivClient(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void SubscribeErroEvents()
        {
            _ws.OnError += ReaderService.ReadValueErrorEvent;
        }

        public void SubscribeSucessEvents()
        {
            var reader = _serviceProvider.GetService<ReaderService>();
            _ws.OnMessage += reader.ReadValueFromDeriv;

        }

        public void UnsubscribeErrosEvents()
        {
            _ws.OnError -= ReaderService.ReadValueErrorEvent;

        }

        public void UnsubscribeSucessEvents()
        {
            var reader = _serviceProvider.GetService<ReaderService>();

            _ws.OnMessage -= reader.ReadValueFromDeriv;

        }

        public void SetConfigurations(string appId, string token)
        {
            _ws = new WebSocket($"wss://ws.binaryws.com/websockets/v3?app_id={appId}");
            _token = token;
            _ws.SslConfiguration.EnabledSslProtocols = SslProtocols.None;
        }

        public void Connect()
        {
            _ws.Connect();
        }

        public void Stop()
        {
            _ws.Close();
        }

        public void SubscribeOpenContract(ResponseMessage responseMessage)
        {
            if (responseMessage.Error != null)
            {
                var contractId =responseMessage.EchoReq.contract_id;
                var command = CommandsService.GetCommands(CommandsApi.OpenContract, contractId);
                _ws.Send(command);
            }
            else
            {
                var command = CommandsService.GetCommands(CommandsApi.OpenContract, responseMessage.Buy.contract_id);
                _ws.Send(command);
            }
            

        }

        public void Sell(long openContractContractId, double openContractBuyPrice)
        {
            var command = CommandsService.GetCommands(CommandsApi.Sell, new {sell = openContractContractId, price = openContractBuyPrice});
            _ws.Send(command);
        }

        public void Authorize()
        {
            var command = CommandsService.GetCommands(CommandsApi.Authorize, _token);
            _ws.Send(command);
        }

        public void GetAvailableMarkets()
        {
            var command = CommandsService.GetCommands(CommandsApi.AvailableMarkets, null);
            _ws.Send(command);
        }

        public void GetMarketQuote(string market)
        {
            var command = CommandsService.GetCommands(CommandsApi.TickStream, market);
            _ws.Send(command);
        }

        public void GetTransactionStream()
        {
            var command = CommandsService.GetCommands(CommandsApi.TransactionStream, null);
            _ws.Send(command);
        }

        public void GetCandlesStream(string market, int granularity, bool subscribe = false)
        {
            var command =
                CommandsService.GetCommands(CommandsApi.OlhcStream, new {Market = market, Granularity = granularity}, subscribe);
            Console.WriteLine(command);
            _ws.Send(command);
        }

        public void GetBalanceStream()
        {
            var command =
                CommandsService.GetCommands(CommandsApi.Balance, new { balance = 1, subscribe = 1 });
            Console.WriteLine(command);
            _ws.Send(command);
        }

        public void Forget(string id)
        {
            var command = new {forget = id};
            _ws.Send(JsonConvert.SerializeObject(command));
        }

        public void SendCommand(string command)
        {
            Console.WriteLine(command);
            _ws.Send(command);
        }
    }
}




