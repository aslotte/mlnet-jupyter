using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.ML;
using Newtonsoft.Json;
using ProductCategoryFunctionsApp.Models;
using System.IO;
using System.Threading.Tasks;

namespace ProductCategoryFunctionsApp
{
    public class ProductCategoryPredictionFunction
    {
        private readonly PredictionEnginePool<ProductInformation, ProductCategoryPrediction> predictionEnginePool;

        public ProductCategoryPredictionFunction(PredictionEnginePool<ProductInformation, ProductCategoryPrediction> predictionEnginePool)
        {
            this.predictionEnginePool = predictionEnginePool;
        }

        [FunctionName("PredictProductCategory")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<ProductInformation>(requestBody);

            //Make prediction
            var prediction = predictionEnginePool.Predict(modelName: "ProductCategoryModel", data);

            return new OkObjectResult(prediction.Category);
        }
    }
}
