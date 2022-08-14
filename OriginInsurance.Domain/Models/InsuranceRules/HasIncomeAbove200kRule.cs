namespace OriginInsurance.Domain.Models.InsuranceRules
{
    public class HasIncomeAbove200kRule : InsuranceRule
    {
        public HasIncomeAbove200kRule(InsuranceScore insuranceScore, UserData userData) : base(insuranceScore, userData) { }

        public override void CalculateRisk()
        {
            if (UserData.Income > 200000)
                InsuranceScore.Deduct(1);
        }
    }
}
