using System;

namespace _01_MyBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Joseph", 1000);
            Console.WriteLine($"A conta {account.Number} foi criada para {account.Owner} com saldo de R$ {account.Balance}");


            account.MakeWithdrawal(190, DateTime.Now, "Cobertor");
            Console.WriteLine(account.Balance);
        }
    }
}
