using Microsoft.ML.Data;

namespace DerivSmartRobot.Models
{
    public class PredicitionCandle
    {
        [ColumnName("Score")]
        public float Close { get; set; }

    }


    public class PredictionCandleDud
    {
        [NoColumn]
        public string Date { get; set; }
        [ColumnName("Open")] [LoadColumn(0)]
        public float Open { get; set; }
        [ColumnName("High")]
        [LoadColumn(1)]
        public float High { get; set; }
        [ColumnName("Low")]
        [LoadColumn(2)]
        public float Low { get; set; }
        [ColumnName("Close")]
        [LoadColumn(3)]
        public float Close { get; set; }
        [NoColumn]
        public float Volume { get; set; }
    }


    public class PredictionCandleDud2
    {
        [NoColumn]
        public string Date { get; set; }
        [LoadColumn(1)]
        public float Open { get; set; }
        [LoadColumn(2)]
        public float High { get; set; }
        [LoadColumn(3)]
        public float Low { get; set; }
        [LoadColumn(4)]
        public float Close { get; set; }
    }

    public class PriceForecast
    {
        public float[] Forecast { get; set; }
    }

}
