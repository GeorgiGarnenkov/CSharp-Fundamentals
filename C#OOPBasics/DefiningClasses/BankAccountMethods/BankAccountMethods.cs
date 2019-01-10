using System;

class BankAccountMethods
{
    static void Main()
    {
        BankAccount acc = new BankAccount();

        acc.Id = 1;
        acc.Deposit(1500);
        acc.Withdraw(1000);

        Console.WriteLine(acc);
    }
}
