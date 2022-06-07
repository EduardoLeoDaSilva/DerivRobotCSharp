using DerivSmartRobot.Models.View;
using DerivSmartRobot.Services;

namespace DerivSmartRobot
{

    public class HostedService : IHostedService
    {
        private readonly IClientDeriv _client;
        private readonly ITradeService _tradeService;

        public HostedService(IClientDeriv client, ITradeService tradeService)
        {
            _client = client;
            _tradeService = tradeService;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _tradeService.Log = new LogView {Date = DateTime.Now, Log = "Iniciando robô"};
            _client.SetConfigurations("31306", _tradeService.currentOperation.AccessToken);
            _client.SubscribeSucessEvents();
            _client.SubscribeErroEvents();
            _client.Connect();
            _client.Authorize();

            // await Task.Delay(2000);
            // await _client.GetMarketQuote(_tradeService.RobotConfigutarion.Market);
            // _client.GetCandlesStream(_tradeService.RobotConfigutarion.Market, 60, true); //todo mudar dpois
            //_client.GetTransactionStream();
            // _client.GetBalanceStream();


        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Parando");
            _client.UnsubscribeSucessEvents();
            _client.UnsubscribeErrosEvents();
            return Task.CompletedTask;
        }
    }
}