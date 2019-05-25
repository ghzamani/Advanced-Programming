namespace A11
{
    public class SavingsAccount : Account
    {
        public double InterestRate;

        public SavingsAccount(double balance, double interestRate) : base(balance)
        {
            this.InterestRate = interestRate;
        }

        public override void Credit(double amount)
        {
            base.Credit(amount);
        }

        public override bool Debit(double amount) => base.Debit(amount);

        public double CalculateInterest()
        {
            return Balance * InterestRate;
        }


    }
}
