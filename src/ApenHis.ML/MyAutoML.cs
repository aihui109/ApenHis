using ApenHis_ML;
using Microsoft.ML;
using Microsoft.ML.AutoML;
using static Microsoft.ML.DataOperationsCatalog;

namespace ApenHis.ML
{
    public class MyAutoML
    {
        public async Task Run()
        {
            // Create MLContext
            MLContext mlContext = new MLContext();
            // Load data
            var dataPath = Path.GetFullPath(@"taxi-fare-train.csv");
            // Infer columns
            var columnInference = mlContext.Auto().InferColumns(dataPath, labelColumnName: "fare_amount", groupColumns: false);
            // Create text loader
            var textLoader = mlContext.Data.CreateTextLoader(columnInference.TextLoaderOptions);
            // Load data into IDataView
            IDataView dataView = textLoader.Load(dataPath);
            // Create data process pipeline
            TrainTestData trainValidationData = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
            SweepablePipeline pipeline = mlContext.Auto().Featurizer(dataView, columnInformation: columnInference.ColumnInformation)
                    .Append(mlContext.Auto().Regression(labelColumnName: columnInference.ColumnInformation.LabelColumnName));
            // Create experiment settings
            var experimentSettings = new AutoMLExperiment.AutoMLExperimentSettings();
            experimentSettings.MaxExperimentTimeInSeconds = 600;
            // Create experiment
            var experiment = mlContext.Auto().CreateExperiment(experimentSettings);
            experiment.SetPipeline(pipeline)
                .SetRegressionMetric(RegressionMetric.RSquared, labelColumn: columnInference.ColumnInformation.LabelColumnName)
                .SetTrainingTimeInSeconds(60)
                .SetDataset(trainValidationData);
            // Log experiment trials
            mlContext.Log += (_, e) => {
                if (e.Source.Equals("AutoMLExperiment"))
                {
                    Console.WriteLine(e.RawMessage);
                }
            };
            // Run experiment
            var experimentResult = await experiment.RunAsync();
            if (experimentResult != null)
                mlContext.Model.Save(experimentResult.Model,dataView.Schema,"model.zip");

            //Define DataViewSchema for data preparation pipeline and trained model
            DataViewSchema modelSchema;

            // Load trained model
            ITransformer trainedModel = mlContext.Model.Load("model.zip", out modelSchema);

            var predictionEngine = mlContext.Model.CreatePredictionEngine<MLModel2.ModelInput, MLModel2.ModelOutput>(trainedModel);
            MLModel2.ModelInput modelInput = new()
            {
                Vendor_id = "CMT",
                Fare_amount = 17.5f,
                Passenger_count = 1,
                Payment_type = "CRD",
                Rate_code = 1,
                Trip_distance = 3.5f,
            };
            var prediction = predictionEngine.Predict(modelInput);
            Console.WriteLine(prediction.Fare_amount);
        }
    }
}
