namespace A11
{
    public class CheckingAccount : Account
    {
        public double TransactionFee;

        public CheckingAccount(double balance,double transactionFee) 
            : base(balance)
        {
            this.TransactionFee = transactionFee;
        }
        
        public override void Credit(double amount)
        {
            if (amount >= 0)
                this.Balance = Balance + amount - TransactionFee;
            else
                base.Credit(amount);
        }

        public override bool Debit(double amount)
        {
            if (amount <= this.Balance)
            {
                this.Balance = Balance - amount - TransactionFee;
                return true;
            }
            else
                return base.Debit(amount);
        }
    }
}
