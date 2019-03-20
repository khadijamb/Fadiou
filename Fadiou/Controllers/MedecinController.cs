using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fadiou.Models;
using PagedList;
using PagedList.Mvc;

namespace Fadiou.Controllers
{
    public class MedecinController : Controller
    {
        private bdFadiouContext db = new bdFadiouContext();

        // GET: Medecin
        public ActionResult Index(int? page)

        {
            page = page.HasValue ? page : 1;
            int sizePage = 2;
            var lesMedecins = getListMedecin().ToList();
            return View(lesMedecins.ToPagedList((int) page, sizePage));
        }

        // GET: Medecin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedecinViewModel medecinViewModel = getListMedecin().Where(a => a.idPers == id).FirstOrDefault();
            if (medecinViewModel == null)
            {
                return HttpNotFound();
            }
            return View(medecinViewModel);
        }

        //GET: Medecin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medecin/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPers,nomPers,prenomPers,adressePers,dateNaissancePers,sexePers,cniPers,situationMatPers,emailPers,telPers,idMed,specialteMed")] MedecinViewModel medecinViewModel)
        {
            if (ModelState.IsValid)
            {
                //db.MedecinViewModels.Add(medecinViewModel);
                Personne p = new Personne();
                p.adressePers = medecinViewModel.adressePers;
                p.cniPers = medecinViewModel.cniPers;
                p.dateNaissancePers = medecinViewModel.dateNaissancePers;
                p.emailPers = medecinViewModel.emailPers;
                p.nomPers = medecinViewModel.nomPers;
                p.prenomPers = medecinViewModel.prenomPers;
                p.sexePers = medecinViewModel.sexePers;
                p.situationMatPers = medecinViewModel.situationMatPers;
                p.telPers = medecinViewModel.telPers;
                db.personnes.Add(p);
                Medecin m = new Medecin();
                m.idMed = p.idPers;
                m.specialteMed = medecinViewModel.specialteMed;
                // m.personne = p;
                db.medecins.Add(m);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medecinViewModel);
        }

        // GET: Medecin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedecinViewModel medecinViewModel = getListMedecin().Where(a => a.idPers == id).FirstOrDefault();
            if (medecinViewModel == null)
            {
                return HttpNotFound();
            }
            return View(medecinViewModel);
        }

        // POST: Medecin/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPers,nomPers,prenomPers,adressePers,dateNaissancePers,sexePers,cniPers,situationMatPers,emailPers,telPers,idMed,specialteMed")] MedecinViewModel medecinViewModel)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(medecinViewModel).State = EntityState.Modified;
                //db.SaveChanges();
                Personne p = db.personnes.Find(medecinViewModel.idPers);
                p.adressePers = medecinViewModel.adressePers;
                p.cniPers = medecinViewModel.cniPers;
                p.dateNaissancePers = medecinViewModel.dateNaissancePers;
                p.emailPers = medecinViewModel.emailPers;
                p.nomPers = medecinViewModel.nomPers;
                p.prenomPers = medecinViewModel.prenomPers;
                p.sexePers = medecinViewModel.sexePers;
                p.situationMatPers = medecinViewModel.situationMatPers;
                p.telPers = medecinViewModel.telPers;
                //db.personnes.Add(p);
                Medecin m = new Medecin();
                //m.idMed = p.idPers;
                m.specialteMed = medecinViewModel.specialteMed;
                // m.personne = p;
                //db.medecins.Add(m);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(medecinViewModel);
        }

        // GET: Medecin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedecinViewModel medecinViewModel = getListMedecin().Where(a => a.idPers == id).FirstOrDefault();
            if (medecinViewModel == null)
            {
                return HttpNotFound();
            }
            return View(medecinViewModel);
        }

        // POST: Medecin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedecinViewModel medecinViewModel = getListMedecin().Where(a => a.idPers == id).FirstOrDefault();

            Medecin m = db.medecins.Find(id);
            db.medecins.Remove(m);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public List<MedecinViewModel> getListMedecin()
        {
            var listPersonne = db.medecins.ToList();
            List<MedecinViewModel> lesMedecins = new List<MedecinViewModel>();
            foreach (var x in listPersonne)
            {
                MedecinViewModel m = new MedecinViewModel();
                var i = db.personnes.Find(x.idMed);
                m.idPers = i.idPers;
                m.nomPers = i.nomPers;
                m.prenomPers = i.prenomPers;
                m.adressePers = i.adressePers;
                m.cniPers = i.cniPers;
                m.dateNaissancePers = i.dateNaissancePers;
                m.emailPers = i.emailPers;
                m.sexePers = i.sexePers;
                m.situationMatPers = i.situationMatPers;
                m.telPers = i.telPers;
                m.specialteMed = x.specialteMed;
                lesMedecins.Add(m);
            }
            return (lesMedecins);
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
