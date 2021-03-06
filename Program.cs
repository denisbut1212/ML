using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.ML;
using Microsoft.OpenApi.Models;
using MLModel_Api;

// Configure app
var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPredictionEnginePool<MlModel.ModelInput, MlModel.ModelOutput>()
    .FromFile("MLModel1.zip");

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo {Title = "ML interaction API", Description = "API docs", Version = "v1"});
});
var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1"); });

app.MapPost("/predict",
    async (PredictionEnginePool<MlModel.ModelInput, MlModel.ModelOutput> predictionEnginePool,
            MlModel.ModelInput input) =>
        await Task.FromResult(predictionEnginePool.Predict(input)));

app.Run();