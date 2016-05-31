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
    public class QuestionTriggersController : Controller
    {
        private DbContext db = new DbContext();

        // GET: QuestionTriggers
        public ActionResult Index()
        {
            return View(db.QuestionTrigger.ToList());
        }

        // GET: QuestionTriggers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionTrigger questionTrigger = db.QuestionTrigger.Find(id);
            if (questionTrigger == null)
            {
                return HttpNotFound();
            }
            return View(questionTrigger);
        }

        // GET: QuestionTriggers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuestionTriggers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,answer,jump_to")] QuestionTrigger questionTrigger)
        {
            if (ModelState.IsValid)
            {
                db.QuestionTrigger.Add(questionTrigger);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(questionTrigger);
        }

        // GET: QuestionTriggers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionTrigger questionTrigger = db.QuestionTrigger.Find(id);
            if (questionTrigger == null)
            {
                return HttpNotFound();
            }
            return View(questionTrigger);
        }

        // POST: QuestionTriggers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,answer,jump_to")] QuestionTrigger questionTrigger)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questionTrigger).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(questionTrigger);
        }

        // GET: QuestionTriggers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionTrigger questionTrigger = db.QuestionTrigger.Find(id);
            if (questionTrigger == null)
            {
                return HttpNotFound();
            }
            return View(questionTrigger);
        }

        // POST: QuestionTriggers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuestionTrigger questionTrigger = db.QuestionTrigger.Find(id);
            db.QuestionTrigger.Remove(questionTrigger);
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
