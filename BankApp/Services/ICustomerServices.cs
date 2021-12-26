using BankApp.Models.Bank;
using BankApp.ViewsModels.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Services
{
    public interface ICustomerServices
    {
        public List<Customer> CustomersList();

        public List<Customer> CustomersList(bool state);

        public Customer GetCustomer(int id);

        public Customer CustomerCreate(Customer customer);

        public void CustomerDelete(int id);

        public Customer CustomerEdit( int id, CustomerEdit_VM customerEdit_VM );
    }
}
