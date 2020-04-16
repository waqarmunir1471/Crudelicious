using System.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Crudelicious.Models;

namespace Crudelicious.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context){
            dbContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            List<CDelicious> AllDishes = dbContext.cDelicious.OrderByDescending(s => s.Name).ToList();
            return View(AllDishes);
        }
        [HttpGet("new")]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost("create")]
        public IActionResult Create(CDelicious newDish)
        {
            if(ModelState.IsValid)
            {
                dbContext.cDelicious.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else{
                return View("Add");
            }
        }
        [HttpGet("{detailId}")]
        public IActionResult Details(int detailId)
        {
            CDelicious GetDish = dbContext.cDelicious.FirstOrDefault(dish => dish.DishId == detailId);
            return View(GetDish);
        }
        [HttpGet("Edit/{EditId}")]
        public IActionResult EditId(int EditId, CDelicious cDelicious)
        {
            CDelicious GetDish = dbContext.cDelicious.FirstOrDefault(dish => dish.DishId == EditId);
            return View("Edit",GetDish);
        }
        [HttpPost("{DishId}")]
        public IActionResult Update(int DishId,CDelicious updateDish)
        {
            if(ModelState.IsValid){
                CDelicious GetDish = dbContext.cDelicious.FirstOrDefault(dish => dish.DishId == DishId);
                GetDish.Name = updateDish.Name;
                GetDish.ChefName = updateDish.ChefName;
                GetDish.Calories = updateDish.Calories;
                GetDish.Tastiness = updateDish.Tastiness;
                GetDish.Description = updateDish.Description;
                GetDish.UpdatedAt = DateTime.Now;
                dbContext.SaveChanges();
                return Redirect("/");
            }
            else{

                return Redirect($"Edit/{DishId}");
            }
            



        }
        // public IActionResult Privacy()
        // {
        //     return View();
        // }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        // }
    }
}
