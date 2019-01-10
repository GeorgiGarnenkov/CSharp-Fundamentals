using System;
using System.Collections.Generic;
using System.Dynamic;

class TestClient
{
    static void Main()
    {
        var accounts = new Dictionary<int, BankAccount>();
        string input;

        while ((input = Console.ReadLine()) != "End")
        {
            var commandArgs = input.Split();
            var command = commandArgs[0];

            switch (command)
            {
                case "Create":
                    Create(commandArgs, accounts);
                    break;
                case "Deposit":
                    Deposit(commandArgs, accounts);
                    break;
                case "Withdraw":
                    Withdraw(commandArgs, accounts);
                    break;
                case "Print":
                    Print(commandArgs, accounts);
                    break;
            }
        }
    }

    private static void Print(string[] commandArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(commandArgs[1]);
        if (accounts.ContainsKey(id))
        {
            Console.WriteLine($"Account ID{id}, balance {accounts[id].Balance:f2}");
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static void Withdraw(string[] commandArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(commandArgs[1]);
        var amount = decimal.Parse(commandArgs[2]);

        if (accounts.ContainsKey(id))
        {
            if (accounts[id].Balance - amount >= 0)
            {
                accounts[id].Balance -= amount;
            }
            else
            {
                Console.WriteLine("Insufficient balance");
            }
            
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static void Deposit(string[] commandArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(commandArgs[1]);
        var amount = decimal.Parse(commandArgs[2]);

        if (accounts.ContainsKey(id))
        {
            accounts[id].Balance += amount;
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static void Create(string[] commandArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(commandArgs[1]);
        if (accounts.ContainsKey(id))
        {
            Console.WriteLine("Account already exists");
        }
        else
        {
            var acc = new BankAccount();
            acc.Id = id;
            accounts.Add(id, acc);
        }
    }
}
