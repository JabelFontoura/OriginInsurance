using OriginInsurance.Domain.Constants;

namespace OriginInsurance.Domain.Models.InsuranceRules
{
    public class IsMarriedLifeRiskRule : InsuranceRule
    {
        public IsMarriedLifeRiskRule(InsuranceScore insuranceScore, UserData userData) : base(insuranceScore, userData) { }

        public override void CalculateRisk()
        {
            if (UserData.MartialStatus == MaritalStatus.Married)
                InsuranceScore.Add(1);
        }
    }
}
