namespace OriginInsurance.Domain.Models.InsuranceRules
{
    public class DoesNotHaveVehicleRule : InsuranceRule
    {
        public DoesNotHaveVehicleRule(InsuranceScore insuranceScore, UserData userData) : base(insuranceScore, userData) { }

        public override void CalculateRisk()
        {
            if (UserData.Vehicle == null)
                InsuranceScore.SetIneligible();
        }
    }
}
