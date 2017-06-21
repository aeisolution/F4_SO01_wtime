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
    public class ProfiliOrariController : Controller
    {
        private WTimeDBContext db = new WTimeDBContext();

        // GET: ProfilOrari
        public ActionResult Index()
        {
            return View(db.ProfiliOrari.ToList());
        }

        // GET: ProfilOrari/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfiloOrario profiloOrario = db.ProfiliOrari.Find(id);
            if (profiloOrario == null)
            {
                return HttpNotFound();
            }
            return View(profiloOrario);
        }

        // GET: ProfilOrari/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfilOrari/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,NumeroOre")] ProfiloOrario profiloOrario)
        {
            if (ModelState.IsValid)
            {
                db.ProfiliOrari.Add(profiloOrario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profiloOrario);
        }

        // GET: ProfilOrari/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfiloOrario profiloOrario = db.ProfiliOrari.Find(id);
            if (profiloOrario == null)
            {
                return HttpNotFound();
            }
            return View(profiloOrario);
        }

        // POST: ProfilOrari/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,NumeroOre")] ProfiloOrario profiloOrario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profiloOrario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profiloOrario);
        }

        // GET: ProfilOrari/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfiloOrario profiloOrario = db.ProfiliOrari.Find(id);
            if (profiloOrario == null)
            {
                return HttpNotFound();
            }
            return View(profiloOrario);
        }

        // POST: ProfilOrari/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProfiloOrario profiloOrario = db.ProfiliOrari.Find(id);
            db.ProfiliOrari.Remove(profiloOrario);
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
