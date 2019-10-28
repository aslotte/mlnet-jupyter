using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.ML;
using ProductCategoryFunctionsApp;
using ProductCategoryFunctionsApp.Models;

[assembly: FunctionsStartup(typeof(Startup))]
namespace ProductCategoryFunctionsApp
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddPredictionEnginePool<ProductInformation, ProductCategoryPrediction>()
               .FromFile(modelName: "ProductCategoryModel", filePath: "MLModels/productCategoryClassifier.zip", watchForChanges: true);
        }
    }
}
