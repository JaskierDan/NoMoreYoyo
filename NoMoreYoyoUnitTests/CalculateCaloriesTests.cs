using NUnit.Framework;
using Microsoft.EntityFrameworkCore;

using NoMoreYoyo.Models;
using NoMoreYoyo.Controllers;

namespace NoMoreYoyoUnitTests
{
    public class CalculateCaloriesTests
    {
        NoMoreYoyoContext context;
        PublicController controller;

        public CalculateCaloriesTests()
        {
            var options = new DbContextOptionsBuilder<NoMoreYoyoContext>().UseInMemoryDatabase("NoMoreYoyoTestDb").Options;
            context = new NoMoreYoyoContext(options);
            controller = new PublicController(context);
        }

        [Test]
        public void Get_Calories_When_User_Is_Male()
        { 
            CaloriesViewModel model = new CaloriesViewModel();
            model.Sex = 0;
            model.Age = 24;
            model.Activity = (decimal)1.725;
            model.Weight = 75;
            model.Height = 175;
            Assert.AreEqual(controller.GetCalories(model),3114.1425);

        }

        [Test]
        public void Get_Calories_When_User_Is_Female()
        {
            CaloriesViewModel model = new CaloriesViewModel();
            model.Sex = 1;
            model.Age = 25;
            model.Activity = (decimal)1.55;
            model.Weight = 55;
            model.Height = 164;
            Assert.AreEqual(controller.GetCalories(model), 2099.165);

        }
    }
}
