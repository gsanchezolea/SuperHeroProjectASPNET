using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroProject.Data;
using SuperHeroProject.Models;

namespace SuperHeroProject.Controllers
{
   
    public class SuperHeroesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuperHeroesController(ApplicationDbContext context)
        {
            _context = context;
        }
      
        // GET: SuperHeroes
        public ActionResult Index()
        {
            List<Models.SuperHero> SuperHeroList =_context.SuperHeroes.ToList();
            return View(SuperHeroList);
        }

        // GET: SuperHeroes/Details/5
        public ActionResult Details(int id)
        {
            SuperHero superHeroDetails = _context.SuperHeroes.Where(s => s.Id == id).SingleOrDefault();
            return View(superHeroDetails);
        }

        // GET: SuperHeroes/Create
        public ActionResult Create()
        {
            SuperHero newSuperHero = new SuperHero();
            return View(newSuperHero);
        }

        // POST: SuperHeroes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuperHero newSuperHero)
        {
         if(ModelState.IsValid)
            {
                _context.SuperHeroes.Add(newSuperHero);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }

        // GET: SuperHeroes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SuperHeroes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHeroes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SuperHeroes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}