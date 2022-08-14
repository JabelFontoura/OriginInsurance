namespace OriginInsurance.Domain.Models.InsuranceRules
{
    public class VehicleWasProducedInLast5Years : InsuranceRule
    {
        public VehicleWasProducedInLast5Years(InsuranceScore insuranceScore, UserData userData) : base(insuranceScore, userData) { }

        public override void CalculateRisk()
        {
            if ((DateTime.Now.Year - UserData.Vehicle?.Year) <= 5)
                InsuranceScore.Add(1);
        }
    }
}
