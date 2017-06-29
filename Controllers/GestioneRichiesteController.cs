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
    public class GestioneRichiesteController : Controller
    {
        private WTimeDBContext db = new WTimeDBContext();

        // GET: GestioneRichieste
        public ActionResult Index(int? IdTipoStatus)
        {
            if (IdTipoStatus==null)
                IdTipoStatus = 1;
            
            var richieste = db.Richieste.Where(m => m.IdTipoStatus == IdTipoStatus)
                                        .Include(r => r.Operatore)
                                        .Include(r => r.Status)
                                        .Include(r => r.TipoRichiesta);

            ViewBag.selectStatus = new SelectList(db.TipoStatus,
                                                  "IdTipoStatus",
                                                  "Nome", IdTipoStatus);

            return View(richieste.ToList());
        }

        // GET: GestioneRichieste/Details/5
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

    
        // GET: GestioneRichieste/Edit/5
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
            //ViewBag.IdOperatore = new SelectList(db.Operatori, "Id", "Nome", richiesta.IdOperatore);
            ViewBag.IdTipoStatus = new SelectList(db.TipoStatus, "IdTipoStatus", "Nome", richiesta.IdTipoStatus);
            //ViewBag.IdTipoRichiesta = new SelectList(db.TipoRichieste, "IdTipoRichiesta", "Nome", richiesta.IdTipoRichiesta);
            return View(richiesta);
        }

        // POST: GestioneRichieste/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRichiesta,IdOperatore,DataInizio,DataFine,Giornaliera,OraInizio,MinutiInizio,OraFine,MinutiFine,IdTipoStatus,DataStatus,Note,UsernameValidatore,IdTipoRichiesta")] Richiesta richiesta)
        {
            richiesta.DataStatus = DateTime.Now;
            richiesta.UsernameValidatore = User.Identity.Name;

            if (ModelState.IsValid)
            {
                db.Entry(richiesta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.IdOperatore = new SelectList(db.Operatori, "Id", "Nome", richiesta.IdOperatore);
            ViewBag.IdTipoStatus = new SelectList(db.TipoStatus, "IdTipoStatus", "Nome", richiesta.IdTipoStatus);
            //ViewBag.IdTipoRichiesta = new SelectList(db.TipoRichieste, "IdTipoRichiesta", "Nome", richiesta.IdTipoRichiesta);
            return View(richiesta);
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
