namespace OriginInsurance.Domain.Models.InsuranceRules
{
    public class HasAgeUnder30Rule : InsuranceRule
    {
        public HasAgeUnder30Rule(InsuranceScore insuranceScore, UserData userData) : base(insuranceScore, userData) { }

        public override void CalculateRisk()
        {
            if (UserData.Age < 30)
                InsuranceScore.Deduct(2);
        }
    }
}
