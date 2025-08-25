using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Assignment1.Models
{
    public class ContactHandler : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public ContactHandler() : base("DefaultConnection") { }
    }
}