using System.Text.Json.Serialization;

namespace OriginInsurance.Application.Dtos
{
    public class HouseDataDto
    {
        [JsonPropertyName("ownership_status")]
        public string OwnershipStatus { get; set; }
    }
}