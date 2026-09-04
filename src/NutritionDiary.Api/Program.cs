using MediatR;
using Microsoft.AspNetCore.Http.Json;
using NutritionDiary.Application;
using NutritionDiary.Application.DiaryEntries.Commands.LogDiaryEntry;
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

app.MapPost("/api/diaryentries", async (LogDiaryEntryCommand command, IMediator mediator, CancellationToken cancellationToken) =>
{
    var result = await mediator.Send(command, cancellationToken);

    return result.IsSuccess
    ? Results.Ok(result.Value)
    : Results.BadRequest(result.Error);
})
.Produces<DiaryEntryResponse>(StatusCodes.Status200OK)
.ProducesProblem(StatusCodes.Status400BadRequest);

app.Run();
