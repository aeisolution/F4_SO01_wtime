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
    public class RichiesteController : Controller
    {
        private WTimeDBContext db = new WTimeDBContext();

        // GET: Richieste
        public ActionResult Index()
        {
            var richieste = db.Richieste.Include(r => r.Operatore).Include(r => r.Status).Include(r => r.TipoRichiesta);
            return View(richieste.ToList());
        }

        // GET: Richieste/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Richiesta richiesta = db.Richieste.Find(id);
            if (richiesta == null)
            {
                return HttpNotFound();
            }
            return View(richiesta);
        }

        // GET: Richieste/Create
        public ActionResult Create()
        {
            ViewBag.IdOperatore = new SelectList(db.Operatori, "Id", "Nome");
            //ViewBag.IdTipoStatus = new SelectList(db.TipoStatus, "IdTipoStatus", "Nome");
            ViewBag.IdTipoRichiesta = new SelectList(db.TipoRichieste, "IdTipoRichiesta", "Nome");
            return View();
        }

        // POST: Richieste/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Richiesta richiestaVM)
        {
            var tipo = db.TipoRichieste.Find(richiestaVM.IdTipoRichiesta);
            richiestaVM.DataStatus = DateTime.Now;
            richiestaVM.IdTipoStatus = 1;
            richiestaVM.Status = db.TipoStatus.Find(1);

            if (tipo.Giornaliero)
            {
                richiestaVM.Giornaliera = true;
                richiestaVM.DataFine = richiestaVM.DataInizio;
            }

            if (ModelState.IsValid)
            {
                db.Richieste.Add(richiestaVM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdOperatore = new SelectList(db.Operatori, "Id", "Nome", richiestaVM.IdOperatore);
            ViewBag.IdTipoStatus = new SelectList(db.TipoStatus, "IdTipoStatus", "Nome", richiestaVM.IdTipoStatus);
            ViewBag.IdTipoRichiesta = new SelectList(db.TipoRichieste, "IdTipoRichiesta", "Nome", richiestaVM.IdTipoRichiesta);
            return View(richiestaVM);
        }

        // GET: Richieste/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Richiesta richiesta = db.Richieste.Find(id);
            if (richiesta == null)
            {
                return HttpNotFound();
            } 

            if(richiesta.IdTipoStatus!=1)
            {
                return RedirectToAction("Index");
            }

            //ViewBag.IdOperatore = new SelectList(db.Operatori, "Id", "Nome", richiesta.IdOperatore);
            //ViewBag.IdTipoStatus = new SelectList(db.TipoStatus, "IdTipoStatus", "Nome", richiesta.IdTipoStatus);
            ViewBag.IdTipoRichiesta = new SelectList(db.TipoRichieste, "IdTipoRichiesta", "Nome", richiesta.IdTipoRichiesta);
            return View(richiesta);
        }

        // POST: Richieste/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRichiesta,IdOperatore,DataInizio,DataFine,Giornaliera,OraInizio,MinutiInizio,OraFine,MinutiFine,IdTipoStatus,DataStatus,Note,UsernameValidatore,IdTipoRichiesta")] Richiesta richiesta)
        {
            /*
            Richiesta ricDB = db.Richieste.Find(richiesta.IdRichiesta);
            if (ricDB.IdTipoStatus != 1)
            {
                return RedirectToAction("Index");
            }
            */
            var tipo = db.TipoRichieste.Find(richiesta.IdTipoRichiesta);
            richiesta.DataStatus = DateTime.Now;
            richiesta.IdTipoStatus = 1;
            richiesta.Status = db.TipoStatus.Find(1);

            if (tipo.Giornaliero)
            {
                richiesta.Giornaliera = true;
                richiesta.DataFine = richiesta.DataInizio;
            }

            if (ModelState.IsValid)
            {
                db.Entry(richiesta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdOperatore = new SelectList(db.Operatori, "Id", "Nome", richiesta.IdOperatore);
            ViewBag.IdTipoStatus = new SelectList(db.TipoStatus, "IdTipoStatus", "Nome", richiesta.IdTipoStatus);
            ViewBag.IdTipoRichiesta = new SelectList(db.TipoRichieste, "IdTipoRichiesta", "Nome", richiesta.IdTipoRichiesta);
            return View(richiesta);
        }

        // GET: Richieste/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Richiesta richiesta = db.Richieste.Find(id);
            if (richiesta == null)
            {
                return HttpNotFound();
            }

            if (richiesta.IdTipoStatus != 1)
            {
                return RedirectToAction("Index");
            }

            return View(richiesta);
        }

        // POST: Richieste/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Richiesta richiesta = db.Richieste.Find(id);
            if (richiesta.IdTipoStatus != 1)
            {
                return RedirectToAction("Index");
            }


            db.Richieste.Remove(richiesta);
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
