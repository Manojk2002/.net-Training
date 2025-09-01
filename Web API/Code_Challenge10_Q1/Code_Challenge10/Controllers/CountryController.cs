using Code_Challenge10.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Code_Challenge10.Controllers
{
    public class CountryController : Controller
    {
        private static List<Country> countries = new List<Country>
        {
            new Country { ID = 1, CountryName = "Belgium", Capital = "Brussels" },
            new Country { ID = 2, CountryName = "Canada", Capital = "Ottawa" }
        };

        public ActionResult Index()
        {
            return View(countries);
        }

        public ActionResult Details(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return HttpNotFound();

            return View(country);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Country country)
        {
            country.ID = countries.Max(c => c.ID) + 1;
            countries.Add(country);
            return RedirectToAction("Index");
        }

        // GET: Country/Edit/1
        public ActionResult Edit(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return HttpNotFound();

            return View(country);
        }

        // POST: Country/Edit/1
        [HttpPost]
        public ActionResult Edit(int id, Country updatedCountry)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return HttpNotFound();

            country.CountryName = updatedCountry.CountryName;
            country.Capital = updatedCountry.Capital;
            return RedirectToAction("Index");
        }

        // GET: Country/Delete/1
        public ActionResult Delete(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return HttpNotFound();

            return View(country);
        }

        // POST: Country/Delete/1
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return HttpNotFound();

            countries.Remove(country);
            return RedirectToAction("Index");
        }
    }
}
