namespace OriginInsurance.Domain.Models.InsuranceRules
{
    public class DoesNotHaveHouseRule : InsuranceRule
    {
        public DoesNotHaveHouseRule(InsuranceScore insuranceScore, UserData userData) : base(insuranceScore, userData) { }

        public override void CalculateRisk()
        {
            if (UserData.House == null)
                InsuranceScore.SetIneligible();
        }
    }
}
