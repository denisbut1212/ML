using System;
using System.IO;
using Microsoft.ML;

namespace MLModel_Api
{
    public partial class MlModel
    {
        private static readonly string MlModelPath = Path.GetFullPath("MLModel1.zip");

        public static readonly Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictEngine =
            new(CreatePredictEngine, true);

        /// <summary>
        /// Use this method to predict on <see cref="ModelInput"/>.
        /// </summary>
        /// <param name="input">model input.</param>
        /// <returns><seealso cref=" ModelOutput"/></returns>
        public static ModelOutput Predict(ModelInput input)
        {
            var predictEngineValue = PredictEngine.Value;
            return predictEngineValue.Predict(input);
        }

        private static PredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
        {
            var mlContext = new MLContext();
            var mlModel = mlContext.Model.Load(MlModelPath, out _);

            return mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }
    }
}