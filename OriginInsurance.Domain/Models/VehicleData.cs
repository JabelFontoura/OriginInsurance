namespace OriginInsurance.Domain.Models
{
    public class VehicleData
    {
        public int Year { get; private set; }

        public VehicleData() { }

        public VehicleData(int year)
        {
            Year = year;
        }
    }
}