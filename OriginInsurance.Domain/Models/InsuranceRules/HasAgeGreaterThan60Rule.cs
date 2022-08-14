namespace OriginInsurance.Domain.Models.InsuranceRules
{
    public class HasAgeGreaterThan60Rule : InsuranceRule
    {
        public HasAgeGreaterThan60Rule(InsuranceScore insuranceScore, UserData userData) : base(insuranceScore, userData) { }

        public override void CalculateRisk()
        {
            if (UserData.Age > 60)
                InsuranceScore.SetIneligible();
        }
    }
}
