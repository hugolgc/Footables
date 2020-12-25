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
    public class JoueursController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: Joueurs
        public ActionResult Index()
        {
            List<Joueur> joueurs = new List<Joueur>();
            Random rand = new Random(DateTime.Now.ToString().GetHashCode());

            int count = db.Joueur.Count();

            for (int i = 0; i < count; i++)
            {
                joueurs.Add(db.Joueur.Find(rand.Next(0, (count))));
            }

            return View(joueurs.Take(10));
        }

        // GET: Joueurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Joueur joueur = db.Joueur.Find(id);
            if (joueur == null)
            {
                return HttpNotFound();
            }
            return View(joueur);
        }

        // GET: Joueurs/Create
        public ActionResult Create()
        {
            ViewBag.id_equipe = new SelectList(db.Equipe, "Id", "nom");
            ViewBag.id_poste = new SelectList(db.Poste, "Id", "libelle");
            return View();
        }

        // POST: Joueurs/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nom,age,id_equipe,id_poste")] Joueur joueur)
        {
            if (ModelState.IsValid)
            {
                db.Joueur.Add(joueur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_equipe = new SelectList(db.Equipe, "Id", "nom", joueur.id_equipe);
            ViewBag.id_poste = new SelectList(db.Poste, "Id", "libelle", joueur.id_poste);
            return View(joueur);
        }

        // GET: Joueurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Joueur joueur = db.Joueur.Find(id);
            if (joueur == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_equipe = new SelectList(db.Equipe, "Id", "nom", joueur.id_equipe);
            ViewBag.id_poste = new SelectList(db.Poste, "Id", "libelle", joueur.id_poste);
            return View(joueur);
        }

        // POST: Joueurs/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nom,age,id_equipe,id_poste")] Joueur joueur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(joueur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_equipe = new SelectList(db.Equipe, "Id", "nom", joueur.id_equipe);
            ViewBag.id_poste = new SelectList(db.Poste, "Id", "libelle", joueur.id_poste);
            return View(joueur);
        }

        // GET: Joueurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Joueur joueur = db.Joueur.Find(id);
            if (joueur == null)
            {
                return HttpNotFound();
            }
            return View(joueur);
        }

        // POST: Joueurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Joueur joueur = db.Joueur.Find(id);
            db.Joueur.Remove(joueur);
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
