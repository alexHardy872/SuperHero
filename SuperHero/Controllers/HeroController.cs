using SuperHero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHero.Controllers
{
    public class HeroController : Controller
    {
        ApplicationDbContext context;
        public HeroController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Hero
        public ActionResult Index()
        {
            return View();
        }

        // GET: Hero/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Hero List/ List

        public ActionResult List()
        {
            List<Hero> heroList = context.Heroes.ToList();
            return View(heroList);
        }

        [HttpPost]
        public ActionResult List(List<Hero> heroList)
        {   
           
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: Hero/Create
        public ActionResult Create()
        {
            Hero hero = new Hero();
            return View(hero);
        }

        // POST: Hero/Create
        [HttpPost]
        public ActionResult Create(Hero hero)
        {
            try
            {
                context.Heroes.Add(hero);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        // GET: Hero/Edit/5
        public ActionResult Edit(int id)
        {
            Hero hero = context.Heroes.Where(h => h.Id == id).First();
            return View(hero);
        }

        // POST: Hero/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Hero hero)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Hero/Delete/5
        public ActionResult Delete(int id)
        {
            Hero hero = context.Heroes.Where(h => h.Id == id).First();
            return View(hero);
        }

        // POST: Hero/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Hero hero)
        {
            try
            {
                context.Heroes.Remove(hero);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
