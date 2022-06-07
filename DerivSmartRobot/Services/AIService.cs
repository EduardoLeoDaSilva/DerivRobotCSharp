using DerivSmartRobot.Models;
using DerivSmartRobot.Models.NewFolder;
using Microsoft.ML;
using Microsoft.ML.Transforms.TimeSeries;
using Skender.Stock.Indicators;

namespace DerivSmartRobot.Services
{
    public class AIService
    {
        private MLContext mlContext;
        public ITransformer model;
        public int LengthList;

        public ITransformer Load(List<PredictionCandleDud> candleDuds)
        {

            mlContext = new MLContext(seed: 0);
            model = Train(mlContext, "", candleDuds);
            return model;


        }

        private ITransformer Train(MLContext mlContext1, string empty, List<PredictionCandleDud> candleDuds)
        {

            IDataView dataView = mlContext.Data.LoadFromEnumerable<PredictionCandleDud>(candleDuds);
            //var pipeline = mlContext.Transforms.CopyColumns(outputColumnName: "Close", inputColumnName: "Close");

            //pipeline.Append(mlContext.Transforms.CopyColumns("HighLabel", "High"));
            //pipeline.Append(mlContext.Transforms.CopyColumns("LowLabel", "Low"));
            //pipeline.Append(mlContext.Transforms.CopyColumns("OpenLabel", "Open"));

            var pipeline = mlContext.Transforms.Concatenate("Features", "High", "Low", "Open")
                .Append(mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: "Close"))
                .Append(mlContext.Regression.Trainers.FastTree());

            var model = pipeline.Fit(dataView);
            return model;
        }


        public float[] Train2(List<PredictionCandleDud2> candleDuds)
        {
            mlContext = new MLContext(seed: 0);



                IDataView dataView = mlContext.Data.LoadFromEnumerable<PredictionCandleDud2>(candleDuds);


                var pipeline = mlContext.Forecasting.ForecastBySsa("Forecast", nameof(PredictionCandleDud.Close),
                    windowSize: 5, seriesLength: 10000, trainSize: 10000, horizon: 100);


                model = pipeline.Fit(dataView);
            

            var forecast = model.CreateTimeSeriesEngine<PredictionCandleDud2, PriceForecast>(mlContext);

            var prediction = forecast.Predict();


            return prediction.Forecast;

        }


        public Single[] TrainAndGetLastDigitPrediction(List<LastDigitPredictionClass> lastDigits)
        {
            mlContext = new MLContext(seed: 0);



            IDataView dataView = mlContext.Data.LoadFromEnumerable<LastDigitPredictionClass>(lastDigits.ToList());


            var pipeline = mlContext.Forecasting.ForecastBySsa("Forecast", nameof(LastDigitPredictionClass.LastDigit),
                windowSize: 50, seriesLength: 1000, trainSize: 10000, horizon: 100);


            model = pipeline.Fit(dataView);


            var forecast = model.CreateTimeSeriesEngine<LastDigitPredictionClass, LastDigitForecast>(mlContext);

            var prediction = forecast.Predict();


            return prediction.Forecast;

        }


        void Evaluate(MLContext mlContext, ITransformer model, List<PredictionCandleDud> candleDuds)
        {
            IDataView dataView = mlContext.Data.LoadFromEnumerable<PredictionCandleDud>(candleDuds);
            var predictions = model.Transform(dataView);
            var metrics = mlContext.Regression.Evaluate(predictions, "Label", "Score");
        }


        public float TestSinglePrediction(ITransformer model, PredictionCandleDud predict)
        {
            predict.Close = 0;

            var predictionFunction = mlContext.Model.CreatePredictionEngine<PredictionCandleDud, PredicitionCandle>(model);

            var prediction = predictionFunction.Predict(predict);


            return prediction.Close;
        }
    }
}
