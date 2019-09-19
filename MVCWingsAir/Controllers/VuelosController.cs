using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCWingsAir.Models;

namespace MVCWingsAir.Controllers
{
    public class VuelosController : Controller
    {
        private WingsAirEntities db = new WingsAirEntities();

        // GET: Vuelos
        public ActionResult Index()
        {
            var vuelos = db.Vuelos.Include(v => v.Aeropuertos).Include(v => v.Aeropuertos1).Include(v => v.Aviones).Include(v => v.OrigenDestino).Include(v => v.OrigenDestino1).Include(v => v.Pilotos);
            return View(vuelos.ToList());
        }

        // GET: Vuelos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vuelos vuelos = db.Vuelos.Find(id);
            if (vuelos == null)
            {
                return HttpNotFound();
            }
            return View(vuelos);
        }

        // GET: Vuelos/Create
        public ActionResult Create()
        {
            ViewBag.IdOrigen = new SelectList(db.Aeropuertos, "IdAeropuerto", "Municipio");
            ViewBag.IdDestino = new SelectList(db.Aeropuertos, "IdAeropuerto", "Municipio");
            ViewBag.IdAvion = new SelectList(db.Aviones, "IdAvion", "Codigo");
            ViewBag.IdOrigen = new SelectList(db.OrigenDestino, "IdOrigenDestino", "Nombre");
            ViewBag.IdDestino = new SelectList(db.OrigenDestino, "IdOrigenDestino", "Nombre");
            ViewBag.IdPiloto = new SelectList(db.Pilotos, "IdPiloto", "NombreCompleto");
            return View();
        }

        // POST: Vuelos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVuelo,Numerovuelo,Estatus,IdPiloto,IdAvion,IdOrigen,IdDestino,FechaVuelo")] Vuelos vuelos)
        {
            if (ModelState.IsValid)
            {
                db.Vuelos.Add(vuelos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdOrigen = new SelectList(db.Aeropuertos, "IdAeropuerto", "Municipio", vuelos.IdOrigen);
            ViewBag.IdDestino = new SelectList(db.Aeropuertos, "IdAeropuerto", "Municipio", vuelos.IdDestino);
            ViewBag.IdAvion = new SelectList(db.Aviones, "IdAvion", "Codigo", vuelos.IdAvion);
            ViewBag.IdOrigen = new SelectList(db.OrigenDestino, "IdOrigenDestino", "Nombre", vuelos.IdOrigen);
            ViewBag.IdDestino = new SelectList(db.OrigenDestino, "IdOrigenDestino", "Nombre", vuelos.IdDestino);
            ViewBag.IdPiloto = new SelectList(db.Pilotos, "IdPiloto", "NombreCompleto", vuelos.IdPiloto);
            return View(vuelos);
        }

        // GET: Vuelos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vuelos vuelos = db.Vuelos.Find(id);
            if (vuelos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdOrigen = new SelectList(db.Aeropuertos, "IdAeropuerto", "Municipio", vuelos.IdOrigen);
            ViewBag.IdDestino = new SelectList(db.Aeropuertos, "IdAeropuerto", "Municipio", vuelos.IdDestino);
            ViewBag.IdAvion = new SelectList(db.Aviones, "IdAvion", "Codigo", vuelos.IdAvion);
            ViewBag.IdOrigen = new SelectList(db.OrigenDestino, "IdOrigenDestino", "Nombre", vuelos.IdOrigen);
            ViewBag.IdDestino = new SelectList(db.OrigenDestino, "IdOrigenDestino", "Nombre", vuelos.IdDestino);
            ViewBag.IdPiloto = new SelectList(db.Pilotos, "IdPiloto", "NombreCompleto", vuelos.IdPiloto);
            return View(vuelos);
        }

        // POST: Vuelos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVuelo,Numerovuelo,Estatus,IdPiloto,IdAvion,IdOrigen,IdDestino,FechaVuelo")] Vuelos vuelos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vuelos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdOrigen = new SelectList(db.Aeropuertos, "IdAeropuerto", "Municipio", vuelos.IdOrigen);
            ViewBag.IdDestino = new SelectList(db.Aeropuertos, "IdAeropuerto", "Municipio", vuelos.IdDestino);
            ViewBag.IdAvion = new SelectList(db.Aviones, "IdAvion", "Codigo", vuelos.IdAvion);
            ViewBag.IdOrigen = new SelectList(db.OrigenDestino, "IdOrigenDestino", "Nombre", vuelos.IdOrigen);
            ViewBag.IdDestino = new SelectList(db.OrigenDestino, "IdOrigenDestino", "Nombre", vuelos.IdDestino);
            ViewBag.IdPiloto = new SelectList(db.Pilotos, "IdPiloto", "NombreCompleto", vuelos.IdPiloto);
            return View(vuelos);
        }

        // GET: Vuelos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vuelos vuelos = db.Vuelos.Find(id);
            if (vuelos == null)
            {
                return HttpNotFound();
            }
            return View(vuelos);
        }

        // POST: Vuelos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vuelos vuelos = db.Vuelos.Find(id);
            db.Vuelos.Remove(vuelos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
