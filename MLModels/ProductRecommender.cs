using Microsoft.ML.Trainers;
using Microsoft.ML;
using StellantisSupportAPI.MLModels;


    using Microsoft.ML;
    using Microsoft.ML.Data;
    using Microsoft.ML.Trainers; // Adicione essa linha

    public class ProductRecommender
{
    private readonly MLContext _mlContext;
    private ITransformer _model;

    public bool ModelTrained { get; private set; } = false;

    public ProductRecommender()
    {
        _mlContext = new MLContext();
    }

    public void TrainModel(string dataPath)
    {
        var data = _mlContext.Data.LoadFromTextFile<ProductInteraction>(dataPath, separatorChar: ',', hasHeader: true);

        var options = new MatrixFactorizationTrainer.Options
        {
            MatrixColumnIndexColumnName = nameof(ProductInteraction.UserId),
            MatrixRowIndexColumnName = nameof(ProductInteraction.ProductId),
            LabelColumnName = nameof(ProductInteraction.Label),
            NumberOfIterations = 20,
            ApproximationRank = 100
        };

        var pipeline = _mlContext.Recommendation().Trainers.MatrixFactorization(options);

        _model = pipeline.Fit(data);
        ModelTrained = true;
    }

    public float Predict(float userId, float productId)
    {
        if (!ModelTrained)
        {
            throw new InvalidOperationException("The model has not been trained yet.");
        }

        var predictionEngine = _mlContext.Model.CreatePredictionEngine<ProductInteraction, ProductPrediction>(_model);
        var prediction = predictionEngine.Predict(new ProductInteraction { UserId = userId, ProductId = productId });
        return prediction.Score;
    }
}

public class ProductPrediction
{
    public float Score { get; set; }
}
