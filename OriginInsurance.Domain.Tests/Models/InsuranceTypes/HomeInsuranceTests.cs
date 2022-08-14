using OriginInsurance.Domain.Constants;
using OriginInsurance.Domain.Models;
using OriginInsurance.Domain.Models.InsuranceTypes;

namespace OriginInsurance.Domain.Tests.Models.InsuranceTypes
{
    public class HomeInsuranceTests
    {
        [Test]
        public void GivenUserDoesNotHaveIncomeShouldSethomeToIneligible()
        {
            // Arrange
            var userData = new UserData(0, 25, 0, MaritalStatus.Single, null, new VehicleData(), new List<int>() { 1, 2, 1 });

            // Act
            var home = new HomeInsurance(userData).MapScore();

            // Assert
            Assert.That(home, Is.EqualTo(InsuranceEligibility.Ineligible));
        }

        [Test]
        public void GivenUserHasAgeBelow30ShouldDecut2FromScore()
        {
            // Arrange
            var userData = new UserData(1, 25, 0, MaritalStatus.Single, new HouseData(), new VehicleData(), new List<int>() { 5, 5 });

            // Act
            var home = new HomeInsurance(userData);

            // Assert
            Assert.That(home.InsuranceScore.Score, Is.EqualTo(8));
        }

        [Test]
        public void GivenUserHasAgeBetween30And40ShouldDecut1FromScore()
        {
            // Arrange
            var userData = new UserData(1, 35, 0, MaritalStatus.Single, new HouseData(), new VehicleData(), new List<int>() { 5, 5 });

            // Act
            var home = new HomeInsurance(userData);

            // Assert
            Assert.That(home.InsuranceScore.Score, Is.EqualTo(9));
        }

        [Test]
        public void GivenUserHas200kIncomeShouldDecut1FromScore()
        {
            // Arrange
            var userData = new UserData(200001, 50, 0, MaritalStatus.Single, new HouseData(), new VehicleData(), new List<int>() { 5, 5 });

            // Act
            var home = new HomeInsurance(userData);

            // Assert
            Assert.That(home.InsuranceScore.Score, Is.EqualTo(9));
        }

        [Test]
        public void GivenUserHasMortgagedHouseShouldAdd1ToScore()
        {
            // Arrange
            var userData = new UserData(1, 50, 0, MaritalStatus.Single, new HouseData() { OwnershipStatus = OwnershipStatus.Mortgaged }, new VehicleData(), new List<int>() { 5, 5 });

            // Act
            var home = new HomeInsurance(userData);

            // Assert
            Assert.That(home.InsuranceScore.Score, Is.EqualTo(11));
        }
    }
}
