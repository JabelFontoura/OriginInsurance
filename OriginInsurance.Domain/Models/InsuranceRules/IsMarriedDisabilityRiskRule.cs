using OriginInsurance.Domain.Constants;

namespace OriginInsurance.Domain.Models.InsuranceRules
{
    public class IsMarriedDisabilityRiskRule : InsuranceRule
    {
        public IsMarriedDisabilityRiskRule(InsuranceScore insuranceScore, UserData userData) : base(insuranceScore, userData) { }

        public override void CalculateRisk()
        {
            if (UserData.MartialStatus == MaritalStatus.Married)
                InsuranceScore.Deduct(1);
        }
    }
}