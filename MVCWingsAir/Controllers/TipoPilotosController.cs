using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCWingsAir.Models;

namespace MVCWingsAir.Controllers {
	public class TipoPilotosController : Controller {
		private WingsAirEntities db = new WingsAirEntities();

		// GET: TipoPilotos
		public ActionResult Index() {
			return View( db.TipoPiloto.ToList() );
		}

		// GET: TipoPilotos/Details/5
		public ActionResult Details( int? id ) {
			if( id == null ) {
				return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
			}
			TipoPiloto tipoPiloto = db.TipoPiloto.Find( id );
			if( tipoPiloto == null ) {
				return HttpNotFound();
			}
			return View( tipoPiloto );
		}

		// GET: TipoPilotos/Create
		public ActionResult Create() {
			return View();
		}

		// POST: TipoPilotos/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create( [Bind( Include = "IdTipoPiloto,Tipo" )] TipoPiloto tipoPiloto ) {
			if( ModelState.IsValid ) {
				db.TipoPiloto.Add( tipoPiloto );
				db.SaveChanges();
				return RedirectToAction( "Index" );
			}

			return View( tipoPiloto );
		}

		// GET: TipoPilotos/Edit/5
		public ActionResult Edit( int? id ) {
			if( id == null ) {
				return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
			}
			TipoPiloto tipoPiloto = db.TipoPiloto.Find( id );
			if( tipoPiloto == null ) {
				return HttpNotFound();
			}
			return View( tipoPiloto );
		}

		// POST: TipoPilotos/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit( [Bind( Include = "IdTipoPiloto,Tipo" )] TipoPiloto tipoPiloto ) {
			if( ModelState.IsValid ) {
				db.Entry( tipoPiloto ).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction( "Index" );
			}
			return View( tipoPiloto );
		}

		// GET: TipoPilotos/Delete/5
		public ActionResult Delete( int? id ) {
			if( id == null ) {
				return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
			}
			TipoPiloto tipoPiloto = db.TipoPiloto.Find( id );
			if( tipoPiloto == null ) {
				return HttpNotFound();
			}
			return View( tipoPiloto );
		}

		// POST: TipoPilotos/Delete/5
		[HttpPost, ActionName( "Delete" )]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed( int id ) {
			TipoPiloto tipoPiloto = db.TipoPiloto.Find( id );
			db.TipoPiloto.Remove( tipoPiloto );
			db.SaveChanges();
			return RedirectToAction( "Index" );
		}

		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				db.Dispose();
			}
			base.Dispose( disposing );
		}
	}
}
