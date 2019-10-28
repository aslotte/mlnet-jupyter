using Microsoft.ML.Data;

namespace ProductReviewSentimentBlazorApp.ML.Models
{
    public class ProductReview
    {
        [LoadColumn(0)]
        public bool Sentiment;

        [LoadColumn(1)]
        public string Review;
    }
}
