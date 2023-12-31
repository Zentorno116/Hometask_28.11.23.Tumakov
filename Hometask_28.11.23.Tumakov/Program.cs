﻿using System;

public enum AccountType
{
    Checking,
    Savings,
    Deposit
}

public class BankAccount
{
    private string accountNumber;
    private decimal balance;
    private AccountType accountType;

    public BankAccount()
    {
        GenerateAccountNumber();
    }

    public BankAccount(decimal balance)
    {
        GenerateAccountNumber();
        this.balance = balance;
    }

    public BankAccount(AccountType accountType)
    {
        GenerateAccountNumber();
        this.accountType = accountType;
    }

    public BankAccount(decimal balance, AccountType accountType)
    {
        GenerateAccountNumber();
        this.balance = balance;
        this.accountType = accountType;
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
        set { balance = value; }
    }

    public AccountType Type
    {
        get { return accountType; }
        set { accountType = value; }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Упражнение 9.1. Банк с конструктором.");
        BankAccount account = new BankAccount(9112023m, AccountType.Savings);

        Console.WriteLine($"Номер счета: {account.AccountNumber}");
        Console.WriteLine($"Баланс: {account.Balance}");
        Console.WriteLine($"Тип счета: {account.Type}");
    }
}