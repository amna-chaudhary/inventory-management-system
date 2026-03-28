using System.Web.Mvc;
using MVCPro.Models;

namespace MVCPro.Controllers
{
    public class AccountController : Controller
    {
        // GET: Register
        // GET: Register
        public ActionResult Register()
        {
            return View(new User());  // Pass an empty User object to the view to avoid null reference
        }

        // POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                // Save to the database (ensure to save User object to the database)
                // db.Users.Add(model);
                // db.SaveChanges();

                return RedirectToAction("Login");
            }

            return View(model);  // Pass the model back if the form validation fails
        }


        // GET: Login
        // GET: Login
        public ActionResult Login()
        {
            return View(new User());  // Ensure to pass an empty User object for binding
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                // Authentication logic here (check if the user exists in the database)
                // Example:
                // var user = db.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

                return RedirectToAction("Index", "Home");
            }

            return View(model);  // Return the model back to the view if invalid
        }

    }
}
