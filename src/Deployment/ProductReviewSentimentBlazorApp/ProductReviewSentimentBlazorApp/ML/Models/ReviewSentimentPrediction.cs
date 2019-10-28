using Microsoft.ML.Data;

namespace ProductReviewSentimentBlazorApp.ML.Models
{
    public class ReviewSentimentPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool IsPositive { get; set; }

        public float Score { get; set; }
    }
}
