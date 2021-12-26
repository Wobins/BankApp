using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Models.Bank
{
    //On cree la classe client
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLaststName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public DateTime CustomerCreationDate { get; set; }
        public DateTime CustomerUpdatedDate { get; set; }
        public DateTime CustomerDeletedDate { get; set; }
        public bool CustomerState { get; set; } //ici cet attribut correspond a si oui ou non le                                            client est encore actif dans la banque(supprime)        
    }
}
