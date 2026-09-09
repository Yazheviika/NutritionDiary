using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NutritionDiary.Application.Interfaces;
using NutritionDiary.Infrastructure.ExternalApis.Usda;
using NutritionDiary.Infrastructure.Persistence;
using NutritionDiary.Infrastructure.Persistence.Repositories;

namespace NutritionDiary.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NutritionDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IFoodItemRepository, FoodItemRepository>();
            services.AddScoped<IDiaryEntryRepository, DiaryEntryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IFoodDataProvider, UsdaFoodDataProvider>();
            services.AddHttpClient("UsdaClient", client =>
            {
                client.BaseAddress = new Uri(configuration["ExternalApis:Usda:BaseUrl"]!);
            });

            return services;
        }
    }
}
