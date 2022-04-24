using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoMoreYoyo.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            
            


            BodyAttributesViewModel model = new BodyAttributesViewModel();

            var measurementTypes = DbContext.MeasurementTypes.ToList();

            foreach(var item in measurementTypes)
            {
                model.MeasurementTypes.Add(new SelectListItem
                {
                    Text = $"{item.Name} ({item.Metric})",
                    Value = item.Id.ToString()
                }) ;
            }
            
            return View(model);
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
        public ActionResult SaveMeasurement(BodyAttributesViewModel model)
        {
            if (model.Value == 0) {
                ModelState.AddModelError("Value"," Value must bne greater than 0!");
            }

            if (!ModelState.IsValid) {
                return View(nameof(BodyAttributes), model);
            }

            return Json(new { success = true, value = model.Value });
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
            if (model.UserName == null)
            {
                ModelState.AddModelError(nameof(model.UserName), "You must provide a username if you wish to sign up!");
            }
            if (model.Password == null)
            {
                ModelState.AddModelError(nameof(model.Password), "You must provide a password if you wish to sign up!");
            }
            if (model.EmailAddress == null)
            {
                ModelState.AddModelError(nameof(model.EmailAddress), "You must provide an email address if you wish to sign up!");
            }

            if (!ModelState.IsValid)
            {
                RegisterUser(model);
                return View(nameof(Login), model);
            }

            return RedirectToAction(nameof(BodyAttributes));
        }

        private void RegisterUser(LoginViewModel model)
        {
            var user = new User()
            {
                UserName = model.UserName,
                EmailAddress = model.EmailAddress,
                Password = model.Password,
                Sex = model.Sex,
                RegisteredDate = DateTime.UtcNow
            };

            DbContext.Attach(user);
            DbContext.Users.Add(user);
            DbContext.SaveChanges();
        }
    }
}
