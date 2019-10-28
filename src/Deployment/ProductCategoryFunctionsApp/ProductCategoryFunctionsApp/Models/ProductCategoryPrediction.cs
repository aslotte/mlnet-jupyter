using Microsoft.ML.Data;

namespace ProductCategoryFunctionsApp.Models
{
    public class ProductCategoryPrediction
    {
        [ColumnName("PredictedLabel")]
        public string Category { get; set; }

        public float[] Score { get; set; }
    }
}
