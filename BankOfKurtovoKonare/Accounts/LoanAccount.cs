using System;
using BankOfKurtovoKonare.Interfaces;
using BankOfKurtovoKonare.Customers;

namespace BankOfKurtovoKonare.Accounts
{
    class LoanAccount : Account
    {
        public LoanAccount(ICustomer customer, decimal balance, decimal initialInterestRate)
        : base(customer, balance, initialInterestRate)
        {
        }

        public override decimal CalculatereInterestRate(int periodInMonths)
        {
            int mountsWithInterest = Math.Max(0, (this.Customer.CustomerType == CustomerType.Individual ? 3 : 2));
            return base.CalculatereInterestRate(mountsWithInterest);
        }
    }
}

