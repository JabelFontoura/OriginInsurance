namespace OriginInsurance.Domain.Models
{
    public class InsuranceScore
    {
        public int? Score { get; private set; }
        public bool IsEligible { get => Score.HasValue; }

        public InsuranceScore(int score)
        {
            Score = score;
        }

        public void Add(int score)
        {
            if (Score == null)
                    return;

            Score += score;
        }

        public void Deduct(int score)
        {
            if (Score == null)
                return;

            Score -= score;
        }

        public void SetIneligible()
        {
            Score = null;
        }
    }
}
