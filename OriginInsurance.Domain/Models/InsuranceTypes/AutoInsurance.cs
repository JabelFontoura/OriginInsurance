using OriginInsurance.Domain.Models.InsuranceRules;

namespace OriginInsurance.Domain.Models.InsuranceTypes
{
    public class AutoInsurance : BaseInsurance
    {
        public override HashSet<InsuranceRule> Rules
        {
            get => new HashSet<InsuranceRule>()
            {
                new DoesNotHaveVehicleRule(InsuranceScore, UserData),
                new HasAgeUnder30Rule(InsuranceScore, UserData),
                new HasAgeBetween30And40Rule(InsuranceScore, UserData),
                new HasIncomeAbove200kRule(InsuranceScore, UserData),
                new VehicleWasProducedInLast5Years(InsuranceScore, UserData)
            };
        }

        public AutoInsurance(UserData userData) : base(userData) { }
    }
}
