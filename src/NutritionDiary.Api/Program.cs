using MediatR;
using Microsoft.AspNetCore.Http.Json;
using NutritionDiary.Api.Endpoints;
using NutritionDiary.Application;
using NutritionDiary.Application.DiaryEntries.Commands.LogDiaryEntry;
using NutritionDiary.Application.DiaryEntries.Queries.GetDiaryEntriesForUser;
using NutritionDiary.Application.DTOs;
using NutritionDiary.Infrastructure;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapDiaryEntryEndpoints();

app.Run();
