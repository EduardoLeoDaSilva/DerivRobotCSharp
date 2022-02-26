using DerivSmartRobot.Domain.Enums;
using Newtonsoft.Json;

namespace DerivSmartRobot.Models.DerivClasses;

public class History
{
    public List<double> Prices { get; set; }
    public List<long> Times { get; set; }
}
