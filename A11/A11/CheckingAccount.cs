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
            base.Credit(amount);
            this.Balance -= TransactionFee;
        }

        public override bool Debit(double amount)
        {            
            bool baseDebit = base.Debit(amount);

            if (!baseDebit)
                return baseDebit;

            this.Balance -= TransactionFee;
            return baseDebit;
        }
    }
}
