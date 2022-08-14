using AutoMapper;
using OriginInsurance.Application.AutoMapper;
using OriginInsurance.Application.Dtos;
using OriginInsurance.Application.Interfaces;
using OriginInsurance.Application.Services;
using OriginInsurance.Domain.Constants;

namespace OriginInsurance.Application.Tests.Services
{
    [TestFixtureSource(nameof(FixtureArgs))]
    public class RiskCalculationServiceTests
    {
        static object[] FixtureArgs = {
            new object[] { new UserDataDto()
            {
                Age = 35,
                Income = 0,
                Dependents = 2,
                House = new HouseDataDto() { OwnershipStatus = OwnershipStatus.Owned},
                MaritalStatus = MaritalStatus.Married,
                Vehicle = new VehicleDataDto() { Year = 2018 },
                RiskQuestions = new List<int>() { 0, 1, 0}
            }, new RiskProfileDto()
            {
                Auto = InsuranceEligibility.Regular,
                Disability = InsuranceEligibility.Ineligible,
                Home = InsuranceEligibility.Economic,
                Life = InsuranceEligibility.Regular
            }},

            new object[] { new UserDataDto()
            {
                Age = 35,
                Income = 0,
                Dependents = 2,
                House = null,
                MaritalStatus = MaritalStatus.Married,
                Vehicle = new VehicleDataDto() { Year = 2018 },
                RiskQuestions = new List<int>() { 0, 1, 0}
            }, new RiskProfileDto()
            {
                Auto = InsuranceEligibility.Regular,
                Disability = InsuranceEligibility.Ineligible,
                Home = InsuranceEligibility.Ineligible,
                Life = InsuranceEligibility.Regular
            }},

            new object[] { new UserDataDto()
            {
                Age = 35,
                Income = 0,
                Dependents = 2,
                House = new HouseDataDto() { OwnershipStatus = OwnershipStatus.Owned},
                MaritalStatus = MaritalStatus.Married,
                Vehicle = null,
                RiskQuestions = new List<int>() { 0, 1, 0}
            }, new RiskProfileDto()
            {
                Auto = InsuranceEligibility.Ineligible,
                Disability = InsuranceEligibility.Ineligible,
                Home = InsuranceEligibility.Economic,
                Life = InsuranceEligibility.Regular
            }},

            new object[] { new UserDataDto()
            {
                Age = 70,
                Income = 0,
                Dependents = 2,
                House = new HouseDataDto() { OwnershipStatus = OwnershipStatus.Owned},
                MaritalStatus = MaritalStatus.Married,
                Vehicle = new VehicleDataDto() { Year = 2018 },
                RiskQuestions = new List<int>() { 0, 1, 0}
            }, new RiskProfileDto()
            {
                Auto = InsuranceEligibility.Regular,
                Disability = InsuranceEligibility.Ineligible,
                Home = InsuranceEligibility.Regular,
                Life = InsuranceEligibility.Ineligible
            }},

        };

        private UserDataDto UserDataDto;
        private RiskProfileDto RiskProfileDto;

        public RiskCalculationServiceTests(UserDataDto userDataDto, RiskProfileDto riskProfileDto)
        {
            UserDataDto = userDataDto;
            RiskProfileDto = riskProfileDto;
        }

        private IMapper _mapper;
        private IRiskCalculationService _service;

        [SetUp]
        public void SetUp()
        {
            _mapper = new Mapper(AutoMapperConfiguration.RegisterMappings());
            _service = new RiskCalculationService(_mapper);
        }

        [Test]
        public async Task TestCalculate()
        {
            // Act
            var result = await _service.Calculate(UserDataDto);

            // Assert
            Assert.That(result.Auto, Is.EqualTo(RiskProfileDto.Auto));
            Assert.That(result.Life, Is.EqualTo(RiskProfileDto.Life));
            Assert.That(result.Home, Is.EqualTo(RiskProfileDto.Home));
            Assert.That(result.Disability, Is.EqualTo(RiskProfileDto.Disability));

        }
    }
}
