using OriginInsurance.Domain.Constants;
using OriginInsurance.Domain.Models;
using OriginInsurance.Domain.Models.InsuranceTypes;

namespace OriginInsurance.Domain.Tests.Models.InsuranceTypes
{
    public class LifeInsuranceTests
    {
        [Test]
        public void GivenUserHasAgeGreaterThan60ShouldSetDisalityToIneligible()
        {
            // Arrange
            var userData = new UserData(1, 70, 0, MaritalStatus.Single, new HouseData(), new VehicleData(), new List<int>() { 1, 2, 1 });

            // Act
            var life = new LifeInsurance(userData).MapScore();

            // Assert
            Assert.That(life, Is.EqualTo(InsuranceEligibility.Ineligible));
        }

        [Test]
        public void GivenUserHasAgeBelow30ShouldDecut2FromScore()
        {
            // Arrange
            var userData = new UserData(1, 25, 0, MaritalStatus.Single, new HouseData(), new VehicleData(), new List<int>() { 5, 5 });

            // Act
            var life = new LifeInsurance(userData);

            // Assert
            Assert.That(life.InsuranceScore.Score, Is.EqualTo(8));
        }

        [Test]
        public void GivenUserHasAgeBetween30And40ShouldDecut1FromScore()
        {
            // Arrange
            var userData = new UserData(1, 35, 0, MaritalStatus.Single, new HouseData(), new VehicleData(), new List<int>() { 5, 5 });

            // Act
            var life = new LifeInsurance(userData);

            // Assert
            Assert.That(life.InsuranceScore.Score, Is.EqualTo(9));
        }

        [Test]
        public void GivenUserHas200kIncomeShouldDecut1FromScore()
        {
            // Arrange
            var userData = new UserData(200001, 50, 0, MaritalStatus.Single, new HouseData(), new VehicleData(), new List<int>() { 5, 5 });

            // Act
            var life = new LifeInsurance(userData);

            // Assert
            Assert.That(life.InsuranceScore.Score, Is.EqualTo(9));
        }

        [Test]
        public void GivenUserHasDependentesShouldAdd1ToScore()
        {
            // Arrange
            var userData = new UserData(1, 50, 2, MaritalStatus.Single, new HouseData() { OwnershipStatus = OwnershipStatus.Owned }, new VehicleData(), new List<int>() { 5, 5 });

            // Act
            var disabilityInsurance = new LifeInsurance(userData);

            // Assert
            Assert.That(disabilityInsurance.InsuranceScore.Score, Is.EqualTo(11));
        }

        [Test]
        public void GivenUserIsMarriedShouldAdd1ToScore()
        {
            // Arrange
            var userData = new UserData(1, 50, 2, MaritalStatus.Single, new HouseData() { OwnershipStatus = OwnershipStatus.Owned }, new VehicleData(), new List<int>() { 5, 5 });

            // Act
            var disabilityInsurance = new LifeInsurance(userData);

            // Assert
            Assert.That(disabilityInsurance.InsuranceScore.Score, Is.EqualTo(11));
        }
    }
}
