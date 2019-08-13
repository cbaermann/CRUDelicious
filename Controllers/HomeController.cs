using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;


namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;

        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            List<Dish> dishes = dbContext.Dishes.ToList();
            return View("Index", dishes);
        }

        [HttpGet("Add")]

        public IActionResult Add()
        {
            return View("Add");
        }

        [HttpPost("New")]
        public IActionResult New(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Index", newDish);
            }
            else
            {
                return View("Add");
            }
        }

        [HttpGet("{id}")]

        public IActionResult displayDish(int id)
        {
            Dish dish = dbContext.Dishes.FirstOrDefault(d=>d.DishId==id);
            return View("dish", dish);
        }

        [HttpGet("edit/{id}")]

        public IActionResult Edit(int id)
        {
            Dish dish = dbContext.Dishes.FirstOrDefault(d=>d.DishId==id);
            return View("Edit", dish);
        }

        [HttpGet("destroy/{id}")]
        public IActionResult Destroy(int id)
        {
            Dish dish = dbContext.Dishes.FirstOrDefault(d=>d.DishId==id);
            dbContext.Dishes.Remove(dish);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost("update")]
        public IActionResult UpdateDish(Dish updateDish)
        {
            Console.WriteLine("I AM GETTING HERE **************");
            if(ModelState.IsValid)
            {
                Dish dish = dbContext.Dishes.FirstOrDefault(d=>d.DishId==updateDish.DishId);
                dish.Chef = updateDish.Chef;
                dish.Name = updateDish.Name;
                dish.Calories = updateDish.Calories;
                dish.Description = updateDish.Description;
                dish.Tastiness = updateDish.Tastiness;
                dish.UpdatedAt = DateTime.Now;
                dbContext.SaveChanges();
                return RedirectToAction("displayDish", new {id = dish.DishId});
            }

            else
            {
                return View("Edit", updateDish);
            }


        }




     
       
    }
}
