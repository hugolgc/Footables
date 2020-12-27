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
    public class StatEquipesController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: StatEquipes
        /*public ActionResult Index()
        {
            var statEquipe = db.StatEquipe.Include(s => s.Equipe).Include(s => s.Match);
            return View(statEquipe.ToList());
        }

        // GET: StatEquipes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatEquipe statEquipe = db.StatEquipe.Find(id);
            if (statEquipe == null)
            {
                return HttpNotFound();
            }
            return View(statEquipe);
        }

        // GET: StatEquipes/Create
        public ActionResult Create()
        {
            ViewBag.id_equipe = new SelectList(db.Equipe, "Id", "nom");
            ViewBag.id_match = new SelectList(db.Match, "Id", "lieu");
            return View();
        }

        // POST: StatEquipes/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,but,etat,domicile,possession,hors_jeu,corner,id_equipe,id_match")] StatEquipe statEquipe)
        {
            if (ModelState.IsValid)
            {
                db.StatEquipe.Add(statEquipe);
                db.SaveChanges();

                StatJoueur statJoueur = new StatJoueur();
                statJoueur.id_match = statEquipe.id_match;

                List<int> joueurs_id = db.Joueur.Where(joueur => joueur.id_equipe == statEquipe.id_equipe).Select(item => item.Id).ToList();

                foreach (var item in joueurs_id)
                {
                    statJoueur.id_joueur = item;
                    db.StatJoueur.Add(statJoueur);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            ViewBag.id_equipe = new SelectList(db.Equipe, "Id", "nom", statEquipe.id_equipe);
            ViewBag.id_match = new SelectList(db.Match, "Id", "lieu", statEquipe.id_match);
            return View(statEquipe);
        }

        // GET: StatEquipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatEquipe statEquipe = db.StatEquipe.Find(id);
            if (statEquipe == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_equipe = new SelectList(db.Equipe, "Id", "nom", statEquipe.id_equipe);
            ViewBag.id_match = new SelectList(db.Match, "Id", "lieu", statEquipe.id_match);
            return View(statEquipe);
        }

        // POST: StatEquipes/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,but,etat,domicile,possession,hors_jeu,corner,id_equipe,id_match")] StatEquipe statEquipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statEquipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_equipe = new SelectList(db.Equipe, "Id", "nom", statEquipe.id_equipe);
            ViewBag.id_match = new SelectList(db.Match, "Id", "lieu", statEquipe.id_match);
            return View(statEquipe);
        }

        // GET: StatEquipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatEquipe statEquipe = db.StatEquipe.Find(id);
            if (statEquipe == null)
            {
                return HttpNotFound();
            }
            return View(statEquipe);
        }

        // POST: StatEquipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StatEquipe statEquipe = db.StatEquipe.Find(id);
            db.StatEquipe.Remove(statEquipe);
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
