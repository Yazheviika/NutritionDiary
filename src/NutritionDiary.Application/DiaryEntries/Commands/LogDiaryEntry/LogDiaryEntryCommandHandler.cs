using MediatR;
using NutritionDiary.Application.Common;
using NutritionDiary.Application.Common.Mapping;
using NutritionDiary.Application.DTOs;
using NutritionDiary.Application.Interfaces;
using NutritionDiary.Domain.Entities;

namespace NutritionDiary.Application.DiaryEntries.Commands.LogDiaryEntry
{
    public class LogDiaryEntryCommandHandler : IRequestHandler<LogDiaryEntryCommand, Result<DiaryEntryResponse>>
    {
        private readonly IFoodItemRepository _foodItemRepository;
        private readonly IDiaryEntryRepository _diaryEntryRepository;
        private readonly DiaryEntryMapper _diaryEntryMapper;
        private readonly IUnitOfWork _unitOfWork;

        public LogDiaryEntryCommandHandler(IFoodItemRepository foodItemRepository, IDiaryEntryRepository diaryEntryRepository, DiaryEntryMapper diaryEntryMapper, IUnitOfWork unitOfWork)
        {
            _foodItemRepository = foodItemRepository;
            _diaryEntryRepository = diaryEntryRepository;
            _diaryEntryMapper = diaryEntryMapper;
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

            var result = _diaryEntryMapper.ToResponse(diaryEntry);
            return Result<DiaryEntryResponse>.Success(result);
        }
    }
}