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
    public class InfirmierController : Controller
    {
        private bdFadiouContext db = new bdFadiouContext();

        // GET: Infirmier
        public ActionResult Index()
        {
            return View(getListInfirmier().ToList());
        }

        // GET: Infirmier/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InfirmierViewModel infirmierViewModel = getListInfirmier().Where(a => a.idPers == id).FirstOrDefault();
            if (infirmierViewModel == null)
            {
                return HttpNotFound();
            }
            return View(infirmierViewModel);
        }

        // GET: Infirmier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Infirmier/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPers,nomPers,prenomPers,adressePers,dateNaissancePers,sexePers,cniPers,situationMatPers,emailPers,telPers,specialteInf")] InfirmierViewModel infirmierViewModel)
        {
            if (ModelState.IsValid)
            {
                //db.InfirmierViewModels.Add(infirmierViewModel);
                Personne p = new Personne();
                p.adressePers = infirmierViewModel.adressePers;
                p.cniPers = infirmierViewModel.cniPers;
                p.dateNaissancePers = infirmierViewModel.dateNaissancePers;
                p.emailPers = infirmierViewModel.emailPers;
                p.nomPers = infirmierViewModel.nomPers;
                p.prenomPers = infirmierViewModel.prenomPers;
                p.sexePers = infirmierViewModel.sexePers;
                p.situationMatPers = infirmierViewModel.situationMatPers;
                p.telPers = infirmierViewModel.telPers;
                db.personnes.Add(p);
                Infirmier m = new Infirmier();
                m.idInf = p.idPers;
                m.specialteInf = infirmierViewModel.specialteInf;
                // m.personne = p;
                db.infirmiers.Add(m);
                db.SaveChanges();
                return RedirectToAction("Index");
                
            }

            return View(infirmierViewModel);
        }

        // GET: Infirmier/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InfirmierViewModel infirmierViewModel = getListInfirmier().Where(a=>a.idPers==id).FirstOrDefault();
            if (infirmierViewModel == null)
            {
                return HttpNotFound();
            }
            return View(infirmierViewModel);
        }

        //// POST: Infirmier/Edit/5
        //// Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        //// plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "idPers,nomPers,prenomPers,adressePers,dateNaissancePers,sexePers,cniPers,situationMatPers,emailPers,telPers,specialteInf")] InfirmierViewModel infirmierViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(infirmierViewModel).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(infirmierViewModel);
        //}

        //// GET: Infirmier/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    InfirmierViewModel infirmierViewModel = db.InfirmierViewModels.Find(id);
        //    if (infirmierViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(infirmierViewModel);
        //}

        //// POST: Infirmier/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    InfirmierViewModel infirmierViewModel = db.InfirmierViewModels.Find(id);
        //    db.InfirmierViewModels.Remove(infirmierViewModel);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public List<InfirmierViewModel> getListInfirmier()
        {
            var listPersonne = db.infirmiers.ToList();
            List<InfirmierViewModel> lesInfirmiers = new List<InfirmierViewModel>();
            foreach (var x in listPersonne)
            {
                InfirmierViewModel i = new InfirmierViewModel();
                var p = db.personnes.Find(x.idInf);
                i.idPers = p.idPers;
                i.nomPers = p.nomPers;
                i.prenomPers = p.prenomPers;
                i.dateNaissancePers = p.dateNaissancePers;
                i.emailPers = p.emailPers;
                i.cniPers = p.cniPers;
                i.adressePers = p.adressePers;
                i.sexePers = p.sexePers;
                i.situationMatPers = p.situationMatPers;
                i.telPers = p.telPers;
                i.specialteInf = db.infirmiers.Find(p.idPers).specialteInf;
                lesInfirmiers.Add(i);

            }
            return lesInfirmiers;
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
