using BankOfKurtovoKonare.Customers;

namespace BankOfKurtovoKonare.Interfaces
{
    public interface ICustomer
    {
        string Name { get; }
        CustomerType CustomerType { get; }
    }
}
