﻿using Microsoft.AspNetCore.Mvc;
using NoMoreYoyo.Models;
using System;

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

        public IActionResult Calories(CaloriesViewModel model = null)
        {
            return View(model ?? new CaloriesViewModel());
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