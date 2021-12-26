using BankApp.Models.Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Services
{
    public class TransactionServices : ITransactionServices
    {
        private readonly DataContext _context;

        public TransactionServices(DataContext context)
        {
            _context = context;
        }

        public List<Transaction> TransactionsList()
        {
            return _context.Transactions.ToList();
        }

        public List<Transaction> TransactionsList(bool state)
        {
            return _context.Transactions.Where(t => t.TransactionState).ToList();
        }

        public Transaction GetTransaction(int id)
        {
            return _context.Transactions.Where(t => t.TransactionID == id).FirstOrDefault();
        }

        public Transaction CreateTransaction(Transaction transaction)
        {           
            transaction.TransactionCreationDate = DateTime.Now;
            transaction.TransactionUpdatedDate = DateTime.Now;
            transaction.TransactionState = true;
            _context.Transactions.Add(transaction);
            _context.SaveChanges();

            return transaction;
        }

        public void DeleteTransaction(int id)
        {
            var transaction = GetTransaction(id);
            transaction.TransactionDeletedDate = DateTime.Now;
            transaction.TransactionState = false;

            _context.Update(transaction);
            _context.SaveChanges();
        }
    }
}
