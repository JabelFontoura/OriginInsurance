using AutoMapper;
using OriginInsurance.Application.Dtos;
using OriginInsurance.Application.Interfaces;
using OriginInsurance.Domain.Models;
using OriginInsurance.Domain.Models.InsuranceTypes;

namespace OriginInsurance.Application.Services
{
    public class RiskCalculationService : IRiskCalculationService
    {
        private readonly IMapper _mapper;

        public RiskCalculationService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<RiskProfileDto> Calculate(UserDataDto userDataDto)
        {
            var userData = _mapper.Map<UserData>(userDataDto);

            var disability = new DisabilityInsurance(userData).MapScore();
            var life = new LifeInsurance(userData).MapScore();
            var auto = new AutoInsurance(userData).MapScore();
            var home = new HomeInsurance(userData).MapScore();

            var riskProfile = new RiskProfile(disability, life, auto, home);

            return Task.FromResult(_mapper.Map<RiskProfileDto>(riskProfile));
        }
    }
}
