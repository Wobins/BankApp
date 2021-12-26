using BankApp.Models.Bank;
using BankApp.Services;
using BankApp.ViewsModels.Accounts;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly DataContext _context;
        

        public AccountServices(DataContext context)
        {
            _context = context;
            
        }

        public List<Account> AccountsList()
        {
            return _context.Accounts.ToList();
        }

        public List<Account> AccountsList(bool AccountState)
        {
            return _context.Accounts.Where(acc => acc.AccountState).ToList();
        }

        public Account GetAccount(int id)
        {
            return _context.Accounts.Where(acc => acc.AccountID == id).FirstOrDefault();
        }

        public Account AccountCreate (Account account)
        {
            account.AccountCreationDate = DateTime.Now;
            account.AccountUpdatedDate = DateTime.Now;
            account.AccountState = true;
            _context.Accounts.Add(account);
            _context.SaveChanges();

            return account;
        }

        public void AccountDelete (int id)
        {
            var account = GetAccount(id);
            account.AccountDeletedDate = DateTime.Now;
            account.AccountState = false;

            _context.Update(account);
            _context.SaveChanges();
        }

        public Account AccountEdit(int id, AccountEdit_VM accountEdit_VM)
        {
            //on recupere le compte a modifier a modifier
            var account = GetAccount(id);

            //On recupere les modifications effectuees
            account.AccountNumber = accountEdit_VM.AccountNumber;
            account.AccountBalance = accountEdit_VM.AccountBalance;
            account.AccountUpdatedDate = DateTime.Now;

            _context.Update(account);
            _context.SaveChanges();

            return account;
        }
    }
}
