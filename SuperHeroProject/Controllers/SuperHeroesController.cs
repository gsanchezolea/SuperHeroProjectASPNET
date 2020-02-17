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
            List<Models.SuperHero> SuperHeroList = _context.SuperHeroes.ToList();
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
            if (ModelState.IsValid)
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
            SuperHero superHeroToEdit = _context.SuperHeroes.Where(s => s.Id == id).SingleOrDefault();
            return View(superHeroToEdit);
        }

        // POST: SuperHeroes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SuperHero superHeroWithEdits)
        {
            if (ModelState.IsValid)
            {
                SuperHero dbSuperHero = _context.SuperHeroes.Where(s => s.Id == superHeroWithEdits.Id).SingleOrDefault();
                dbSuperHero.Name = superHeroWithEdits.Name;
                dbSuperHero.AlterEgo = superHeroWithEdits.AlterEgo;
                dbSuperHero.PrimaryAbility = superHeroWithEdits.PrimaryAbility;
                dbSuperHero.SecondaryAbility = superHeroWithEdits.SecondaryAbility;
                dbSuperHero.CatchPhrase = dbSuperHero.CatchPhrase;
                
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: SuperHeroes/Delete/5
        public ActionResult Delete(int id)
        {
            SuperHero superHeroToDelete = _context.SuperHeroes.Where(s => s.Id == id).SingleOrDefault();
            return View(superHeroToDelete);
        }

        // POST: SuperHeroes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SuperHero superHeroToDelete)
        {
            if (ModelState.IsValid)
            {
                SuperHero dbSuperHero = _context.SuperHeroes.Where(s => s.Id == superHeroToDelete.Id).SingleOrDefault();
                _context.SuperHeroes.Remove(dbSuperHero);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}