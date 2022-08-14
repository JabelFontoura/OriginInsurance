using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OriginInsurance.Application.Dtos;
using OriginInsurance.Application.Interfaces;
using OriginInsurance.Domain.Constants;
using OriginInsurance.WebApi.Controllers;
using OriginInsurance.WebApi.Validations;

namespace OriginInsurance.WebApi.Tests.Controllers
{
    public class InsuranceControllerTests
    {
        private Mock<IRiskCalculationService> _mockRiskCalculationService;
        private IValidator<UserDataDto> _validator;
        private UserDataDto _userDataWithCorrectValues;

        [SetUp]
        public void SetUp()
        {
            _mockRiskCalculationService = new Mock<IRiskCalculationService>();
            _mockRiskCalculationService.Setup(x => x.Calculate(It.IsAny<UserDataDto>())).Returns(Task.FromResult(new RiskProfileDto()));
            _validator = new UserDataDtoValidator();
            _userDataWithCorrectValues = new UserDataDto()
            {
                Age = 1,
                Income = 1,
                Dependents = 1,
                House = null,
                MaritalStatus = MaritalStatus.Married,
                RiskQuestions = new List<int>() { 1, 1, 1 },
                Vehicle = null
            };
        }

        [Test]
        public async Task GivenAllFieldsAreValidShouldReturnOk()
        {
            // Arrange
            var userDataDto = _userDataWithCorrectValues;

            // Act
            var result = await new InsuranceController(_validator, _mockRiskCalculationService.Object).CalculateRisk(userDataDto);

            // Assert
            Assert.IsInstanceOf(typeof(OkObjectResult), result);
        }

        [Test]
        public async Task GivenAllFieldsAreValidAndAgeIsIncorrectShouldReturnBadRequest()
        {
            // Arrange
            var userDataDto = _userDataWithCorrectValues;
            userDataDto.Age = -1;

            // Act
            var result = await new InsuranceController(_validator, _mockRiskCalculationService.Object).CalculateRisk(userDataDto);

            // Assert
            Assert.IsInstanceOf(typeof(BadRequestObjectResult), result);
        }

        [Test]
        public async Task GivenAllFieldsAreValidAndIncomeIsIncorrectShouldReturnBadRequest()
        {
            // Arrange
            var userDataDto = _userDataWithCorrectValues;
            userDataDto.Income = -1;

            // Act
            var result = await new InsuranceController(_validator, _mockRiskCalculationService.Object).CalculateRisk(userDataDto);

            // Assert
            Assert.IsInstanceOf(typeof(BadRequestObjectResult), result);
        }

        [Test]
        public async Task GivenAllFieldsAreValidAndDependentsIsIncorrectShouldReturnBadRequest()
        {
            // Arrange
            var userDataDto = _userDataWithCorrectValues;
            userDataDto.Dependents = -1;

            // Act
            var result = await new InsuranceController(_validator, _mockRiskCalculationService.Object).CalculateRisk(userDataDto);

            // Assert
            Assert.IsInstanceOf(typeof(BadRequestObjectResult), result);
        }

        [Test]
        public async Task GivenAllFieldsAreValidAndMaritalStatusIsIncorrectShouldReturnBadRequest()
        {
            // Arrange
            var userDataDto = _userDataWithCorrectValues;
            userDataDto.MaritalStatus = "Not Valid";

            // Act
            var result = await new InsuranceController(_validator, _mockRiskCalculationService.Object).CalculateRisk(userDataDto);

            // Assert
            Assert.IsInstanceOf(typeof(BadRequestObjectResult), result);
        }

        [Test]
        public async Task GivenAllFieldsAreValidAndRiskQuestionsIsIncorrectShouldReturnBadRequest()
        {
            // Arrange
            var userDataDto = _userDataWithCorrectValues;
            userDataDto.RiskQuestions = null;

            // Act
            var result = await new InsuranceController(_validator, _mockRiskCalculationService.Object).CalculateRisk(userDataDto);

            // Assert
            Assert.IsInstanceOf(typeof(BadRequestObjectResult), result);
        }

        [Test]
        public async Task GivenAllFieldsAreValidAndHouseIsIncorrectShouldReturnBadRequest()
        {
            // Arrange
            var userDataDto = _userDataWithCorrectValues;
            userDataDto.House = new HouseDataDto() { OwnershipStatus = "Not valid" };

            // Act
            var result = await new InsuranceController(_validator, _mockRiskCalculationService.Object).CalculateRisk(userDataDto);

            // Assert
            Assert.IsInstanceOf(typeof(BadRequestObjectResult), result);
        }
    }
}
