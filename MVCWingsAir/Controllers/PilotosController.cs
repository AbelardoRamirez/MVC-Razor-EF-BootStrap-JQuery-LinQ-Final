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
    public class PilotosController : Controller
    {
        private WingsAirEntities db = new WingsAirEntities();

        // GET: Pilotos
        public ActionResult Index()
        {
            var pilotos = db.Pilotos.Include(p => p.TipoPiloto);
            return View(pilotos.ToList());
        }

        // GET: Pilotos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pilotos pilotos = db.Pilotos.Find(id);
            if (pilotos == null)
            {
                return HttpNotFound();
            }
            return View(pilotos);
        }

        // GET: Pilotos/Create
        public ActionResult Create()
        {
            ViewBag.IdTipoPiloto = new SelectList(db.TipoPiloto, "IdTipoPiloto", "Tipo");
            return View();
        }

        // POST: Pilotos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPiloto,NombreCompleto,Sexo,HorasVuelo,Estatus,IdTipoPiloto")] Pilotos pilotos)
        {
            if (ModelState.IsValid)
            {
                db.Pilotos.Add(pilotos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoPiloto = new SelectList(db.TipoPiloto, "IdTipoPiloto", "Tipo", pilotos.IdTipoPiloto);
            return View(pilotos);
        }

        // GET: Pilotos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pilotos pilotos = db.Pilotos.Find(id);
            if (pilotos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoPiloto = new SelectList(db.TipoPiloto, "IdTipoPiloto", "Tipo", pilotos.IdTipoPiloto);
            return View(pilotos);
        }

        // POST: Pilotos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPiloto,NombreCompleto,Sexo,HorasVuelo,Estatus,IdTipoPiloto")] Pilotos pilotos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pilotos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoPiloto = new SelectList(db.TipoPiloto, "IdTipoPiloto", "Tipo", pilotos.IdTipoPiloto);
            return View(pilotos);
        }

        // GET: Pilotos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pilotos pilotos = db.Pilotos.Find(id);
            if (pilotos == null)
            {
                return HttpNotFound();
            }
            return View(pilotos);
        }

        // POST: Pilotos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pilotos pilotos = db.Pilotos.Find(id);
            db.Pilotos.Remove(pilotos);
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
