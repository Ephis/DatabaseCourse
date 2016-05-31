using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatabaseSulution;

namespace DatabaseSulution.Controllers
{
    public class PrefabAnswersController : Controller
    {
        private DbContext db = new DbContext();

        // GET: PrefabAnswers
        public ActionResult Index()
        {
            var prefabAnswers = db.PrefabAnswers.Include(p => p.Question);
            return View(prefabAnswers.ToList());
        }

        // GET: PrefabAnswers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrefabAnswers prefabAnswers = db.PrefabAnswers.Find(id);
            if (prefabAnswers == null)
            {
                return HttpNotFound();
            }
            return View(prefabAnswers);
        }

        // GET: PrefabAnswers/Create
        public ActionResult Create()
        {
            ViewBag.question_id = new SelectList(db.Question, "id", "text");
            return View();
        }

        // POST: PrefabAnswers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,text,question_id")] PrefabAnswers prefabAnswers)
        {
            if (ModelState.IsValid)
            {
                db.PrefabAnswers.Add(prefabAnswers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.question_id = new SelectList(db.Question, "id", "text", prefabAnswers.question_id);
            return View(prefabAnswers);
        }

        // GET: PrefabAnswers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrefabAnswers prefabAnswers = db.PrefabAnswers.Find(id);
            if (prefabAnswers == null)
            {
                return HttpNotFound();
            }
            ViewBag.question_id = new SelectList(db.Question, "id", "text", prefabAnswers.question_id);
            return View(prefabAnswers);
        }

        // POST: PrefabAnswers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,text,question_id")] PrefabAnswers prefabAnswers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prefabAnswers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.question_id = new SelectList(db.Question, "id", "text", prefabAnswers.question_id);
            return View(prefabAnswers);
        }

        // GET: PrefabAnswers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrefabAnswers prefabAnswers = db.PrefabAnswers.Find(id);
            if (prefabAnswers == null)
            {
                return HttpNotFound();
            }
            return View(prefabAnswers);
        }

        // POST: PrefabAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrefabAnswers prefabAnswers = db.PrefabAnswers.Find(id);
            db.PrefabAnswers.Remove(prefabAnswers);
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
