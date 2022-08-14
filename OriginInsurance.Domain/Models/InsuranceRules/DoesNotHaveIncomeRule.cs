namespace OriginInsurance.Domain.Models.InsuranceRules
{
    public class DoesNotHaveIncomeRule : InsuranceRule
    {
        public DoesNotHaveIncomeRule(InsuranceScore insuranceScore, UserData userData) : base(insuranceScore, userData) { }

        public override void CalculateRisk()
        {
            if (UserData.Income == 0)
                InsuranceScore.SetIneligible();
        }
    }
}
