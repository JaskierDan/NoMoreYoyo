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

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn()
        {
            return RedirectToAction(nameof(BodyAttributes));
        }

        public IActionResult Signup()
        {

            //TO DO
            return null;
        }

        public IActionResult MyProfile()
        {
            return View();
        }
    }
}
