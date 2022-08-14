namespace OriginInsurance.Domain.Models.InsuranceRules
{
    public class HasAgeBetween30And40Rule : InsuranceRule
    {
        public HasAgeBetween30And40Rule(InsuranceScore insuranceScore, UserData userData) : base(insuranceScore, userData) { }

        public override void CalculateRisk()
        {
            if (UserData.Age >= 30 && UserData.Age <= 40)
                InsuranceScore.Deduct(1);
        }
    }
}
