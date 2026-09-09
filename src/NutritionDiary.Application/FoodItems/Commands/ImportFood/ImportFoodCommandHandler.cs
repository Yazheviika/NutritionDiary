using MediatR;
using NutritionDiary.Application.Common;
using NutritionDiary.Application.Common.Mapping;
using NutritionDiary.Application.DTOs;
using NutritionDiary.Application.Interfaces;

namespace NutritionDiary.Application.FoodItems.Commands.ImportFood
{
    public class ImportFoodCommandHandler : IRequestHandler<ImportFoodCommand, Result<ProductResponse>>
    {
        private readonly ProductMapper _mapper;
        private readonly IFoodDataProvider _foodDataProvider;
        private readonly IFoodItemRepository _foodItemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ImportFoodCommandHandler(
            ProductMapper mapper, 
            IFoodDataProvider foodDataProvider, 
            IFoodItemRepository foodItemRepository,
            IUnitOfWork unitOfWorl)
        {
            _mapper = mapper;
            _foodDataProvider = foodDataProvider;
            _foodItemRepository = foodItemRepository;
            _unitOfWork = unitOfWorl;
        }

        public async Task<Result<ProductResponse>> Handle(ImportFoodCommand request, CancellationToken cancellationToken)
        {
            var existingProduct = await _foodItemRepository.GetBySourceAndExternalIdAsync(request.Source, request.ExternalId, cancellationToken);

            if(existingProduct != null)
            {
                return Result<ProductResponse>.Success(_mapper.ToResponse(existingProduct));
            }

            var foodDetail = await _foodDataProvider.ImportAsync(request.ExternalId, cancellationToken);

            if(foodDetail != null)
            {
                _foodItemRepository.Add(foodDetail);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return Result<ProductResponse>.Success(_mapper.ToResponse(foodDetail));
            }

            return Result<ProductResponse>.Failure($"Could not import food with external ID '{request.ExternalId}' " +
                "— not found or missing required nutrition data");
        }
    }
}