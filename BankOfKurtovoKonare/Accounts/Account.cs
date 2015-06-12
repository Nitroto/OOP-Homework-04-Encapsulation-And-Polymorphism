using System;
using BankOfKurtovoKonare.Interfaces;

namespace BankOfKurtovoKonare.Accounts
{
    public abstract class Account : IAccount
    {
        private ICustomer customer;
        private decimal interestRate;

        public Account(ICustomer customer, decimal balance, decimal initialInterestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = initialInterestRate;
        }

        public ICustomer Customer
        {
            get
            {
                return this.customer;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("customer", "Customer cannot be empty!");
                }
                this.customer = value;
            }
        }
        public decimal InterestRate
        {
            get
            {
                return this.interestRate;
            }
            set
            {
                if (value < 0M)
                {
                    throw new ArgumentOutOfRangeException("interestRate", "Interest rate cannot be negative!");
                }
                this.interestRate = value;
            }
        }
        public decimal Balance { get; protected set; }

        public virtual decimal CalculatereInterestRate(int periodInMonths)
        {
            decimal rate = this.Balance * (1 + this.InterestRate * periodInMonths);
            return rate;
        }
    }
}
