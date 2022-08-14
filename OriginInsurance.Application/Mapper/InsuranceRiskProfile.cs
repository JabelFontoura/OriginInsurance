using AutoMapper;
using OriginInsurance.Application.Dtos;
using OriginInsurance.Domain.Models;

namespace OriginInsurance.Application.AutoMapper
{
    public class InsuranceRiskProfile : Profile
    {
        public InsuranceRiskProfile()
        {
            CreateMap<UserData, UserDataDto>();
            CreateMap<UserDataDto, UserData>();

            CreateMap<RiskProfile, RiskProfileDto>();
            CreateMap<RiskProfileDto, RiskProfile>();

            CreateMap<HouseData, HouseDataDto>();
            CreateMap<HouseDataDto, HouseData>();

            CreateMap<VehicleData, VehicleDataDto>();
            CreateMap<VehicleDataDto, VehicleData>();
        }
    }
}
