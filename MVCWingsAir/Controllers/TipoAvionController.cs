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
    public class TipoAvionController : Controller
    {
        private WingsAirEntities db = new WingsAirEntities();

        // GET: TipoAvion
        public ActionResult Index()
        {
            return View(db.TipoAvion.ToList());
        }

        // GET: TipoAvion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAvion tipoAvion = db.TipoAvion.Find(id);
            if (tipoAvion == null)
            {
                return HttpNotFound();
            }
            return View(tipoAvion);
        }

        // GET: TipoAvion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoAvion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoAvion,Nombre")] TipoAvion tipoAvion)
        {
            if (ModelState.IsValid)
            {
                db.TipoAvion.Add(tipoAvion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoAvion);
        }

        // GET: TipoAvion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAvion tipoAvion = db.TipoAvion.Find(id);
            if (tipoAvion == null)
            {
                return HttpNotFound();
            }
            return View(tipoAvion);
        }

        // POST: TipoAvion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoAvion,Nombre")] TipoAvion tipoAvion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoAvion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoAvion);
        }

        // GET: TipoAvion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAvion tipoAvion = db.TipoAvion.Find(id);
            if (tipoAvion == null)
            {
                return HttpNotFound();
            }
            return View(tipoAvion);
        }

        // POST: TipoAvion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoAvion tipoAvion = db.TipoAvion.Find(id);
            db.TipoAvion.Remove(tipoAvion);
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
