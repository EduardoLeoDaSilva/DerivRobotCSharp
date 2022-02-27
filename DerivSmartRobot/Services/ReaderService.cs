using DerivSmartRobot.Domain.Enums;
using DerivSmartRobot.Models.Classes;
using DerivSmartRobot.Models.DerivClasses;
using DerivSmartRobot.Redis;
using DerivSmartRobot.Robots;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using ErrorEventArgs = WebSocketSharp.ErrorEventArgs;
using MessageEventArgs = WebSocketSharp.MessageEventArgs;

namespace DerivSmartRobot.Services;

public class ReaderService
{
    private static ITradeService _tradeService;
    private static IRsiRobot _rsiRobot;
    private readonly IRsiFractalRobot _rsiFractalRobotRobot;
    private readonly ISmaAndWmaGoRobot _smaAndWmaGoRobot;
    private readonly IRsiMacdRobot _rsiMacdRobot;
    private readonly IMacdRobot _macdRobot;
    private readonly IMarubuzuRobot _marubuzuRobot;
    private readonly IDigitRobotRobot _digitRobot;
    private readonly IRsiStockHigherAndLowerRobot _rsiStockHigherAndLowerRobotRoboto;




    public ReaderService(ITradeService tradeService, IRsiRobot rsiRobot,
        IRsiFractalRobot rsiFractalRobotRobot, ISmaAndWmaGoRobot smaAndWmaGoRobot, IRsiMacdRobot rsiMacdRobot, IMacdRobot macdRobot, IMarubuzuRobot marubuzuRobot, IDigitRobotRobot digitRobot, IRsiStockHigherAndLowerRobot rsiStockHigherAndLowerRobotRoboto)
    {
        _tradeService = tradeService;
        _rsiRobot = rsiRobot;
        _rsiFractalRobotRobot = rsiFractalRobotRobot;
        _smaAndWmaGoRobot = smaAndWmaGoRobot;
        _rsiMacdRobot = rsiMacdRobot;
        _macdRobot = macdRobot;
        _marubuzuRobot = marubuzuRobot;
        _digitRobot = digitRobot;
        _rsiStockHigherAndLowerRobotRoboto = rsiStockHigherAndLowerRobotRoboto;
    }

    public void ReadValueFromDeriv(object? sender, MessageEventArgs e)
    {
        var webSocketReturn = JsonConvert.DeserializeObject<ResponseMessage>(e.Data);

        if (webSocketReturn.Error != null)
        {
            Console.WriteLine($"{webSocketReturn.Error.Message}");
            return;
        }

        switch (webSocketReturn?.MsgType)
        {
            case MsgType.Tick:
                SendToRobot(webSocketReturn, CommandsApi.TickStream);
                break;
            case MsgType.Transaction:
                SendToRobot(webSocketReturn, CommandsApi.TransactionStream);
                break;
            case MsgType.Buy:
                SendToRobot(webSocketReturn, CommandsApi.Buy);
                break;
            case MsgType.Proposal:
                SendToRobot(webSocketReturn, CommandsApi.Proposal);
                break;
            case MsgType.Ohlc:
                SendToRobot(webSocketReturn, CommandsApi.OlhcStream);
                break;
            case MsgType.Candles:
                SendToRobot(webSocketReturn, CommandsApi.Candles);
                break;
        }
    }

    public void SendToRobot(ResponseMessage responseMessage, CommandsApi commandsApi)
    {
        switch (_tradeService.RobotConfigutarion.RobotType)
        {
            case RobotType.RSI:
                switch (commandsApi)
                {
                    case CommandsApi.OlhcStream:
                        _rsiRobot.VerifyAndBuy(responseMessage);
                        break;
                    case CommandsApi.TransactionStream:
                        var transaction = _rsiRobot.GetTransactionFromCurrentOperationMarket(
                            _tradeService.RobotConfigutarion.Market,
                            responseMessage);
                        if (transaction != null)
                        {
                            if (transaction.Action == ContractAction.Sell)
                            {
                                _tradeService.IsOperating = false;
                                Console.WriteLine($"Lucro/Perda de: {transaction.Amount}");
                            }
                            _rsiRobot.UpdateOperationInfo(responseMessage, _tradeService);

                        }
                        _rsiRobot.GetAmountWithMartingale(_tradeService.currentOperation,
                            _tradeService.RobotConfigutarion.MartingaleValue,
                            _tradeService.RobotConfigutarion.MartigaleType);

                        break;
                    case CommandsApi.Buy:
                        Console.WriteLine($"Realizando aporte de {responseMessage.Buy.buy_price}");
                        break;
                    case CommandsApi.Proposal:
                        _tradeService.BuyAContract(responseMessage.Proposal);
                        break;
                    case CommandsApi.Candles:
                        _rsiRobot.FillQuotesWithHistoricalData(responseMessage);
                        break;
                }

                break;
            case RobotType.Digit:
                switch (commandsApi)
                {
                    case CommandsApi.OlhcStream:
                        _digitRobot.VerifyAndBuy(responseMessage);
                        break;
                    case CommandsApi.TransactionStream:
                        var transaction = _digitRobot.GetTransactionFromCurrentOperationMarket(
                            _tradeService.RobotConfigutarion.Market,
                            responseMessage);
                        if (transaction != null)
                        {
                            if (transaction.Action == ContractAction.Sell)
                            {
                                _tradeService.IsOperating = false;
                                Console.WriteLine($"Lucro/Perda de: {transaction.Amount}");
                            }
                            _digitRobot.UpdateOperationInfo(responseMessage, _tradeService);

                        }
                        _digitRobot.GetAmountWithMartingale(_tradeService.currentOperation,
                            _tradeService.RobotConfigutarion.MartingaleValue,
                            _tradeService.RobotConfigutarion.MartigaleType);

                        break;
                    case CommandsApi.Buy:
                        Console.WriteLine($"Realizando aporte de {responseMessage.Buy.buy_price}");
                        break;
                    case CommandsApi.Proposal:
                        _tradeService.BuyAContract(responseMessage.Proposal);
                        break;
                    case CommandsApi.Candles:
                        _digitRobot.FillQuotesWithHistoricalData(responseMessage);
                        break;
                }

                break;
            case RobotType.MACD:
                switch (commandsApi)
                {
                    case CommandsApi.OlhcStream:
                        _macdRobot.VerifyAndBuy(responseMessage);
                        break;
                    case CommandsApi.TransactionStream:
                        var transaction = _macdRobot.GetTransactionFromCurrentOperationMarket(
                            _tradeService.RobotConfigutarion.Market,
                            responseMessage);
                        if (transaction != null)
                        {
                            if (transaction.Action == ContractAction.Sell)
                            {
                                _tradeService.IsOperating = false;
                            }
                            Console.WriteLine($"Lucro/Perda de: {transaction.Amount}");
                            _macdRobot.UpdateOperationInfo(responseMessage, _tradeService);
                        }
                        _macdRobot.GetAmountWithMartingale(_tradeService.currentOperation,
                            _tradeService.RobotConfigutarion.MartingaleValue,
                            _tradeService.RobotConfigutarion.MartigaleType);

                        break;
                    case CommandsApi.Buy:
                        Console.WriteLine($"Realizando aporte de {responseMessage.Buy.buy_price}");
                        break;
                    case CommandsApi.Proposal:
                        _tradeService.BuyAContract(responseMessage.Proposal);
                        break;
                    case CommandsApi.Candles:
                        _macdRobot.FillQuotesWithHistoricalData(responseMessage);
                        break;
                }
                break;
            case RobotType.RSIMACD:
                switch (commandsApi)
                {
                    case CommandsApi.OlhcStream:
                        _rsiMacdRobot.VerifyAndBuy(responseMessage);
                        break;
                    case CommandsApi.TransactionStream:
                        var transaction = _rsiMacdRobot.GetTransactionFromCurrentOperationMarket(
                            _tradeService.RobotConfigutarion.Market,
                            responseMessage);
                        if (transaction != null)
                        {
                            if (transaction.Action == ContractAction.Sell)
                            {
                                _tradeService.IsOperating = false;
                            }
                            Console.WriteLine($"Lucro/Perda de: {transaction.Amount}");
                            _rsiMacdRobot.UpdateOperationInfo(responseMessage, _tradeService);
                        }
                        _rsiMacdRobot.GetAmountWithMartingale(_tradeService.currentOperation,
                            _tradeService.RobotConfigutarion.MartingaleValue,
                            _tradeService.RobotConfigutarion.MartigaleType);

                        break;
                    case CommandsApi.Buy:
                        Console.WriteLine($"Realizando aporte de {responseMessage.Buy.buy_price}");
                        break;
                    case CommandsApi.Proposal:
                        _tradeService.BuyAContract(responseMessage.Proposal);
                        break;
                    case CommandsApi.Candles:
                        _rsiMacdRobot.FillQuotesWithHistoricalData(responseMessage);
                        break;
                }
                break;
            case RobotType.RsiFractal:
                switch (commandsApi)
                {
                    case CommandsApi.OlhcStream:
                        _rsiFractalRobotRobot.VerifyAndBuy(responseMessage);
                        break;
                    case CommandsApi.TransactionStream:
                        var transaction = _rsiFractalRobotRobot.GetTransactionFromCurrentOperationMarket(
                            _tradeService.RobotConfigutarion.Market,
                            responseMessage);
                        if (transaction != null)
                        {
                            if (transaction.Action == ContractAction.Sell)
                            {
                                _tradeService.IsOperating = false;
                            }
                            Console.WriteLine($"Lucro/Perda de: {transaction.Amount}");
                            _rsiFractalRobotRobot.UpdateOperationInfo(responseMessage, _tradeService);
                        }
                        _rsiFractalRobotRobot.GetAmountWithMartingale(_tradeService.currentOperation,
                            _tradeService.RobotConfigutarion.MartingaleValue,
                            _tradeService.RobotConfigutarion.MartigaleType);

                        break;
                    case CommandsApi.Buy:
                        Console.WriteLine($"Realizando aporte de {responseMessage.Buy.buy_price}");
                        break;
                    case CommandsApi.Proposal:
                        _tradeService.BuyAContract(responseMessage.Proposal);
                        break;
                    case CommandsApi.Candles:
                        _rsiFractalRobotRobot.FillQuotesWithHistoricalData(responseMessage);
                        break;
                }
                break;
            case RobotType.Marubuzu:
                switch (commandsApi)
                {
                    case CommandsApi.OlhcStream:
                        _marubuzuRobot.VerifyAndBuy(responseMessage);
                        break;
                    case CommandsApi.TransactionStream:
                        var transaction = _marubuzuRobot.GetTransactionFromCurrentOperationMarket(
                            _tradeService.RobotConfigutarion.Market,
                            responseMessage);
                        if (transaction != null)
                        {
                            if (transaction.Action == ContractAction.Sell)
                            {
                                _tradeService.IsOperating = false;
                            }
                            Console.WriteLine($"Lucro/Perda de: {transaction.Amount}");
                            _marubuzuRobot.UpdateOperationInfo(responseMessage, _tradeService);
                        }
                        _marubuzuRobot.GetAmountWithMartingale(_tradeService.currentOperation,
                            _tradeService.RobotConfigutarion.MartingaleValue,
                            _tradeService.RobotConfigutarion.MartigaleType);

                        break;
                    case CommandsApi.Buy:
                        Console.WriteLine($"Realizando aporte de {responseMessage.Buy.buy_price}");
                        break;
                    case CommandsApi.Proposal:
                        _tradeService.BuyAContract(responseMessage.Proposal);
                        break;
                    case CommandsApi.Candles:
                        _marubuzuRobot.FillQuotesWithHistoricalData(responseMessage);
                        break;
                }
                break;
            case RobotType.RsiStockHigherAndLower:
                switch (commandsApi)
                {
                    case CommandsApi.OlhcStream:
                        _rsiStockHigherAndLowerRobotRoboto.VerifyAndBuy(responseMessage);
                        break;
                    case CommandsApi.TransactionStream:
                        var transaction = _rsiStockHigherAndLowerRobotRoboto.GetTransactionFromCurrentOperationMarket(
                            _tradeService.RobotConfigutarion.Market,
                            responseMessage);
                        if (transaction != null)
                        {
                            if (transaction.Action == ContractAction.Sell)
                            {
                                _tradeService.IsOperating = false;
                            }
                            Console.WriteLine($"Lucro/Perda de: {transaction.Amount}");
                            _rsiStockHigherAndLowerRobotRoboto.UpdateOperationInfo(responseMessage, _tradeService);
                        }
                        _rsiStockHigherAndLowerRobotRoboto.GetAmountWithMartingale(_tradeService.currentOperation,
                            _tradeService.RobotConfigutarion.MartingaleValue,
                            _tradeService.RobotConfigutarion.MartigaleType);

                        break;
                    case CommandsApi.Buy:
                        Console.WriteLine($"Realizando aporte de {responseMessage.Buy.buy_price}");
                        break;
                    case CommandsApi.Proposal:
                        _tradeService.BuyAContract(responseMessage.Proposal);
                        break;
                    case CommandsApi.Candles:
                        _rsiStockHigherAndLowerRobotRoboto.FillQuotesWithHistoricalData(responseMessage);
                        break;
                }
                break;
        }
    }

    public static void ReadValueErrorEvent(object? sender, ErrorEventArgs e)
    {
        Console.WriteLine("Erro retornado do websocket");
    }
}

