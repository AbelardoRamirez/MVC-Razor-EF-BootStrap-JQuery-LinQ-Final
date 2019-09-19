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
    public class AeropuertosController : Controller
    {
        private WingsAirEntities db = new WingsAirEntities();

        // GET: Aeropuertos
        public ActionResult Index()
        {
            return View(db.Aeropuertos.ToList());
        }

        // GET: Aeropuertos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aeropuertos aeropuertos = db.Aeropuertos.Find(id);
            if (aeropuertos == null)
            {
                return HttpNotFound();
            }
            return View(aeropuertos);
        }

        // GET: Aeropuertos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aeropuertos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAeropuerto,Municipio,Estado,Pais")] Aeropuertos aeropuertos)
        {
            if (ModelState.IsValid)
            {
                db.Aeropuertos.Add(aeropuertos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aeropuertos);
        }

        // GET: Aeropuertos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aeropuertos aeropuertos = db.Aeropuertos.Find(id);
            if (aeropuertos == null)
            {
                return HttpNotFound();
            }
            return View(aeropuertos);
        }

        // POST: Aeropuertos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAeropuerto,Municipio,Estado,Pais")] Aeropuertos aeropuertos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aeropuertos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aeropuertos);
        }

        // GET: Aeropuertos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aeropuertos aeropuertos = db.Aeropuertos.Find(id);
            if (aeropuertos == null)
            {
                return HttpNotFound();
            }
            return View(aeropuertos);
        }

        // POST: Aeropuertos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aeropuertos aeropuertos = db.Aeropuertos.Find(id);
            db.Aeropuertos.Remove(aeropuertos);
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
