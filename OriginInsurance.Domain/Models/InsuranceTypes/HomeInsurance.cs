using OriginInsurance.Domain.Models.InsuranceRules;

namespace OriginInsurance.Domain.Models.InsuranceTypes
{
    public class HomeInsurance : BaseInsurance
    {
        public override HashSet<InsuranceRule> Rules
        {
            get => new HashSet<InsuranceRule>()
            {
                new DoesNotHaveHouseRule(InsuranceScore, UserData),
                new HasAgeUnder30Rule(InsuranceScore, UserData),
                new HasAgeBetween30And40Rule(InsuranceScore, UserData),
                new HasIncomeAbove200kRule(InsuranceScore, UserData),
                new HasMortgagedHouseRule(InsuranceScore, UserData)
            };
        }

        public HomeInsurance(UserData userData) : base(userData) { }
    }
}
