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

            account.MakeWithdrawal(50, DateTime.Now, "Xbox 360");

            Console.WriteLine(account.GetAccountHistory());

            // Teste para conta inválida
            try
            {
                var invalidAccount = new BankAccount("invalid", -55);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exceção devido a tentativa de criação de conta com saldo negativo");
                Console.WriteLine(e.ToString());
            }


            // Teste para saldo negativo
            try
            {
                account.MakeWithdrawal(75000, DateTime.Now, "Tentativa de saque");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exceção devido a tentativa de saque de valores indisponíveis");
                Console.WriteLine(e.ToString());
            }

        }
    }
}
