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
            Hero hero = context.Heroes.Where(h => h.Id == id).FirstOrDefault();
            return View(hero);
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
                context.Heroes.Remove(context.Heroes.FirstOrDefault(h => h.Id == hero.Id));
                context.Heroes.Add(hero);
                context.SaveChanges();
                return RedirectToAction("List");


                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        //GET: Hero/Delete/5
        public ActionResult Delete(int id)
        {
            // Hero heroToDelete = context.Heroes.Where(hero => hero.Id == id).SingleOrDefault();
            Hero heroToDelete = context.Heroes.Find(id);

            return View( heroToDelete);
        }

        //POST: Hero/Delete/5
        [HttpPost]
        public ActionResult Delete( Hero heroToDelete)
        {
            try
            {

                context.Heroes.Remove(context.Heroes.FirstOrDefault(h => h.Id == heroToDelete.Id));
                context.SaveChanges();
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }
    }
}
