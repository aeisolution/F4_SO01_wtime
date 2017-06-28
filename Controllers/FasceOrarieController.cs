using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wtime.Models;
using wtime.Tools;
using wtime.ViewModels;

namespace wtime.Controllers
{
    public class FasceOrarieController : Controller
    {
        private WTimeDBContext db = new WTimeDBContext();

        // -----------------------------------
        // GESTIONE FASCE ORARIE
        [HttpPost]
        public ActionResult Create(FasciaOrariaViewModel fasciaOrariaVM)
        {
            var profiloOrario = db.ProfiliOrari.Find(fasciaOrariaVM.IdProfiloOrario);
            var fasciaOraria = new FasciaOraria
            {
                Codice = fasciaOrariaVM.Codice,
                IdProfiloOrario = fasciaOrariaVM.IdProfiloOrario,
                B1_Inizio_Ora = fasciaOrariaVM.B1_Inizio_Ora,
                B1_Inizio_Minuti = fasciaOrariaVM.B1_Inizio_Minuti,
                B1_Fine_Ora = fasciaOrariaVM.B1_Fine_Ora,
                B1_Fine_Minuti = fasciaOrariaVM.B1_Fine_Minuti,
                B2_Inizio_Ora = fasciaOrariaVM.B2_Inizio_Ora,
                B2_Inizio_Minuti = fasciaOrariaVM.B2_Inizio_Minuti,
                B2_Fine_Ora = fasciaOrariaVM.B2_Fine_Ora,
                B2_Fine_Minuti = fasciaOrariaVM.B2_Fine_Minuti
            };

            profiloOrario.FasceOrarie.Add(fasciaOraria);

            if (ModelState.IsValid)
            {
                db.Entry(profiloOrario).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Details", "ProfiliOrari", 
                new { id = fasciaOrariaVM.IdProfiloOrario });
        }

        public ActionResult Delete(string id)
        {
            var fascia = db.FasceOrarie.Find(id);
            db.FasceOrarie.Remove(fascia);
            db.SaveChanges();

            return RedirectToAction("Details", "ProfiliOrari", new { id = fascia.IdProfiloOrario });
        }


        public ActionResult Edit(string id)
        {
            var fascia = db.FasceOrarie.Find(id);

            var dlOre = viewTool.DropdownOre();
            var dlMinuti = viewTool.DropdownMinuti();

            ViewBag.selectB1_Inizio_Ora = new SelectList(dlOre, "Value", "Text", fascia.B1_Inizio_Ora);
            ViewBag.selectB1_Inizio_Minuti = new SelectList(dlMinuti, "Value", "Text", fascia.B1_Inizio_Minuti);
            ViewBag.selectB1_Fine_Ora = new SelectList(dlOre, "Value", "Text", fascia.B1_Fine_Ora);
            ViewBag.selectB1_Fine_Minuti = new SelectList(dlMinuti, "Value", "Text", fascia.B1_Fine_Minuti);
            ViewBag.selectB2_Inizio_Ora = new SelectList(dlOre, "Value", "Text", fascia.B2_Inizio_Ora);
            ViewBag.selectB2_Inizio_Minuti = new SelectList(dlMinuti, "Value", "Text", fascia.B2_Inizio_Minuti);
            ViewBag.selectB2_Fine_Ora = new SelectList(dlOre, "Value", "Text", fascia.B2_Fine_Ora);
            ViewBag.selectB2_Fine_Minuti = new SelectList(dlMinuti, "Value", "Text", fascia.B2_Fine_Minuti);

            return View(fascia);
        }

        [HttpPost]
        public ActionResult FasciaEdit(FasciaOraria fasciaOraria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fasciaOraria).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Details", "ProfiliOrari", 
                                    new { id = fasciaOraria.IdProfiloOrario });
        }

        // POST: FasceOrarie/Edit/5
        [HttpPost]
        public ActionResult Edit(FasciaOraria fasciaOraria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fasciaOraria).State = EntityState.Modified;
                db.SaveChanges();
                
            }
            return RedirectToAction("Details", "ProfiliOrari", new { id = fasciaOraria.IdProfiloOrario });
        }


    }
}