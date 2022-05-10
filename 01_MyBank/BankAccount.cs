using System;
using System.Collections.Generic;
using System.Text;

namespace _01_MyBank
{
    public class BankAccount
    {
        public string Number { get;}
        public string Owner { get; set;}
        public decimal Balance 
        { 
            get 
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance = balance + item.Amount;
                }
                return balance;
            } 
        }

        private static int accountNumberSeed = 123456789;

        private List<Transaction> allTransactions = new List<Transaction>();

        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "O depósito deve ser possuir valor positivo");
            }
            
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);

        }
           
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "O saque deve ser possuir valor positivo");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Não há fundos suficientes para este saque.");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }
    }
}


