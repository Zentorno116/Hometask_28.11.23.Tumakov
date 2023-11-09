using System;
using System.Collections.Generic;

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

    public BankTransaction()
    {
        Amount = 0m;
        TransactionDate = DateTime.Now;
    }
}

public class Account
{
    private string _accountNumber;
    private decimal _balance;
    private AccountType _accountType;
    private Queue<BankTransaction> _transactions;

    public Account()
    {
        GenerateAccountNumber();
        _transactions = new Queue<BankTransaction>();
    }

    public Account(decimal balance) : this()
    {
        _balance = balance;
    }

    public Account(AccountType accountType) : this()
    {
        _accountType = accountType;
    }

    public Account(decimal balance, AccountType accountType) : this(accountType)
    {
        _balance = balance;
    }

    private void GenerateAccountNumber()
    {
        _accountNumber = Guid.NewGuid().ToString("N").Substring(0, 12);
    }

    public string AccountNumber
    {
        get { return _accountNumber; }
    }

    public decimal Balance
    {
        get { return _balance; }
        set
        {
            _balance = value;
            _transactions.Enqueue(new BankTransaction(value));
        }
    }

    public AccountType Type
    {
        get { return _accountType; }
        set { _accountType = value; }
    }

    public void Deposit(decimal amount)
    {
        _balance += amount;
        _transactions.Enqueue(new BankTransaction(amount));
    }

    public void Withdraw(decimal amount)
    {
        _balance -= amount;
        _transactions.Enqueue(new BankTransaction(-amount));
    }

    public IEnumerable<BankTransaction> Transactions
    {
        get { return _transactions; }
    }

    public void Dispose()
    {
        string fileName = $"{_accountNumber}.transactions";
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (BankTransaction transaction in _transactions)
            {
                writer.WriteLine($"{transaction.TransactionDate} {transaction.Amount}");
            }
        }

        GC.SuppressFinalize(this);
    }
}

class Program
{
    static void Main()
    {
        Account account = new Account(11112023m, AccountType.Savings);

        account.Deposit(228m);

        account.Withdraw(123m);

        Console.WriteLine($"Номер счета: {account.AccountNumber}");
        Console.WriteLine($"Баланс: {account.Balance}");
        Console.WriteLine($"Тип счета: {account.Type}");

        foreach (BankTransaction transaction in account.Transactions)
        {
            Console.WriteLine($"Дата: {transaction.TransactionDate}, сумма: {transaction.Amount}");
        }

        account.Dispose();
    }
}