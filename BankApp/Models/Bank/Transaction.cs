using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Models.Bank
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int TransactionAmount { get; set; }
        public DateTime TransactionCreationDate { get; set; }
        public DateTime TransactionUpdatedDate { get; set; }
        public DateTime TransactionDeletedDate { get; set; }
        public bool TransactionState { get; set; }
        public int AccountID { get; set; }
        public Account AccountTransaction { get; set; }
    }
}
