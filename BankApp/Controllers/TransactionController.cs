using BankApp.Models.Bank;
using BankApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Controllers
{
    public class TransactionController : Controller
    {
        private readonly DataContext _context;
        private readonly ITransactionServices _transactionServices;

        //On connecte la BD
        public TransactionController(DataContext context, ITransactionServices transactionServices)
        {
            _context = context;
            _transactionServices = transactionServices;
        }

        // GET: TransactionController
        public ActionResult Index()
        {
            var transactions = _transactionServices.TransactionsList(true);
            return View(transactions);
        }

        // GET: TransactionController/Details/5
        public ActionResult Details(int id)
        {
            var transaction = _transactionServices.GetTransaction(id);
            return View(transaction);
        }

        // GET: TransactionController/Create
        public ActionResult Create()
        {
            IEnumerable<SelectListItem> items = _context.Accounts.Where(acc => acc.AccountState).Select(acc => new SelectListItem
            {
                Value = acc.AccountID .ToString(),
                Text = acc.AccountNumber 
            });
            ViewBag.AccountName = items;
            return View();
        }

        // POST: TransactionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Transaction transaction)
        {
            try
            {
                _transactionServices.CreateTransaction(transaction);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionController/Edit/5
        public ActionResult Edit(int id)
        {
            IEnumerable<SelectListItem> items = _context.Accounts.Where(t => t.AccountState).Select(t => new SelectListItem
            {
                Value = t.AccountID.ToString(),
                Text = t.AccountNumber
            });
            ViewBag.AccountName = items;

            var transaction = _transactionServices.GetTransaction(id);
            return View(transaction);
        }

        // POST: TransactionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Transaction transaction)
        {
            try
            {
                //transaction = _context.Transactions.Where(t => t.TransactionID == id);
                transaction = _transactionServices.GetTransaction(id);
                _context.Transactions.Update(transaction);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionController/Delete/5
        public ActionResult Delete(int id)
        {
            var transaction = _transactionServices.GetTransaction(id);
            return View(transaction);
        }

        // POST: TransactionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Transaction transaction)
        {
            try
            {
                _transactionServices.DeleteTransaction(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
