using OriginInsurance.Domain.Constants;
using OriginInsurance.Domain.Models.InsuranceRules;

namespace OriginInsurance.Domain.Models.InsuranceTypes
{
    public abstract class BaseInsurance
    {
        public InsuranceScore InsuranceScore { get; protected set; }
        public UserData UserData { get; protected set; }
        public abstract HashSet<InsuranceRule> Rules { get; }

        protected BaseInsurance(UserData userData)
        {
            UserData = userData;
            InsuranceScore = new InsuranceScore(UserData.BaseScore);
            Execute();
        }

        public void Execute()
        {
            foreach (var rule in Rules)
                rule.CalculateRisk();
        }

        public string MapScore()
        {
            if (!InsuranceScore.IsEligible)
                return InsuranceEligibility.Ineligible;
            else if (InsuranceScore.Score <= 0)
                return InsuranceEligibility.Economic;
            else if (InsuranceScore.Score <= 2)
                return InsuranceEligibility.Regular;
            else
                return InsuranceEligibility.Responsible;
        }
    }
}