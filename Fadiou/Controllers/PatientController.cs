using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fadiou.Models;

namespace Fadiou.Controllers
{
    public class PatientController : Controller
    {
        private bdFadiouContext db = new bdFadiouContext();

        // GET: PatientViewModels
        public ActionResult Index()
        {
            return View(getListPatient().ToList());
        }

        //// GET: PatientViewModels/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    PatientViewModel patientViewModel = db.PatientViewModels.Find(id);
        //    if (patientViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(patientViewModel);
        //}

        //// GET: PatientViewModels/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: PatientViewModels/Create
        //// Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        //// plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "idPers,nomPers,prenomPers,adressePers,dateNaissancePers,sexePers,cniPers,situationMatPers,emailPers,telPers,poidsPatient,taillePatient,groupeSanguinPatient,ProfessionPatient")] PatientViewModel patientViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.PatientViewModels.Add(patientViewModel);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(patientViewModel);
        //}

        //// GET: PatientViewModels/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    PatientViewModel patientViewModel = db.PatientViewModels.Find(id);
        //    if (patientViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(patientViewModel);
        //}

        //// POST: PatientViewModels/Edit/5
        //// Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        //// plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "idPers,nomPers,prenomPers,adressePers,dateNaissancePers,sexePers,cniPers,situationMatPers,emailPers,telPers,poidsPatient,taillePatient,groupeSanguinPatient,ProfessionPatient")] PatientViewModel patientViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(patientViewModel).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(patientViewModel);
        //}

        //// GET: PatientViewModels/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    PatientViewModel patientViewModel = db.PatientViewModels.Find(id);
        //    if (patientViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(patientViewModel);
        //}

        //// POST: PatientViewModels/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    PatientViewModel patientViewModel = db.PatientViewModels.Find(id);
        //    db.PatientViewModels.Remove(patientViewModel);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        public List<PatientViewModel> getListPatient()
        {
            var listPersonne = db.personnes.ToList();
            List<PatientViewModel> lesPatients = new List<PatientViewModel>();
            foreach (var p in listPersonne)
            {
               PatientViewModel m = new PatientViewModel();
                m.idPers = p.idPers;
                m.nomPers = p.nomPers;
                m.prenomPers = p.prenomPers;
                m.adressePers = p.adressePers;
                m.cniPers = p.cniPers;
                m.dateNaissancePers = p.dateNaissancePers;
                m.emailPers = p.emailPers;
                m.sexePers = p.sexePers;
                m.situationMatPers = p.situationMatPers;
                m.telPers = p.telPers;
                m.ProfessionPatient = db.patients.Find(p.idPers).ProfessionPatient;
   
                m.groupeSanguinPatient = db.patients.Find(p.idPers).groupeSanguinPatient;
              
                lesPatients.Add(m);
            }
            return (lesPatients);
        

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
