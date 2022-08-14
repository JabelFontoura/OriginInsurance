using OriginInsurance.Application.Dtos;

namespace OriginInsurance.Application.Interfaces
{
    public interface IRiskCalculationService
    {
        Task<RiskProfileDto> Calculate(UserDataDto userData);
    }
}
