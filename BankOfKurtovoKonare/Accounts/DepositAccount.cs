using BankOfKurtovoKonare.Interfaces;

namespace BankOfKurtovoKonare.Accounts
{
    class DepositAccount : Account
    {
        public DepositAccount(ICustomer customer, decimal balance, decimal initialInterestRate)
        : base(customer, balance, initialInterestRate)
        {
        }

        public override decimal CalculatereInterestRate(int periodInMonths)
        {
            decimal rate;
            if (this.Balance > 0M && this.Balance < 1000)
            {
                rate = 0;
            }
            else
            {
                rate = base.CalculatereInterestRate(periodInMonths);
            }
            return rate;
        }
    }
}
