using System.Text.Json.Serialization;

namespace OriginInsurance.Application.Dtos
{
    public class UserDataDto
    {
        public decimal Income { get; set; }
        public int Age { get; set; }
        public int Dependents { get; set; }
        public HouseDataDto? House { get; set; }
        public VehicleDataDto? Vehicle { get; set; }
        

        [JsonPropertyName("marital_status")]
        public string MaritalStatus { get; set; }

        [JsonPropertyName("risk_questions")]
        public IList<int> RiskQuestions { get; set; }
    }
}
