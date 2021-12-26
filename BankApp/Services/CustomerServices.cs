using BankApp.Models.Bank;
using BankApp.ViewsModels.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly DataContext _context;

        public CustomerServices(DataContext context)
        {
            _context = context;
            
        }

        public Customer CustomerCreate(Customer customer)
        {
            customer.CustomerCreationDate = DateTime.Now;
            customer.CustomerUpdatedDate = customer.CustomerCreationDate;
            customer.CustomerState = true;
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public Customer GetCustomer(int id)
        {
            return _context.Customers.Where(c => c.CustomerID == id).FirstOrDefault();
        }

        public void CustomerDelete(int id )
        {           
            var customer = GetCustomer(id);
            customer.CustomerState = false;
            customer.CustomerDeletedDate = DateTime.Now;
            _context.Customers.Update(customer);

            Account account = _context.Accounts.Where(acc => acc.CustomerID  == id).FirstOrDefault();
            account.AccountState = false;
            _context.Accounts.Update(account);
                       
            _context.SaveChanges();
            customer.CustomerDeletedDate = DateTime.Now;
        }

        public List<Customer> CustomersList()
        {
            return _context.Customers.ToList();
        }

        public List<Customer> CustomersList(bool state)
        {
            return _context.Customers.Where(c => c.CustomerState == state).ToList();
        }

        public Customer CustomerEdit( int id, CustomerEdit_VM customerEdit_VM )
        {
            //on recupere le customer a modifier
            var customer = GetCustomer(id);

            //On recupere les modifications effectuees
            customer.CustomerFirstName = customerEdit_VM.CustomerFirstName;
            customer.CustomerLaststName = customerEdit_VM.CustomerLaststName;
            customer.CustomerEmail = customerEdit_VM.CustomerEmail;
            customer.CustomerPhoneNumber = customerEdit_VM.CustomerPhoneNumber;
            customer.CustomerUpdatedDate = DateTime.Now;

            _context.Update(customer);
            _context.SaveChanges();

            return customer;            
        }
    }
}
