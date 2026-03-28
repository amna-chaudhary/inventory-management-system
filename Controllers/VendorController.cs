using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MVCPro.Models;
using System.Data.Entity;

namespace MVCPro.Controllers
{
    public class VendorController : Controller
    {
        private readonly MVCProEntities db = new MVCProEntities();

        // GET: Vendor
        public ActionResult Index()
        {
            var vendors = db.Vendors.ToList();
            return View(vendors);
        }

        // GET: Vendor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var vendor = db.Vendors.Find(id);

            if (vendor == null)
                return HttpNotFound();

            return View(vendor);
        }

        // GET: Vendor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vendor/Create
        // POST: Vendor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.Vendors.Add(vendor);
                db.SaveChanges();
                TempData["Success"] = "Vendor created successfully.";
                return RedirectToAction("Index"); // Redirect to the Vendor Index page after successful creation
            }

            // If validation fails, return the same view with validation errors
            TempData["Error"] = "Please correct the errors in the form.";
            return View(vendor);
        }


        // GET: Vendor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var vendor = db.Vendors.Find(id);
            if (vendor == null)
                return HttpNotFound();

            return View(vendor);
        }

        // POST: Vendor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendor).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Success"] = "Vendor updated successfully.";
                return RedirectToAction("Index");
            }

            TempData["Error"] = "Please correct the form.";
            return View(vendor);
        }

        // GET: Vendor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var vendor = db.Vendors.Find(id);
            if (vendor == null)
                return HttpNotFound();

            return View(vendor);
        }

        // POST: Vendor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var vendor = db.Vendors.Find(id);
            db.Vendors.Remove(vendor);
            db.SaveChanges();
            TempData["Success"] = "Vendor deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
