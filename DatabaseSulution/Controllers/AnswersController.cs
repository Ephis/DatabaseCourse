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
    public class AnswersController : Controller
    {
        private DbContext db = new DbContext();

        // GET: Answers
        public ActionResult Index()
        {
            var answer = db.Answer.Include(a => a.PrefabAnswers).Include(a => a.Question).Include(a => a.Survey).Include(a => a.SurveyUser);
            return View(answer.ToList());
        }

        // GET: Answers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = db.Answer.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        // GET: Answers/Create
        public ActionResult Create()
        {
            ViewBag.prefab_answer = new SelectList(db.PrefabAnswers, "id", "text");
            ViewBag.question_id = new SelectList(db.Question, "id", "text");
            ViewBag.survey_id = new SelectList(db.Survey, "id", "title");
            ViewBag.user_id = new SelectList(db.SurveyUser, "id", "email");
            return View();
        }

        // POST: Answers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,bool_a,answer1,prefab_answer,survey_id,question_id,user_id")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                db.Answer.Add(answer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.prefab_answer = new SelectList(db.PrefabAnswers, "id", "text", answer.prefab_answer);
            ViewBag.question_id = new SelectList(db.Question, "id", "text", answer.question_id);
            ViewBag.survey_id = new SelectList(db.Survey, "id", "title", answer.survey_id);
            ViewBag.user_id = new SelectList(db.SurveyUser, "id", "email", answer.user_id);
            return View(answer);
        }

        // GET: Answers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = db.Answer.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            ViewBag.prefab_answer = new SelectList(db.PrefabAnswers, "id", "text", answer.prefab_answer);
            ViewBag.question_id = new SelectList(db.Question, "id", "text", answer.question_id);
            ViewBag.survey_id = new SelectList(db.Survey, "id", "title", answer.survey_id);
            ViewBag.user_id = new SelectList(db.SurveyUser, "id", "email", answer.user_id);
            return View(answer);
        }

        // POST: Answers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,bool_a,answer1,prefab_answer,survey_id,question_id,user_id")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(answer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.prefab_answer = new SelectList(db.PrefabAnswers, "id", "text", answer.prefab_answer);
            ViewBag.question_id = new SelectList(db.Question, "id", "text", answer.question_id);
            ViewBag.survey_id = new SelectList(db.Survey, "id", "title", answer.survey_id);
            ViewBag.user_id = new SelectList(db.SurveyUser, "id", "email", answer.user_id);
            return View(answer);
        }

        // GET: Answers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = db.Answer.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        // POST: Answers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Answer answer = db.Answer.Find(id);
            db.Answer.Remove(answer);
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
