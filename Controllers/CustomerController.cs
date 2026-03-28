using MVCPro.Models;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MVCPro.Controllers
{
    public class CustomerController : Controller
    {
        private MVCProEntities db = new MVCProEntities();

        // GET: Customer
        public ActionResult Index()
        {
            var customers = db.CustomerTable.ToList();
            return View(customers);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var customer = db.CustomerTable.Find(id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(CustomerTable customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }

            try
            {
                db.CustomerTable.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error saving to database: " + ex.Message);
                return View(customer);
            }
        }


        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var customer = db.CustomerTable.Find(id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerTable customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error updating customer: " + ex.Message);
                }
            }

            return View(customer);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var customer = db.CustomerTable.Find(id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var customer = db.CustomerTable.Find(id);
            if (customer != null)
            {
                db.CustomerTable.Remove(customer);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // Dispose database context properly
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
