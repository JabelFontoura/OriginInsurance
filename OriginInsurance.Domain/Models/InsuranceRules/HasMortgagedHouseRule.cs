using OriginInsurance.Domain.Constants;

namespace OriginInsurance.Domain.Models.InsuranceRules
{
    public class HasMortgagedHouseRule : InsuranceRule
    {
        public HasMortgagedHouseRule(InsuranceScore insuranceScore, UserData userData) : base(insuranceScore, userData) { }

        public override void CalculateRisk()
        {
            if (UserData.House?.OwnershipStatus == OwnershipStatus.Mortgaged)
                InsuranceScore.Add(1);
        }
    }
}
