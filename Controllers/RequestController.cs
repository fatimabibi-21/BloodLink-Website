using Microsoft.AspNetCore.Mvc;
using BloodLink.Data;
using BloodLink.Models;
using System.Linq;

namespace BloodLink.Controllers
{
    public class RequestController : Controller
    {
        private readonly AppDbContext _db;

        public RequestController(AppDbContext db)
        {
            _db = db;
        }

        // Shows the newest requests first
        public IActionResult Index()
        {
            // Sort by Priority (Urgent first), then by Date (Newest first)
            var requests = _db.BloodRequests
                .OrderByDescending(r => r.Priority)
                .ThenByDescending(r => r.RequestDate)
                .ToList();

            return View(requests);
        }

        // post request (The Form)
        public IActionResult Create()
        {
            return View();
        }

        // save req and match it with existing donors
        [HttpPost]
        public IActionResult Create(BloodRequest obj)
        {
            if (ModelState.IsValid)
            {
                // Save the Request first (as usual)
                obj.RequestDate = DateTime.Now;
                obj.Status = "Pending";

                _db.BloodRequests.Add(obj);
                _db.SaveChanges();

                //  NEW LOGIC: Search for matching Donors
                // look for Donors where the BloodGroup matches the Request
                var matchingDonors = _db.Donors
                    .Where(d => d.BloodGroup == obj.BloodGroup)
                    .ToList();

                // If matches found, show the "Good News" page
                if (matchingDonors.Count > 0)
                {
                    // We pass the list of donors to a special view
                    return View("MatchFound", matchingDonors);
                }

                // If no matches, just go to the list as usual
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET: Show Edit Form
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();
            var reqFromDb = _db.BloodRequests.Find(id);
            if (reqFromDb == null) return NotFound();
            return View(reqFromDb);
        }

        // POST: Save Updates
        [HttpPost]
        public IActionResult Edit(BloodRequest obj)
        {
            if (ModelState.IsValid)
            {
                // Keep the original RequestDate (don't change it to today)
                _db.BloodRequests.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

       // Delete request
        public IActionResult Delete(int? id)
        {
            var obj = _db.BloodRequests.Find(id);
            if (obj != null)
            {
                _db.BloodRequests.Remove(obj);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}