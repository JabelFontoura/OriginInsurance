using OriginInsurance.Domain.Models.InsuranceRules;

namespace OriginInsurance.Domain.Models.InsuranceRules
{
    public class HasDependentsRule : InsuranceRule
    {
        public HasDependentsRule(InsuranceScore insuranceScore, UserData userData) : base(insuranceScore, userData) { }

        public override void CalculateRisk()
        {
            if (UserData.Dependents > 0)
                InsuranceScore.Add(1);
        }
    }
}
