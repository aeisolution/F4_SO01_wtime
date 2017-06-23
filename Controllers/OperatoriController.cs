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
    [Authorize]
    public class OperatoriController : Controller
    {
        private WTimeDBContext db = new WTimeDBContext();

        // GET: Operatori
        public ActionResult Index(string query)
        {
            IQueryable<Operatore> operatori = db.Operatori.OrderBy(o => o.Cognome);

            if (!string.IsNullOrEmpty(query))
            {
                operatori = operatori
                                .Where(o => o.Cognome.Contains(query) 
                                         || o.Nome.Contains(query)
                                         || o.CodiceFiscale.Contains(query));
            }

            ViewBag.search = query;

            return View(operatori.ToList());
        }


        // GET: Operatori/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operatore operatore = db.Operatori.Find(id);
            if (operatore == null)
            {
                return HttpNotFound();
            }
            return View(operatore);
        }

        // GET: Operatori/Create
        public ActionResult Create()
        {
            ViewBag.IdProfiloOrario = new SelectList(db.ProfiliOrari, "IdProfiloOrario", "Nome");
            return View();
        }

        // POST: Operatori/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Operatore operatore)
        {
            if (ModelState.IsValid)
            {
                db.Operatori.Add(operatore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(operatore);
        }

        // GET: Operatori/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operatore operatore = db.Operatori.Find(id);
            if (operatore == null)
            {
                return HttpNotFound();
            }

            ViewBag.selectProfiliOrari = new SelectList(db.ProfiliOrari, 
                                                        "IdProfiloOrario", "Nome", 
                                                        operatore.IdProfiloOrario);
            return View(operatore);
        }

        // POST: Operatori/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Operatore operatore)
        {
            operatore.ProfiloOrario = db.ProfiliOrari
                                        .Find(operatore.IdProfiloOrario);

            if (ModelState.IsValid)
            {
                db.Entry(operatore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProfiloOrario = new SelectList(db.ProfiliOrari, "IdProfiloOrario", "Nome");
            return View(operatore);
        }

        // GET: Operatori/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operatore operatore = db.Operatori.Find(id);
            if (operatore == null)
            {
                return HttpNotFound();
            }
            return View(operatore);
        }

        // POST: Operatori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Operatore operatore = db.Operatori.Find(id);
            db.Operatori.Remove(operatore);
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
