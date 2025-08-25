using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MVC_Assignment1.Models;
using System.Linq;
using System.Web;

namespace MVC_Assignment1.Repositories
{
    public interface IContactRepo
    {
        Task<List<Contact>> GetAllAsync();
        Task CreateAsync(Contact contact);
        Task DeleteAsync(long id);
    }

}