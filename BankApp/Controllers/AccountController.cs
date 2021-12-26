using BankApp.Models.Bank;
using BankApp.Services;
using BankApp.ViewsModels.Accounts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataContext _context;
        private readonly IAccountServices _accountServices;

        //On connecte la BD
        public AccountController(DataContext context, IAccountServices accountServices)
        {
            _context = context;
            _accountServices = accountServices;
        }

        // GET: AccountController
        public ActionResult Index()
        {
            var accounts = _accountServices.AccountsList(true);
            return View(accounts);
        }

        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            var account = _accountServices.GetAccount(id);
            return View(account);
        }

        // GET: AccountController/Create
        public ActionResult Create()
        {
            IEnumerable<SelectListItem> items = _context.Customers.Where(c => c.CustomerState).Select(c => new SelectListItem
            {
                Value = c.CustomerID.ToString(),
                Text = c.CustomerFirstName + " " + c.CustomerLaststName
            });
            ViewBag.CustomerName = items;
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Account account)
        {
            try
            {
                _accountServices.AccountCreate(account);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            IEnumerable<SelectListItem> items = _context.Customers.Where(c => c.CustomerState).Select(c => new SelectListItem
            {
                Value = c.CustomerID.ToString(),
                Text = c.CustomerFirstName + " " + c.CustomerLaststName
            });
            ViewBag.CustomerName = items;

            var account = _accountServices.GetAccount(id);
            return View(account);
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AccountEdit_VM account)
        {
            try
            {
                _accountServices.AccountEdit(id, account);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            var account = _accountServices.GetAccount(id);
            return View(account);
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Account account)
        {
            try
            {
                _accountServices.AccountDelete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
