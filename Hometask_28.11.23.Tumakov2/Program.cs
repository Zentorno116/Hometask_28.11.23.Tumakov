using System;
using System.Collections;

public enum AccountType
{
    Checking,
    Savings,
    Deposit
}

public class BankTransaction
{
    public readonly decimal Amount;
    public readonly DateTime TransactionDate;

    public BankTransaction(decimal amount)
    {
        Amount = amount;
        TransactionDate = DateTime.Now;
    }
}

public class BankAccount
{
    private string accountNumber;
    private decimal balance;
    private AccountType accountType;
    private Queue transactions;

    public BankAccount()
    {
        GenerateAccountNumber();
        transactions = new Queue();
    }

    public BankAccount(decimal balance) : this()
    {
        Deposit(balance);
    }

    public BankAccount(AccountType accountType) : this()
    {
        this.accountType = accountType;
    }

    public BankAccount(decimal balance, AccountType accountType) : this(accountType)
    {
        Deposit(balance);
    }

    private void GenerateAccountNumber()
    {
        this.accountNumber = Guid.NewGuid().ToString("N").Substring(0, 12);
    }

    public string AccountNumber
    {
        get { return accountNumber; }
    }

    public decimal Balance
    {
        get { return balance; }
    }

    public AccountType Type
    {
        get { return accountType; }
        set { accountType = value; }
    }

    public void Deposit(decimal amount)
    {
        balance += amount;
        transactions.Enqueue(new BankTransaction(amount));
    }

    public void Withdraw(decimal amount)
    {
        balance -= amount;
        transactions.Enqueue(new BankTransaction(-amount));
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Упражнение 9.2. Банк с BankTransaction. ");
        BankAccount account = new BankAccount(10112023m, AccountType.Savings);

        Console.WriteLine($"Номер счета: {account.AccountNumber}");
        Console.WriteLine($"Баланс: {account.Balance}");
        Console.WriteLine($"Тип счета: {account.Type}");
    }
}