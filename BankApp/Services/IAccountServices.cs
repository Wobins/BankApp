using BankApp.Models.Bank;
using BankApp.ViewsModels.Accounts;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Services
{
    public interface IAccountServices
    {
        public List<Account> AccountsList();

        public List<Account> AccountsList(bool state);

        public Account GetAccount(int id);

        public Account AccountCreate(Account account);

        public void AccountDelete(int id);

        public Account AccountEdit(int id, AccountEdit_VM accountEdit_VM);
    }
}
