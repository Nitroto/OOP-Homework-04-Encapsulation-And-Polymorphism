using System;
using BankOfKurtovoKonare.Interfaces;

namespace BankOfKurtovoKonare.Customers
{
    class Customer:ICustomer
    {
        public string name;
        public Customer(string name, CustomerType type)
        {
            this.Name = name;
            this.CustomerType = type;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("name", "Name of customer cannot be empty!");
                }
                this.name = value;
            }
        }
        public CustomerType CustomerType { get; set; }
    }
}
