using DerivSmartRobot.Domain.Enums;
using DerivSmartRobot.Models.DerivClasses;
using Newtonsoft.Json;

namespace DerivSmartRobot.Services
{
    public class CommandsService
    {
        public static string GetCommands(CommandsApi command, dynamic data, bool subscribe = false)
        {
            switch (command)
            {
                case CommandsApi.Authorize:
                {
                    var obj = new
                    {
                        authorize = data
                    };
                    return JsonConvert.SerializeObject(obj);
                }
                case CommandsApi.TransactionStream:
                {
                    var obj = new
                    {
                        transaction = 1,
                        subscribe = 1
                    };
                    var tt = JsonConvert.SerializeObject(obj);
                    return tt;
                }
                case CommandsApi.TickStream:
                {
                    var obj = new
                    {
                        ticks = data,
                        subscribe = 1
                    };
                    var tt = JsonConvert.SerializeObject(obj);
                    return tt;
                }
                case CommandsApi.AvailableMarkets:
                {
                    var obj = new
                    {
                        active_symbols = "brief",
                        product_type = "basic"
                    };
                    var tt = JsonConvert.SerializeObject(obj);
                    return tt;
                }
                case CommandsApi.Buy:
                {
                    var obj = new
                    {
                        buy = data.Id,
                        price = data.AskPrice
                    };
                    var tt = JsonConvert.SerializeObject(obj);
                    return tt;
                }
            
                case CommandsApi.Proposal:
                {
                    var tt = JsonConvert.SerializeObject(data, new JsonSerializerSettings
                    {
                        DefaultValueHandling = DefaultValueHandling.Ignore,
                        NullValueHandling = NullValueHandling.Ignore
                    });
                    return tt;
                }

                case CommandsApi.Balance:
                {
                    var tt = JsonConvert.SerializeObject(data, new JsonSerializerSettings
                    {
                        DefaultValueHandling = DefaultValueHandling.Ignore,
                        NullValueHandling = NullValueHandling.Ignore
                    });
                    return tt;
                }
                    
                case CommandsApi.Sell:
                {
                    var obj = new
                    {
                        sell = data.sell,
                        price = data.price
                    };
                    var tt = JsonConvert.SerializeObject(obj, new JsonSerializerSettings
                    {
                        DefaultValueHandling = DefaultValueHandling.Ignore,
                        NullValueHandling = NullValueHandling.Ignore
                    });
                    return tt;
                }

                

                case CommandsApi.OpenContract:
                {
                        var obj = new
                        {
                            proposal_open_contract = 1,
                            contract_id = data,
                            subscribe = 1
                        };

                        var tt = JsonConvert.SerializeObject(obj, new JsonSerializerSettings
                    {
                        DefaultValueHandling = DefaultValueHandling.Ignore,
                        NullValueHandling = NullValueHandling.Ignore
                    });
                    return tt;
                }


                case CommandsApi.OlhcStream:
                {

                    var request = new
                    {
                        ticks_history = data.Market,
                        adjust_start_time = 1,
                        count = 40000,
                        end = "latest",
                        start = 1,
                        style = "candles",
                        granularity = data.Granularity,
                        subscribe = subscribe ? 1 : 0
                    };
                    var tt = JsonConvert.SerializeObject(request, new JsonSerializerSettings
                    {
                        DefaultValueHandling = DefaultValueHandling.Ignore,
                        NullValueHandling = NullValueHandling.Ignore
                    });
                    return tt;
                }
                default:
                    return "";
            }
        }
    
        public static Contract BuildContractModel(int? Proposal, decimal? Amount, string? Barrier, string? Basis,
            string? Contract_type, string? Currency, int? Duration, string? Duration_unit, string? Symbol)
        {
            var request = new Contract
            {
                Proposal= 1,
                Amount= Amount,
                Basis= Basis,
                Barrier = Barrier,
                Contract_type= Contract_type,
                Currency= "USD",
                Duration= Duration,
                Duration_unit= Duration_unit,
                Symbol= Symbol
            };
            return request;
        }
    
        public static string GetTransactionResponse()
        {
            return "true";
        }
    }
}