using BankApp.Models.Bank;
using BankApp.Services;
using BankApp.ViewsModels.Customers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly DataContext _context;
        private readonly ICustomerServices _customerServices;

        //On connecte la BD
        public CustomerController(DataContext context, ICustomerServices customerServices)
        {
            _context = context;
            _customerServices = customerServices;
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            var customers = _customerServices.CustomersList(true);
            return View(customers);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            var customer = _customerServices.GetCustomer(id);
            return View(customer);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {    
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Customer customer)
        {
            try
            {
                _customerServices.CustomerCreate(customer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = _customerServices.GetCustomer(id);
            return View(customer);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerEdit_VM customer)
        {
            try
            {
                _customerServices.CustomerEdit(id, customer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = _customerServices.GetCustomer(id);
            return View(customer);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                _customerServices.CustomerDelete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
