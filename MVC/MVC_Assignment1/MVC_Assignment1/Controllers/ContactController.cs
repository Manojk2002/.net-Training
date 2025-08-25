using MVC_Assignment1.Models;
using MVC_Assignment1.Repositories;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVC_Assignment1.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepo _repository;

        public ContactController()
        {
            _repository = new ContactRepository();
        }

        public async Task<ActionResult> Index()
        {
            var contacts = await _repository.GetAllAsync();
            return View(contacts);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateAsync(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        public async Task<ActionResult> Delete(long id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }

}