using FluentValidation;
using OriginInsurance.Application.Dtos;

namespace OriginInsurance.WebApi.Validations
{
    public static class ValidationServiceCollectionExtension
    {
        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.AddScoped<IValidator<UserDataDto>, UserDataDtoValidator>();

            return services;
        }
    }
}
