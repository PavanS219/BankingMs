public class Account
{
    public int AccountNumber { get; private set; }
    public string Owner { get; private set; }
    public decimal Balance { get; private set; }

    public Account(int accountNumber, string owner)
    {
        AccountNumber = accountNumber;
        Owner = owner;
        Balance = 0;
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
            return true;
        }
        return false;
    }
}