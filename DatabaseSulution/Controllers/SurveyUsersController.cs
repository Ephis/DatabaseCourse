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
    public class SurveyUsersController : Controller
    {
        private DbContext db = new DbContext();

        // GET: SurveyUsers
        public ActionResult Index()
        {
            return View(db.SurveyUser.ToList());
        }

        // GET: SurveyUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyUser surveyUser = db.SurveyUser.Find(id);
            if (surveyUser == null)
            {
                return HttpNotFound();
            }
            return View(surveyUser);
        }

        // GET: SurveyUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SurveyUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,isMale,age,email,marital_status")] SurveyUser surveyUser)
        {
            if (ModelState.IsValid)
            {
                db.SurveyUser.Add(surveyUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(surveyUser);
        }

        // GET: SurveyUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyUser surveyUser = db.SurveyUser.Find(id);
            if (surveyUser == null)
            {
                return HttpNotFound();
            }
            return View(surveyUser);
        }

        // POST: SurveyUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,isMale,age,email,marital_status")] SurveyUser surveyUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(surveyUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(surveyUser);
        }

        // GET: SurveyUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyUser surveyUser = db.SurveyUser.Find(id);
            if (surveyUser == null)
            {
                return HttpNotFound();
            }
            return View(surveyUser);
        }

        // POST: SurveyUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SurveyUser surveyUser = db.SurveyUser.Find(id);
            db.SurveyUser.Remove(surveyUser);
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
