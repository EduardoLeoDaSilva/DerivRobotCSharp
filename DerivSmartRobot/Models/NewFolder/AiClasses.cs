using Microsoft.ML.Data;

namespace DerivSmartRobot.Models.NewFolder
{
    public class LastDigitPredictionClass
    {
        [LoadColumn(0)]
        public DateTime Date { get; set; }
        [LoadColumn(1)]
        public Single LastDigit { get; set; }
    }

    public class LastDigitForecast
    {
        public Single[] Forecast { get; set; }
    }
}
