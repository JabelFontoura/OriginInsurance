namespace OriginInsurance.Domain.Models
{
    public class HouseData
    {
        public string OwnershipStatus { get; set; }

        public HouseData() { }

        public HouseData(string ownershipStatus)
        {
            OwnershipStatus = ownershipStatus;
        }
    }
}