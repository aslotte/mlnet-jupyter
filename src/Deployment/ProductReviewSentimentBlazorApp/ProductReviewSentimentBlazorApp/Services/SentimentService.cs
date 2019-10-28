using Microsoft.Extensions.ML;
using ProductReviewSentimentBlazorApp.ML.Models;

namespace ProductReviewSentimentBlazorApp.Services
{
    public class SentimentService
    {
        private readonly PredictionEnginePool<ProductReview, ReviewSentimentPrediction> predictionEnginePool;

        public SentimentService(PredictionEnginePool<ProductReview, ReviewSentimentPrediction> predictionEnginePool)
        {
            this.predictionEnginePool = predictionEnginePool;
        }

        public ReviewSentimentPrediction Predict(string review)
        {
            var data = new ProductReview { Review = review };

            return this.predictionEnginePool.Predict(data);
        }
    }
}
