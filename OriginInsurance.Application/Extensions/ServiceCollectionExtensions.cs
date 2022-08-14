using Microsoft.Extensions.DependencyInjection;
using OriginInsurance.Application.Interfaces;
using OriginInsurance.Application.AutoMapper;
using OriginInsurance.Application.Services;

namespace OriginInsurance.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IRiskCalculationService, RiskCalculationService>();
            services.AddAutoMapper(typeof(AutoMapperConfiguration));

            return services;
        }
    }
}
