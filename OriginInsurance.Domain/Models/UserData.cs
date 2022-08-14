namespace OriginInsurance.Domain.Models
{
    public class UserData
    {
        public decimal Income { get; private set; }
        public int Age { get; private set; }
        public int Dependents { get; private set; }
        public string MartialStatus { get; private set; }
        public HouseData House { get; private set; }
        public VehicleData Vehicle { get; private set; }
        public IList<int> RiskQuestions { get; private set; }
        public int BaseScore { get => RiskQuestions.Sum(); }

        public UserData() { }
        
        public UserData(decimal income, int age, int dependents, string maritalStatus, HouseData house, VehicleData vehicle, IList<int> riskQuestions)
        {
            Income = income;
            Age = age;
            Dependents = dependents;
            MartialStatus = maritalStatus;
            House = house;
            Vehicle = vehicle;
            RiskQuestions = riskQuestions;
        }
    }
}