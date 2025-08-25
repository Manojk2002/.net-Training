using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using MVC_Assignment1.Models;

namespace MVC_Assignment1.Repositories
{
    public class ContactRepository : IContactRepo
    {
        private readonly ContactHandler _context;

        public ContactRepository()
        {
            _context = new ContactHandler();
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task CreateAsync(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
        }
    }
}
