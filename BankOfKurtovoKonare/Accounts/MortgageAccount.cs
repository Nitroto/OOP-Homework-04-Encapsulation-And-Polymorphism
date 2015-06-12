using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankOfKurtovoKonare.Interfaces;
using BankOfKurtovoKonare.Customers;

namespace BankOfKurtovoKonare.Accounts
{
    class MortgageAccount : Account
    {
        public MortgageAccount(ICustomer customer, decimal balance, decimal initialInterestRate)
        : base(customer, balance, initialInterestRate)
        {
        }

        public override decimal CalculatereInterestRate(int periodInMonths)
        {
            decimal rate = 0;
            if (this.Customer.CustomerType == CustomerType.Companie)
            {
                int halfInterestMounths = 12;
                int fullInterestMounths = Math.Max(0, periodInMonths - halfInterestMounths);
                rate = (this.Balance * (1 + (this.InterestRate / 2 * halfInterestMounths))) + base.CalculatereInterestRate(fullInterestMounths);
            }
            else
            {
                int noInterestMounths = 6;
                int fullInterestMounths = Math.Max(0, periodInMonths - noInterestMounths);
                rate = base.CalculatereInterestRate(fullInterestMounths);
            }
            int mountsWithInterest = Math.Max(0, (this.Customer.CustomerType == CustomerType.Individual ? 3 : 2));
            return base.CalculatereInterestRate(mountsWithInterest);
        }
    }
}
