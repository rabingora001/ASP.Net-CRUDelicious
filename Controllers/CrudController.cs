using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CRUDelicious.Models;
using System.Linq;

namespace CRUDelicious.Controllers
{
    public class CrudController : Controller
    {
        private CrudContext dbContext;
        public CrudController(CrudContext context)
        {
            dbContext = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            List<Crud> AllDishes = dbContext.dishes.ToList();
            ViewBag.AllDish =AllDishes;
            return View();
        }
        
        [HttpGet]
        [Route("/AddPage")]
        public IActionResult AddPage()
        {
            return View();
        }

        [HttpPost]
        [Route ("/create")]
        public IActionResult CreateDish(Crud AllDishes)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(AllDishes);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                System.Console.WriteLine("error on adding dishes....this did not work");
                return View("AddPage");
            }
        }

        [HttpGet]
        [Route("/show/{id}")]
        public IActionResult Showw(int id)
        {
            Crud showPage = dbContext.dishes.SingleOrDefault(s => s.CrudId == id);
            ViewBag.Show = showPage;
            System.Console.WriteLine("IN SHOW PAGEEEEE");
            System.Console.WriteLine("IN SHOW PAGEEEEE");
            System.Console.WriteLine("IN SHOW PAGEEEEE");
            System.Console.WriteLine("IN SHOW PAGEEEEE");
            return View("ShowPage");
        }

        [HttpGet]
        [Route("/edit/{id}")]
        public IActionResult EditPage(int id)
        {
            Crud editPage = dbContext.dishes.SingleOrDefault(e => e.CrudId == id);
            ViewBag.Show = editPage;
            return View("EditPage");
        }

        [HttpPost]
        [Route("/edit/{EditedId}")]
        public IActionResult EditDish(int EditedId, Crud update)
        {
            Crud editDish=dbContext.dishes.SingleOrDefault(e => e.CrudId == EditedId);
            
            if (ModelState.IsValid)
            {
                editDish.Name=update.Name;
                editDish.Chef=update.Chef;
                editDish.Tastiness=update.Tastiness;
                editDish.Calories=update.Calories;
                editDish.Description=update.Description;
                editDish.UpdatedAt=DateTime.Now;
                dbContext.SaveChanges();
                return RedirectToAction("Showw", new {id = EditedId});
            }
            else
            {
                return View("EditPage");
            }

        }

        [HttpGet]
        [Route("show/delete/{DeleteId}")]
        public IActionResult DeleteFood(int DeleteId)
        {
            Crud deleteFood = dbContext.dishes.SingleOrDefault(d => d.CrudId == DeleteId);
            dbContext.dishes.Remove(deleteFood);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
