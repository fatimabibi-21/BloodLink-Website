using Microsoft.AspNetCore.Mvc;
using BloodLink.Data;
using BloodLink.Models;
using System.Linq;

namespace BloodLink.Controllers
{
    public class DonorController : Controller
    {
        // fro database connection
        private readonly AppDbContext _db;

        // This is the Constructor. It gets the database "keys" when the controller starts.
        public DonorController(AppDbContext db)
        {
            _db = db;
        }

        // List of donors with search functionality
        public IActionResult Index(string searchString)
        {
            // Start with the full list of donors from the database
            var donors = from d in _db.Donors
                         select d;

            // Check: Did the user type anything in the search box?
            if (!string.IsNullOrEmpty(searchString))
            {
                // 3. Filter the list: Keep donors where BloodGroup OR City matches the search
                donors = donors.Where(d => d.BloodGroup.Contains(searchString)
                                        || d.City.Contains(searchString));
            }

            // Send the filtered list to the View
            return View(donors.ToList());
        }

        //add nrew form for donor
        public IActionResult Create()
        {
            // Just show the blank HTML form
            return View();
        }

        // save data from FORM to database
        [HttpPost] 
        public IActionResult Create(Donor obj)
        {
            if (ModelState.IsValid)
            {
                // Add the new donor object to the database queue
                _db.Donors.Add(obj);

                // Commit the changes to mssql
                _db.SaveChanges();

                // Go back to the list page
                return RedirectToAction("Index");
            }
            // If there is an error, stay on the page
            return View(obj);
        }

        // dlt donor
        public IActionResult Delete(int? id)
        {
            //Find the donor by their ID
            var donorObj = _db.Donors.Find(id);

            //If found, remove them
            if (donorObj != null)
            {
                _db.Donors.Remove(donorObj);
                _db.SaveChanges(); // Save the deletion to SQL
            }

            //Refresh the list
            return RedirectToAction("Index");
        }

     // edit donor
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var donorFromDb = _db.Donors.Find(id);

            if (donorFromDb == null)
            {
                return NotFound();
            }

            return View(donorFromDb);
        }

        // Save the changes
        [HttpPost]
        public IActionResult Edit(Donor obj)
        {
            if (ModelState.IsValid)
            {
                _db.Donors.Update(obj); // This updates the existing row
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}