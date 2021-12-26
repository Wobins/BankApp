using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Models.Bank
{
    public class DataContext : DbContext
    {
        //On configure notre base de donnees
        //La classe Iconfiguration permet de maipuler le fichier de configuration appsettings.json
        protected readonly IConfiguration _Configuration;
        public DataContext(IConfiguration Configuration)
        {
            _Configuration = Configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseMySql( _Configuration.GetConnectionString("dataAccess") );
        }

        //Ici on referencie les classes qui seront nos tables, car toutes les classes ne le sont pas forcement
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
