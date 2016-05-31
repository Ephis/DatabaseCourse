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
    public class QuestionSettingsController : Controller
    {
        private DbContext db = new DbContext();

        // GET: QuestionSettings
        public ActionResult Index()
        {
            var questionSettings = db.QuestionSettings.Include(q => q.QuestionTrigger).Include(q => q.QuestionType);
            return View(questionSettings.ToList());
        }

        // GET: QuestionSettings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionSettings questionSettings = db.QuestionSettings.Find(id);
            if (questionSettings == null)
            {
                return HttpNotFound();
            }
            return View(questionSettings);
        }

        // GET: QuestionSettings/Create
        public ActionResult Create()
        {
            ViewBag.trigger_id = new SelectList(db.QuestionTrigger, "id", "id");
            ViewBag.question_type = new SelectList(db.QuestionType, "id", "typename");
            return View();
        }

        // POST: QuestionSettings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,a_amount,question_type,trigger_id")] QuestionSettings questionSettings)
        {
            if (ModelState.IsValid)
            {
                db.QuestionSettings.Add(questionSettings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.trigger_id = new SelectList(db.QuestionTrigger, "id", "id", questionSettings.trigger_id);
            ViewBag.question_type = new SelectList(db.QuestionType, "id", "typename", questionSettings.question_type);
            return View(questionSettings);
        }

        // GET: QuestionSettings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionSettings questionSettings = db.QuestionSettings.Find(id);
            if (questionSettings == null)
            {
                return HttpNotFound();
            }
            ViewBag.trigger_id = new SelectList(db.QuestionTrigger, "id", "id", questionSettings.trigger_id);
            ViewBag.question_type = new SelectList(db.QuestionType, "id", "typename", questionSettings.question_type);
            return View(questionSettings);
        }

        // POST: QuestionSettings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,a_amount,question_type,trigger_id")] QuestionSettings questionSettings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questionSettings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.trigger_id = new SelectList(db.QuestionTrigger, "id", "id", questionSettings.trigger_id);
            ViewBag.question_type = new SelectList(db.QuestionType, "id", "typename", questionSettings.question_type);
            return View(questionSettings);
        }

        // GET: QuestionSettings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionSettings questionSettings = db.QuestionSettings.Find(id);
            if (questionSettings == null)
            {
                return HttpNotFound();
            }
            return View(questionSettings);
        }

        // POST: QuestionSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuestionSettings questionSettings = db.QuestionSettings.Find(id);
            db.QuestionSettings.Remove(questionSettings);
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
