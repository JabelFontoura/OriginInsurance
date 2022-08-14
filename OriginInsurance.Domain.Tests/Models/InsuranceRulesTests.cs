using OriginInsurance.Domain.Constants;
using OriginInsurance.Domain.Models;
using OriginInsurance.Domain.Models.InsuranceRules;

namespace OriginInsurance.Domain.Tests.Models
{
    public class InsuranceRulesTests
    {
        [Test]
        public void GivenUserDataWithoutCarShouldSetInsuranceScoreToIneligible()
        {
            // Arrange
            var userDataWithoutVehicle = new UserData(1, 1, 1, MaritalStatus.Married, null, null, new List<int>() { 0, 1, 0 });
            var insuranceSore = new InsuranceScore(1);

            // Act
            new DoesNotHaveVehicleRule(insuranceSore, userDataWithoutVehicle).CalculateRisk();

            // Assert
            Assert.Null(insuranceSore.Score);
        }

        [Test]
        public void GivenUserDataWithoutHouseShouldSetInsuranceScoreToIneligible()
        {
            // Arrange
            var userDataWithoutVehicle = new UserData(1, 1, 1, MaritalStatus.Married, null, null, new List<int>() { 0, 1, 0 });
            var insuranceSore = new InsuranceScore(1);

            // Act
            new DoesNotHaveHouseRule(insuranceSore, userDataWithoutVehicle).CalculateRisk();

            // Assert
            Assert.Null(insuranceSore.Score);
        }

        [Test]
        public void GivenUserDataWithoutIncomeShouldSetInsuranceScoreToIneligible()
        {
            // Arrange
            var userDataWithoutVehicle = new UserData(0, 1, 1, MaritalStatus.Married, null, null, new List<int>() { 0, 1, 0 });
            var insuranceSore = new InsuranceScore(1);

            // Act
            new DoesNotHaveIncomeRule(insuranceSore, userDataWithoutVehicle).CalculateRisk();

            // Assert
            Assert.Null(insuranceSore.Score);
        }

        [Test]
        public void GivenUserDataHasAgeBetween30And40ShouldDeduct1FromScore()
        {
            // Arrange
            var userDataWithoutVehicle = new UserData(1, 35, 1, MaritalStatus.Married, null, null, new List<int>() { 0, 1, 0 });
            var insuranceSore = new InsuranceScore(1);

            // Act
            new HasAgeBetween30And40Rule(insuranceSore, userDataWithoutVehicle).CalculateRisk();

            // Assert
            Assert.Zero(insuranceSore.Score.Value);
        }

        [Test]
        public void GivenUserDataHasAgeAbove60InsuranceScoreToIneligible()
        {
            // Arrange
            var userDataWithoutVehicle = new UserData(1, 70, 1, MaritalStatus.Married, null, null, new List<int>() { 0, 1, 0 });
            var insuranceSore = new InsuranceScore(1);

            // Act
            new HasAgeGreaterThan60Rule(insuranceSore, userDataWithoutVehicle).CalculateRisk();

            // Assert
            Assert.Null(insuranceSore.Score);
        }

        [Test]
        public void GivenUserDataHasAgeUnder30ShouldDeduct2FromScore()
        {
            // Arrange
            var userDataWithoutVehicle = new UserData(1, 25, 1, MaritalStatus.Married, null, null, new List<int>() { 0, 2, 0 });
            var insuranceSore = new InsuranceScore(2);

            // Act
            new HasAgeUnder30Rule(insuranceSore, userDataWithoutVehicle).CalculateRisk();

            // Assert
            Assert.That(insuranceSore.Score.Value, Is.EqualTo(0));
        }

        [Test]
        public void GivenUserDataHasDependentsShouldAdd1ToScore()
        {
            // Arrange
            var userDataWithoutVehicle = new UserData(1, 50, 1, MaritalStatus.Married, null, null, new List<int>() { 0, 1, 0 });
            var insuranceSore = new InsuranceScore(1);

            // Act
            new HasDependentsRule(insuranceSore, userDataWithoutVehicle).CalculateRisk();

            // Assert
            Assert.That(insuranceSore.Score.Value, Is.EqualTo(2));
        }

        [Test]
        public void GivenUserDataHasIncomeAbove200kShouldDeduct1FromScore()
        {
            // Arrange
            var userDataWithoutVehicle = new UserData(300000, 35, 1, MaritalStatus.Married, null, null, new List<int>() { 0, 1, 0 });
            var insuranceSore = new InsuranceScore(1);

            // Act
            new HasIncomeAbove200kRule(insuranceSore, userDataWithoutVehicle).CalculateRisk();

            // Assert
            Assert.That(insuranceSore.Score.Value, Is.EqualTo(0));
        }

        [Test]
        public void GivenUserDataHasMortgagedHouseShouldAdd1ToScore()
        {
            // Arrange
            var userDataWithoutVehicle = new UserData(1, 35, 1, MaritalStatus.Married, new HouseData(OwnershipStatus.Mortgaged), null, new List<int>() { 0, 1, 0 });
            var insuranceSore = new InsuranceScore(1);

            // Act
            new HasMortgagedHouseRule(insuranceSore, userDataWithoutVehicle).CalculateRisk();

            // Assert
            Assert.That(insuranceSore.Score.Value, Is.EqualTo(2));
        }

        [Test]
        public void GivenUserDataIsMarriedShouldDeduct1FromScore()
        {
            // Arrange
            var userDataWithoutVehicle = new UserData(1, 35, 1, MaritalStatus.Married, null, null, new List<int>() { 0, 1, 0 });
            var insuranceSore = new InsuranceScore(1);

            // Act
            new IsMarriedDisabilityRiskRule(insuranceSore, userDataWithoutVehicle).CalculateRisk();

            // Assert
            Assert.That(insuranceSore.Score.Value, Is.EqualTo(0));
        }

        [Test]
        public void GivenUserDataIsMarriedShouldAdd1ToScore()
        {
            // Arrange
            var userDataWithoutVehicle = new UserData(1, 35, 1, MaritalStatus.Married, null, null, new List<int>() { 0, 1, 0 });
            var insuranceSore = new InsuranceScore(1);

            // Act
            new IsMarriedLifeRiskRule(insuranceSore, userDataWithoutVehicle).CalculateRisk();

            // Assert
            Assert.That(insuranceSore.Score.Value, Is.EqualTo(2));
        }

        [Test]
        public void GivenUserDataVehicleWasProducedInLast5YearsShouldAdd1ToScore()
        {
            // Arrange
            var userDataWithoutVehicle = new UserData(1, 35, 1, MaritalStatus.Married, null, new VehicleData(DateTime.Now.Year - 2), new List<int>() { 0, 1, 0 });
            var insuranceSore = new InsuranceScore(1);

            // Act
            new VehicleWasProducedInLast5Years(insuranceSore, userDataWithoutVehicle).CalculateRisk();

            // Assert
            Assert.That(insuranceSore.Score.Value, Is.EqualTo(2));
        }
    }
}
