using OriginInsurance.Domain.Models.InsuranceRules;

namespace OriginInsurance.Domain.Models.InsuranceTypes
{
    public class DisabilityInsurance : BaseInsurance
    {
        public override HashSet<InsuranceRule> Rules
        {
            get => new HashSet<InsuranceRule>()
            {
                new DoesNotHaveIncomeRule(InsuranceScore, UserData),
                new HasAgeGreaterThan60Rule(InsuranceScore, UserData),
                new HasAgeUnder30Rule(InsuranceScore, UserData),
                new HasAgeBetween30And40Rule(InsuranceScore, UserData),
                new HasIncomeAbove200kRule(InsuranceScore, UserData),
                new HasMortgagedHouseRule(InsuranceScore, UserData),
                new HasDependentsRule(InsuranceScore, UserData),
                new IsMarriedDisabilityRiskRule(InsuranceScore, UserData)
            };
        }

        public DisabilityInsurance(UserData userData) : base(userData) { }
    }
}
