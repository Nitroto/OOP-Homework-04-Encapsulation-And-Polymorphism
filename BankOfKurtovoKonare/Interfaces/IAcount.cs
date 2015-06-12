namespace BankOfKurtovoKonare.Interfaces
{
    public interface IAccount
    {
        ICustomer Customer { get; }
        decimal InterestRate { get; }
        decimal Balance { get; }

        decimal CalculatereInterestRate(int period);
    }
}
