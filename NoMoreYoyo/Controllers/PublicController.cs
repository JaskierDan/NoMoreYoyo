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

        public IActionResult Index()
        {
            return View();
        }
    }
}
