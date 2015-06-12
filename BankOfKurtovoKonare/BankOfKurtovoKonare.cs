using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankOfKurtovoKonare.Accounts;
using BankOfKurtovoKonare.Interfaces;
using BankOfKurtovoKonare.Customers;
using System.Threading;
using System.Globalization;

namespace BankOfKurtovoKonare
{
    class BankOfKurtovoKonare
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            IAccount[] accounts =
            {
                new DepositAccount(new Customer("Ivan Petrov",CustomerType.Individual), 525M,0.0005M),
                new DepositAccount(new Customer("Georgi Georgiev",CustomerType.Individual), 1525M,0.001M),
                new DepositAccount(new Customer("Kriza OOD",CustomerType.Companie), 5525M,0.05M),
                new LoanAccount(new Customer("Petar Ivanov",CustomerType.Individual), -1250M, 0.003M),
                new LoanAccount(new Customer("Firma EOOD",CustomerType.Companie), -21250M, 0.005M),
                new MortgageAccount(new Customer("Ginka Ginkova",CustomerType.Individual), 50000,0.0055M),
                new MortgageAccount(new Customer("Krajbi i razprodajbi OOD", CustomerType.Companie), 1000000,0.007M)
            };
            foreach (IAccount account in accounts)
            {
                Console.WriteLine("2 mounth interest on a {0} \n\r(balance: {1:C2}, rate {2:F3}%): {3:C2}\n\r", account.GetType().Name, account.Balance,account.InterestRate*100,account.CalculatereInterestRate(2));
            }
            foreach (IAccount account in accounts)
            {
                Console.WriteLine("6 mounth interest on a {0} \n\r(balance: {1:C2}, rate {2:F3}%): {3:C2}\n\r", account.GetType().Name, account.Balance, account.InterestRate * 100, account.CalculatereInterestRate(6));
            }
            foreach (IAccount account in accounts)
            {
                Console.WriteLine("12 mounth interest on a {0} \n\r(balance: {1:C2}, rate {2:F3}%): {3:C2}\n\r", account.GetType().Name, account.Balance, account.InterestRate * 100, account.CalculatereInterestRate(12));
            }
        }
    }
}
