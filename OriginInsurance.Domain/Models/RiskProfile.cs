namespace OriginInsurance.Domain.Models
{
    public class RiskProfile
    {
        public string Disability { get; private set; }
        public string Life { get; private set; }
        public string Auto { get; private set; }
        public string Home { get; private set; }

        public RiskProfile(string disability, string life, string auto, string home)
        {
            Disability = disability;
            Life = life;
            Auto = auto;
            Home = home;
        }
    }
}