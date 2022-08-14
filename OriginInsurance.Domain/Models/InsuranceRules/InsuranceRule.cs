namespace OriginInsurance.Domain.Models.InsuranceRules
{
    public abstract class InsuranceRule
    {
        public InsuranceScore InsuranceScore { get; protected set; }
        public UserData UserData { get; protected set; }

        public InsuranceRule(InsuranceScore insuranceScore, UserData userData)
        {
            InsuranceScore = insuranceScore;
            UserData = userData;
        }

        public abstract void CalculateRisk();
    }
}
