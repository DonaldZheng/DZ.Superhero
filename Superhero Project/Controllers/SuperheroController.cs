using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Superhero_Project.Data;
using Superhero_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superhero_Project.Controllers
{
    public class SuperheroController : Controller
    {
        private ApplicationDbContext _context; //represents _context anywhere 

        public SuperheroController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Superhero
        public ActionResult Index()
        {
            return View();
        }

        // GET: Superhero/Details/5
        public ActionResult Details(int id)
        {
            var details = _context.Superheroes.Find(id);
            return View();
        }

        // GET: Superhero/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Superhero/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                _context.Superheroes.Add(superhero);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                Console.WriteLine("Error!");
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Superhero/Edit/5
        public ActionResult Edit(int id)
        {
            var editSuperhero = _context.Superheroes.Find(id);
            return View(editSuperhero);
        }

        // POST: Superhero/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Superhero superhero)
        {
            try
            {
                _context.Superheroes.Update(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Console.WriteLine("Error!");
                return View();
            }
        }

        // GET: Superhero/Delete/5
        public ActionResult Delete(int id)
        {
            var deleteSuperhero =_context.Superheroes.Find(id);
            return View();
        }

        // POST: Superhero/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Superhero superhero)
        {
            try
            {
                _context.Superheroes.Remove(superhero);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Console.WriteLine("Error!");
                return View();
            }
        }
    }
}
