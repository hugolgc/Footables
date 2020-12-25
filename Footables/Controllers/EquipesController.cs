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
    public partial class MainEquipe
    {
        public int Id
        {
            get;
            set;
        }

        public string Figure
        {
            get;
            set;
        }

        public string Nom
        {
            get;
            set;
        }

        public string Points
        {
            get;
            set;
        }
    }

    public class EquipesController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: Equipes/Ranking
        public JsonResult Ranking()
        {
            /* 
             * Une grosse erreur de sérialisation empêche d'utiliser :
             * db.Equipe.OrderByDescending(e => e.points).ToList();
             * 
             * En utilisant MainEquipe comme alternative à peu près élégante, je récupère
             * uniquement le contenu nécéssaire, et non les autres entités lié à Equipe.
             * 
             * Néanmoins, ça serait avec plaisir d'avoir votre explication ^^
             */

            var equipes = from equipe in db.Equipe
                          select new MainEquipe
                          {
                              Id = equipe.Id,
                              Figure = equipe.figure,
                              Nom = equipe.nom,
                              Points = equipe.points
                          };

            return Json(equipes, JsonRequestBehavior.AllowGet);
        }

        // GET: Equipes
        public ActionResult Index()
        {
            return View(db.Equipe.OrderByDescending(equipe => equipe.points).ToList());
        }

        // GET: Equipes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipe equipe = db.Equipe.Find(id);
            if (equipe == null)
            {
                return HttpNotFound();
            }
            return View(equipe);
        }

        // GET: Equipes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Equipes/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nom,acronyme,points,niveau,figure")] Equipe equipe)
        {
            if (ModelState.IsValid)
            {
                db.Equipe.Add(equipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(equipe);
        }

        // GET: Equipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipe equipe = db.Equipe.Find(id);
            if (equipe == null)
            {
                return HttpNotFound();
            }
            return View(equipe);
        }

        // POST: Equipes/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nom,acronyme,points,niveau,figure")] Equipe equipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(equipe);
        }

        // GET: Equipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipe equipe = db.Equipe.Find(id);
            if (equipe == null)
            {
                return HttpNotFound();
            }
            return View(equipe);
        }

        // POST: Equipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipe equipe = db.Equipe.Find(id);
            db.Equipe.Remove(equipe);
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
