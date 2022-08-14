using OriginInsurance.Domain.Constants;
using OriginInsurance.Domain.Models;
using OriginInsurance.Domain.Models.InsuranceTypes;

namespace OriginInsurance.Domain.Tests.Models.InsuranceTypes
{
    public class DisabilityInsuranceTest
    {
        [Test]
        public void GivenUserDoesNotHaveIncomeShouldSetDisalityToIneligible()
        {
            // Arrange
            var userData = new UserData(0, 25, 0, MaritalStatus.Single, new HouseData(), new VehicleData(), new List<int>() { 1, 2, 1 });

            // Act
            var disability = new DisabilityInsurance(userData).MapScore();

            // Assert
            Assert.That(disability, Is.EqualTo(InsuranceEligibility.Ineligible));
        }

        [Test]
        public void GivenUserHasAgeGreaterThan60ShouldSetDisalityToIneligible()
        {
            // Arrange
            var userData = new UserData(1, 70, 0, MaritalStatus.Single, new HouseData(), new VehicleData(), new List<int>() { 1, 2, 1 });

            // Act
            var disability = new DisabilityInsurance(userData).MapScore();

            // Assert
            Assert.That(disability, Is.EqualTo(InsuranceEligibility.Ineligible));
        }

        [Test]
        public void GivenUserHasAgeBelow30ShouldDecut2FromScore()
        {
            // Arrange
            var userData = new UserData(1, 25, 0, MaritalStatus.Single, new HouseData(), new VehicleData(), new List<int>() { 5, 5 });

            // Act
            var disabilityInsurance = new DisabilityInsurance(userData);
            var disability = disabilityInsurance.MapScore();

            // Assert
            Assert.That(disabilityInsurance.InsuranceScore.Score, Is.EqualTo(8));
            Assert.That(disability, Is.EqualTo(InsuranceEligibility.Responsible));
        }

        [Test]
        public void GivenUserHasAgeBetween30And40ShouldDecut1FromScore()
        {
            // Arrange
            var userData = new UserData(1, 35, 0, MaritalStatus.Single, new HouseData(), new VehicleData(), new List<int>() { 5, 5 });

            // Act
            var disabilityInsurance = new DisabilityInsurance(userData);
            var disability = disabilityInsurance.MapScore();

            // Assert
            Assert.That(disabilityInsurance.InsuranceScore.Score, Is.EqualTo(9));
            Assert.That(disability, Is.EqualTo(InsuranceEligibility.Responsible));
        }

        [Test]
        public void GivenUserHas200kIncomeShouldDecut1FromScore()
        {
            // Arrange
            var userData = new UserData(200001, 50, 0, MaritalStatus.Single, new HouseData(), new VehicleData(), new List<int>() { 5, 5 });

            // Act
            var disabilityInsurance = new DisabilityInsurance(userData);
            var disability = disabilityInsurance.MapScore();

            // Assert
            Assert.That(disabilityInsurance.InsuranceScore.Score, Is.EqualTo(9));
            Assert.That(disability, Is.EqualTo(InsuranceEligibility.Responsible));
        }

        [Test]
        public void GivenUserHasMortgagedHouseShouldAdd1ToScore()
        {
            // Arrange
            var userData = new UserData(1, 50, 0, MaritalStatus.Single, new HouseData() { OwnershipStatus = OwnershipStatus.Mortgaged }, new VehicleData(), new List<int>() { 5, 5 });

            // Act
            var disabilityInsurance = new DisabilityInsurance(userData);
            var disability = disabilityInsurance.MapScore();

            // Assert
            Assert.That(disabilityInsurance.InsuranceScore.Score, Is.EqualTo(11));
            Assert.That(disability, Is.EqualTo(InsuranceEligibility.Responsible));
        }

        [Test]
        public void GivenUserHasDependentesShouldAdd1ToScore()
        {
            // Arrange
            var userData = new UserData(1, 50, 2, MaritalStatus.Single, new HouseData() { OwnershipStatus = OwnershipStatus.Owned }, new VehicleData(), new List<int>() { 5, 5 });

            // Act
            var disabilityInsurance = new DisabilityInsurance(userData);
            var disability = disabilityInsurance.MapScore();

            // Assert
            Assert.That(disabilityInsurance.InsuranceScore.Score, Is.EqualTo(11));
            Assert.That(disability, Is.EqualTo(InsuranceEligibility.Responsible));
        }

        [Test]
        public void GivenUserIsMarriedShouldDecut1FromScore()
        {
            // Arrange
            var userData = new UserData(1, 50, 0, MaritalStatus.Married, new HouseData() { OwnershipStatus = OwnershipStatus.Owned }, new VehicleData(), new List<int>() { 5, 5 });

            // Act
            var disabilityInsurance = new DisabilityInsurance(userData);
            var disability = disabilityInsurance.MapScore();

            // Assert
            Assert.That(disabilityInsurance.InsuranceScore.Score, Is.EqualTo(9));
            Assert.That(disability, Is.EqualTo(InsuranceEligibility.Responsible));
        }
    }
}