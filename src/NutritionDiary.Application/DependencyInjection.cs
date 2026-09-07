using Microsoft.Extensions.DependencyInjection;
using NutritionDiary.Application.Common.Mapping;
using System.Reflection;

namespace NutritionDiary.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddSingleton<DiaryEntryMapper>();
            return services;
        }
    }
}