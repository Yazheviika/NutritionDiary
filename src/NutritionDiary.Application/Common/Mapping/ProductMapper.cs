using NutritionDiary.Application.DTOs;
using NutritionDiary.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace NutritionDiary.Application.Common.Mapping
{
    [Mapper]
    public partial class ProductMapper
    {
        [MapperIgnoreSource(nameof(Product.ExternalId))]
        public partial ProductResponse ToResponse(Product product);
    }
}