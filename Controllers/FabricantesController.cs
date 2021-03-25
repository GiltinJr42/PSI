using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PSI.Models;

namespace PSI.Controllers
{
    public class FabricantesController : Controller
    {
        private static IList<Fabricante> fabricantes = new List<Fabricante>()
            {
            new Fabricante() { FabricanteId = 1, Nome = "Sony"},
            new Fabricante() { FabricanteId = 2, Nome = "Vaio"},
            new Fabricante() { FabricanteId = 3, Nome = "Dell"},
            new Fabricante() { FabricanteId = 4, Nome = "Samsung"},
            new Fabricante() { FabricanteId = 5, Nome = "Alienware"}
            };
        // GET: Fabricante
        public ActionResult Index()
        {
            return View(fabricantes);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {
            fabricantes.Add(fabricante);
            fabricante.FabricanteId = fabricantes.Select(m => m.FabricanteId).Max() + 1;
            return RedirectToAction("Index");
        }

        //Editar
        public ActionResult Edit(long id)
        {
            return View(fabricantes.Where(m => m.FabricanteId == id).First());
        }
        public ActionResult Details(long id)
        {
            return View(fabricantes.Where(m => m.FabricanteId == id).First());
        }
        public ActionResult Delete(long id)
        {
            return View(fabricantes.Where(m => m.FabricanteId == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Fabricante fabricante)
        {
            fabricantes.Remove(
            fabricantes.Where(c => c.FabricanteId == fabricante.FabricanteId).First());
            return RedirectToAction("Index");
        }
    }
}