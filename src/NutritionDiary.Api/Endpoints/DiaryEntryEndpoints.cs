using MediatR;
using NutritionDiary.Application.DiaryEntries.Commands.LogDiaryEntry;
using NutritionDiary.Application.DiaryEntries.Queries.GetDiaryEntriesForUser;
using NutritionDiary.Application.DTOs;

namespace NutritionDiary.Api.Endpoints
{
    public static class DiaryEntryEndpoints
    {
        public static IEndpointRouteBuilder MapDiaryEntryEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/diaryentries").WithTags("DiaryEntries");

            group.MapPost("/", async (LogDiaryEntryCommand command, IMediator mediator, CancellationToken cancellationToken) =>
            {
                var result = await mediator.Send(command, cancellationToken);
                
                return result.IsSuccess
                ? Results.Ok(result.Value)
                : Results.BadRequest(result.Error);
            })
            .Produces<DiaryEntryResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest);

            group.MapGet("/", async ([AsParameters] GetDiaryEntriesForUserQuery query, IMediator mediator, CancellationToken cancellationToken) =>
                Results.Ok(await mediator.Send(query, cancellationToken)))
            .Produces<List<DiaryEntryResponse>>(StatusCodes.Status200OK);

            return app;
        }
    }
}
