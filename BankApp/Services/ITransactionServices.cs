using BankApp.Models.Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Services
{
    public interface ITransactionServices
    {
        public List<Transaction> TransactionsList();

        public List<Transaction> TransactionsList(bool state);

        public Transaction GetTransaction(int id);

        public Transaction CreateTransaction(Transaction transaction);

        public void DeleteTransaction(int id);
    }
}
