using Microsoft.ML.Data;
using Skender.Stock.Indicators;

namespace DerivSmartRobot.Models
{
    public class CandleDud : Quote
    {
        [LoadColumn(0)]
        public DateTime Date { get; set; }
        [LoadColumn(1)]
        public decimal Open { get; set; }
        [LoadColumn(2)]
        public decimal High { get; set; }
        [LoadColumn(3)]
        public decimal Low { get; set; }
        [LoadColumn(4)]
        public decimal Close { get; set; }
        [NoColumn]
        public decimal Volume { get; set; }

        // raw sizes
        [NoColumn]
        public decimal Size => High - Low;
        [NoColumn]
        public decimal Body => (Open > Close) ? (Open - Close) : (Close - Open);
        [NoColumn]
        public decimal UpperWick => High - (Open > Close ? Open : Close);
        [NoColumn]
        public decimal LowerWick => (Open > Close ? Close : Open) - Low;

        // percent sizes
        [NoColumn]
        public double BodyPct => (Size != 0) ? (double)(Body / Size) : 1;
        [NoColumn]
        public double UpperWickPct => (Size != 0) ? (double)(UpperWick / Size) : 1;
        [NoColumn]
        public double LowerWickPct => (Size != 0) ? (double)(LowerWick / Size) : 1;


        [NoColumn]
        public bool IsBullish => Close > Open;
        [NoColumn]
        public bool IsBearish => Close < Open;
    }
}