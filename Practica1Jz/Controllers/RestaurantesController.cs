using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practica1Jz.Models;

namespace Practica1Jz.Controllers
{
    public class RestaurantesController : Controller
    {
        private readonly RestauranteContext _context;
        public RestaurantesController(RestauranteContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var restaurantes = await _context.Restaurante.ToListAsync();
            if (restaurantes.Count > 0)
                return View(restaurantes);
            return NoContent();
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        public IActionResult Create(Restaurante restaurantes)
        {
            
            if (ModelState.IsValid)
            {
                _context.Restaurante.Add(restaurantes);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurantes);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {             
                return View();
            }
            else
            {
                var restaurantes = _context.Restaurante.Find(id);
                if (restaurantes == null)
                {                  
                    return View();
                }
                else
                {                   
                    return View(restaurantes);
                }
            }
        }
        [HttpPost]
        public IActionResult Edit(Restaurante restaurantes)
        {
            if (ModelState.IsValid)
            {
                _context.Restaurante.Update(restaurantes);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurantes);
        }
        public ActionResult Delete(int? id)
        {
            var restaurantes = _context.Restaurante.Find(id);

            if (restaurantes == null)
            {
                return View();
            }

            return View(restaurantes);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmado(int id)
        {
            var restaurantes = _context.Restaurante.Find(id);

            if (restaurantes == null)
            {
                return View();
            }

            _context.Restaurante.Remove(restaurantes);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
