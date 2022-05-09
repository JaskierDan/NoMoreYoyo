using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoMoreYoyo.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace NoMoreYoyo.Controllers
{
    public class PublicController : Controller
    {
        private readonly NoMoreYoyoContext DbContext;

        public PublicController(NoMoreYoyoContext context)
        {
            DbContext = context;
        }

        public IActionResult BodyAttributes(BodyAttributesViewModel passedModel = null)
        {
            BodyAttributesViewModel model = new BodyAttributesViewModel();

            if (passedModel != null)
            {
                model.Value = passedModel.Value;
            }

            GetMeasurementTypes(model);

            return View(model);
        }

        public IActionResult Calories(CaloriesViewModel model = null)
        {
            return View(model ?? new CaloriesViewModel());
        }

        public IActionResult Login(LoginViewModel model)
        {
            return View(model);
        }

        public IActionResult SignUp(SignUpViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveMeasurement(BodyAttributesViewModel model)
        {
            if (model.Value == 0)
            {
                ModelState.AddModelError(nameof(model.Value), " Value must be greater than 0!");
            }

            if (!ModelState.IsValid)
            {
                return View(nameof(BodyAttributes), model);
            }

            GetMeasurementTypes(model);

            return View(nameof(BodyAttributes), model);
        }

        [HttpPost]
        public ActionResult SignIn(LoginViewModel model)
        {
            var user = DbContext.Users.FirstOrDefault(u => u.UserName == model.EmailOrUserName || u.EmailAddress == model.EmailOrUserName);

            if (model.EmailOrUserName == null)
            {
                ModelState.AddModelError(nameof(model.EmailOrUserName), "You must provide a username or email if you wish to log in!");
            }
            if (user == null)
            {
                ModelState.AddModelError(nameof(model.EmailOrUserName), "The username or email you provided does not match any registered accounts!");
            }
            if (model.Password == null)
            {
                ModelState.AddModelError(nameof(model.Password), "You must provide a password if you wish to log in!");
            }
            if (user != null)
            {
                if (user.Password != model.Password)
                {
                    ModelState.AddModelError(nameof(model.Password), "The password you provided is incorrect!");
                }
            }

            if (!ModelState.IsValid)
            {
                return View(nameof(Login), model);
            }

            return RedirectToAction(nameof(BodyAttributes));
        }
        [HttpPost]
        public ActionResult SaveHealthStats(CaloriesViewModel model)
        {
            return View(nameof(Calories), model);
        }

        [HttpPost]
        public ActionResult CalculateCalories(CaloriesViewModel model)
        {
            if (model.Weight == 0)
            {
                ModelState.AddModelError(nameof(model.Weight), "Value must be greater than 0!");
            }
            if (model.Height == 0)
            {
                ModelState.AddModelError(nameof(model.Height), "Value must be greater than 0!");
            }
            if (model.Age == 0)
            {
                ModelState.AddModelError(nameof(model.Age), "Value must be greater than 0!");
            }
            if (model.Activity == null)
            {
                ModelState.AddModelError(nameof(model.Activity), "You must select a level of activity!");
            }

            if (!ModelState.IsValid)
            {
                return PartialView(nameof(Calories), model);
            }

            return Json(new { success = true, calories = GetCalories(model) });
        }

        [HttpPost]
        public IActionResult Register(SignUpViewModel model)
        {
            if (model.UserName == null)
            {
                ModelState.AddModelError(nameof(model.UserName), "You must provide a username if you wish to sign up!");
            }
            if (model.Password == null)
            {
                ModelState.AddModelError(nameof(model.Password), "You must provide a password if you wish to sign up!");
            }
            if (model.PasswordAgain != model.Password)
            {
                ModelState.AddModelError(nameof(model.PasswordAgain), "The passwords don't match!");
            }
            if (model.EmailAddress == null)
            {
                ModelState.AddModelError(nameof(model.EmailAddress), "You must provide an email address if you wish to sign up!");
            }

            if (!ModelState.IsValid)
            {
                return View(nameof(SignUp), model);
            }

            RegisterUser(model);
            return RedirectToAction(nameof(BodyAttributes));
        }

        private void RegisterUser(SignUpViewModel model)
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

        private void GetMeasurementTypes(BodyAttributesViewModel model)
        {
            var measurementTypes = DbContext.MeasurementTypes.ToList();

            foreach (var item in measurementTypes)
            {
                Debug.WriteLine("Lefutott");
                model.MeasurementTypes.Add(new SelectListItem
                {
                    Text = $"{item.Name} ({item.Metric})",
                    Value = item.Id.ToString()
                });
            }
        }

        public decimal GetCalories(CaloriesViewModel model)
        {
            if (model.Sex == 0)
                return (66 + (decimal)13.7 * model.Weight + 5 * model.Height - (decimal)6.8 * model.Age) * (decimal)model.Activity;
            else
                return (665 + (decimal)9.6 * model.Weight + (decimal)1.7 * model.Height - (decimal)4.7 * model.Age) * (decimal)model.Activity;
        }

        public IActionResult MyProfile()
        {
            return View();
        }
    }
}
