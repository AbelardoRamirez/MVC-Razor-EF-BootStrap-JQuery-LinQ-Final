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
    public class AvionesController : Controller
    {
        private WingsAirEntities db = new WingsAirEntities();

        // GET: Aviones
        public ActionResult Index()
        {
            var aviones = db.Aviones.Include(a => a.TipoAvion);
            return View(aviones.ToList());
        }

        // GET: Aviones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aviones aviones = db.Aviones.Find(id);
            if (aviones == null)
            {
                return HttpNotFound();
            }
            return View(aviones);
        }

        // GET: Aviones/Create
        public ActionResult Create()
        {
            ViewBag.IdTipoAvion = new SelectList(db.TipoAvion, "IdTipoAvion", "Nombre");
            return View();
        }

        // POST: Aviones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAvion,Codigo,IdTipoAvion,HorasVuelo,Capacidad,Estatus")] Aviones aviones)
        {
            if (ModelState.IsValid)
            {
                db.Aviones.Add(aviones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoAvion = new SelectList(db.TipoAvion, "IdTipoAvion", "Nombre", aviones.IdTipoAvion);
            return View(aviones);
        }

        // GET: Aviones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aviones aviones = db.Aviones.Find(id);
            if (aviones == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoAvion = new SelectList(db.TipoAvion, "IdTipoAvion", "Nombre", aviones.IdTipoAvion);
            return View(aviones);
        }

        // POST: Aviones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAvion,Codigo,IdTipoAvion,HorasVuelo,Capacidad,Estatus")] Aviones aviones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aviones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoAvion = new SelectList(db.TipoAvion, "IdTipoAvion", "Nombre", aviones.IdTipoAvion);
            return View(aviones);
        }

        // GET: Aviones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aviones aviones = db.Aviones.Find(id);
            if (aviones == null)
            {
                return HttpNotFound();
            }
            return View(aviones);
        }

        // POST: Aviones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aviones aviones = db.Aviones.Find(id);
            db.Aviones.Remove(aviones);
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
