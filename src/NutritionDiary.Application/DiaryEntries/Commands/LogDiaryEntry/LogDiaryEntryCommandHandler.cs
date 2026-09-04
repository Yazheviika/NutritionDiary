using MediatR;
using NutritionDiary.Application.Common;
using NutritionDiary.Application.DTOs;
using NutritionDiary.Application.Interfaces;
using NutritionDiary.Domain.Entities;

namespace NutritionDiary.Application.DiaryEntries.Commands.LogDiaryEntry
{
    public class LogDiaryEntryCommandHandler : IRequestHandler<LogDiaryEntryCommand, Result<DiaryEntryResponse>>
    {
        private readonly IFoodItemRepository _foodItemRepository;
        private readonly IDiaryEntryRepository _diaryEntryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public LogDiaryEntryCommandHandler(IFoodItemRepository foodItemRepository, IDiaryEntryRepository diaryEntryRepository, IUnitOfWork unitOfWork)
        {
            _foodItemRepository = foodItemRepository;
            _diaryEntryRepository = diaryEntryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<DiaryEntryResponse>> Handle(LogDiaryEntryCommand request, CancellationToken cancellationToken)
        {
            var foodItem = await _foodItemRepository.GetByIdAsync(request.FoodId, cancellationToken);

            if(foodItem == null)
            {
                return Result<DiaryEntryResponse>.Failure("Food item not found");
            }

            var diaryEntry = new DiaryEntry
            {
                UserId = request.UserId,
                FoodItem = foodItem,
                FoodItemName = foodItem.Name,
                NutritionTotalsSnapshot = foodItem.GetNutritionTotals(request.QuantityInG),
                QuantityInG = request.QuantityInG,
                Meal = request.Meal,
                Date = request.Date
            };

            _diaryEntryRepository.Add(diaryEntry);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<DiaryEntryResponse>.Success(new DiaryEntryResponse
            {
                Id = diaryEntry.Id,
                FoodItemName = diaryEntry.FoodItemName,
                NutritionTotals = diaryEntry.NutritionTotalsSnapshot,
                QuantityInG = diaryEntry.QuantityInG,
                Meal = diaryEntry.Meal,
                Date = diaryEntry.Date
            });
        }
    }
}