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
    public class StatJoueursController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: StatJoueurs
        public ActionResult Index()
        {
            var statJoueur = db.StatJoueur.Include(s => s.Joueur).Include(s => s.Match);
            return View(statJoueur.ToList());
        }

        // GET: StatJoueurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatJoueur statJoueur = db.StatJoueur.Find(id);
            if (statJoueur == null)
            {
                return HttpNotFound();
            }
            return View(statJoueur);
        }

        // GET: StatJoueurs/Create
        public ActionResult Create()
        {
            ViewBag.id_joueur = new SelectList(db.Joueur, "Id", "nom");
            ViewBag.id_match = new SelectList(db.Match, "Id", "lieu");
            return View();
        }

        // POST: StatJoueurs/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,but,decisive,tir,cadre,interception,tacle,faute,jaune,rouge,arret,encaisse,id_joueur,id_match")] StatJoueur statJoueur)
        {
            if (ModelState.IsValid)
            {
                db.StatJoueur.Add(statJoueur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_joueur = new SelectList(db.Joueur, "Id", "nom", statJoueur.id_joueur);
            ViewBag.id_match = new SelectList(db.Match, "Id", "lieu", statJoueur.id_match);
            return View(statJoueur);
        }

        // GET: StatJoueurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatJoueur statJoueur = db.StatJoueur.Find(id);
            if (statJoueur == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_joueur = new SelectList(db.Joueur, "Id", "nom", statJoueur.id_joueur);
            ViewBag.id_match = new SelectList(db.Match, "Id", "lieu", statJoueur.id_match);
            return View(statJoueur);
        }

        // POST: StatJoueurs/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,but,decisive,tir,cadre,interception,tacle,faute,jaune,rouge,arret,encaisse,id_joueur,id_match")] StatJoueur statJoueur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statJoueur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_joueur = new SelectList(db.Joueur, "Id", "nom", statJoueur.id_joueur);
            ViewBag.id_match = new SelectList(db.Match, "Id", "lieu", statJoueur.id_match);
            return View(statJoueur);
        }

        // GET: StatJoueurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatJoueur statJoueur = db.StatJoueur.Find(id);
            if (statJoueur == null)
            {
                return HttpNotFound();
            }
            return View(statJoueur);
        }

        // POST: StatJoueurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StatJoueur statJoueur = db.StatJoueur.Find(id);
            db.StatJoueur.Remove(statJoueur);
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
