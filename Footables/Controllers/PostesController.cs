using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Footables.Models;

namespace Footables.Controllers
{
    public class PostesController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: Postes
        /*public ActionResult Index()
        {
            return View(db.Poste.ToList());
        }

        // GET: Postes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poste poste = db.Poste.Find(id);
            if (poste == null)
            {
                return HttpNotFound();
            }
            return View(poste);
        }

        // GET: Postes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Postes/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,libelle")] Poste poste)
        {
            if (ModelState.IsValid)
            {
                db.Poste.Add(poste);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(poste);
        }

        // GET: Postes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poste poste = db.Poste.Find(id);
            if (poste == null)
            {
                return HttpNotFound();
            }
            return View(poste);
        }

        // POST: Postes/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,libelle")] Poste poste)
        {
            if (ModelState.IsValid)
            {
                db.Entry(poste).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(poste);
        }

        // GET: Postes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poste poste = db.Poste.Find(id);
            if (poste == null)
            {
                return HttpNotFound();
            }
            return View(poste);
        }

        // POST: Postes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Poste poste = db.Poste.Find(id);
            db.Poste.Remove(poste);
            db.SaveChanges();
            return RedirectToAction("Index");
        }*/

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
