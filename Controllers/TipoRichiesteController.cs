using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wtime.Models;

namespace wtime.Controllers
{
    public class TipoRichiesteController : Controller
    {
        private WTimeDBContext db = new WTimeDBContext();

        // GET: TipoRichieste
        public ActionResult Index()
        {
            return View(db.TipoRichieste.ToList());
        }

        // GET: TipoRichieste/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoRichiesta tipoRichiesta = db.TipoRichieste.Find(id);
            if (tipoRichiesta == null)
            {
                return HttpNotFound();
            }
            return View(tipoRichiesta);
        }

        // GET: TipoRichieste/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoRichieste/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoRichiesta,Nome,Giornaliero")] TipoRichiesta tipoRichiesta)
        {
            if (ModelState.IsValid)
            {
                db.TipoRichieste.Add(tipoRichiesta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoRichiesta);
        }

        // GET: TipoRichieste/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoRichiesta tipoRichiesta = db.TipoRichieste.Find(id);
            if (tipoRichiesta == null)
            {
                return HttpNotFound();
            }
            return View(tipoRichiesta);
        }

        // POST: TipoRichieste/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoRichiesta,Nome,Giornaliero")] TipoRichiesta tipoRichiesta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoRichiesta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoRichiesta);
        }

        // GET: TipoRichieste/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoRichiesta tipoRichiesta = db.TipoRichieste.Find(id);
            if (tipoRichiesta == null)
            {
                return HttpNotFound();
            }
            return View(tipoRichiesta);
        }

        // POST: TipoRichieste/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoRichiesta tipoRichiesta = db.TipoRichieste.Find(id);
            db.TipoRichieste.Remove(tipoRichiesta);
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
