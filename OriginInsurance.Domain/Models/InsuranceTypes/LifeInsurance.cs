using OriginInsurance.Domain.Models.InsuranceRules;

namespace OriginInsurance.Domain.Models.InsuranceTypes
{
    public class LifeInsurance : BaseInsurance
    {
        public override HashSet<InsuranceRule> Rules
        {
            get => new HashSet<InsuranceRule>()
            {
                new HasAgeGreaterThan60Rule(InsuranceScore, UserData),
                new HasIncomeAbove200kRule(InsuranceScore, UserData),
                new HasAgeUnder30Rule(InsuranceScore, UserData),
                new HasAgeBetween30And40Rule(InsuranceScore, UserData),
                new HasDependentsRule(InsuranceScore, UserData),
                new IsMarriedLifeRiskRule(InsuranceScore, UserData)
            };
        }

        public LifeInsurance(UserData userData) : base(userData) { }
    }
}
