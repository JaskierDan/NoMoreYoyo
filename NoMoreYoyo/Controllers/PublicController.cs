using Microsoft.AspNetCore.Mvc;
using NoMoreYoyo.Models;

namespace NoMoreYoyo.Controllers
{
    public class PublicController : Controller
    {
        private readonly NoMoreYoyoContext DbContext;

        public PublicController(NoMoreYoyoContext context)
        {
            DbContext = context;
        }

        public IActionResult BodyAttributes()
        {
            return View();
        }

        public IActionResult Calories()
        {
            return View();
        }

        public IActionResult Login(LoginViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult SignIn(LoginViewModel model)
        {
            if (model.UserName == null)
            {
                ModelState.AddModelError(nameof(model.UserName), "You must provide a username if you wish to log in!");
            }
            if (model.Password == null)
            {
                ModelState.AddModelError(nameof(model.Password), "You must provide a password if you wish to log in!");
            }

            if (!ModelState.IsValid)
            {
                return View(nameof(Login), model);
            }

            return RedirectToAction(nameof(BodyAttributes));
        }

        public IActionResult Signup(LoginViewModel model)
        {

            //TO DO
            return null;
        }
    }
}
