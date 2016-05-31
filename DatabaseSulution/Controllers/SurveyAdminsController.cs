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
    public class SurveyAdminsController : Controller
    {
        private DbContext db = new DbContext();

        // GET: SurveyAdmins
        public ActionResult Index()
        {
            return View(db.SurveyAdmin.ToList());
        }

        // GET: SurveyAdmins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyAdmin surveyAdmin = db.SurveyAdmin.Find(id);
            if (surveyAdmin == null)
            {
                return HttpNotFound();
            }
            return View(surveyAdmin);
        }

        // GET: SurveyAdmins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SurveyAdmins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,user_name,password,email")] SurveyAdmin surveyAdmin)
        {
            if (ModelState.IsValid)
            {
                db.SurveyAdmin.Add(surveyAdmin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(surveyAdmin);
        }

        // GET: SurveyAdmins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyAdmin surveyAdmin = db.SurveyAdmin.Find(id);
            if (surveyAdmin == null)
            {
                return HttpNotFound();
            }
            return View(surveyAdmin);
        }

        // POST: SurveyAdmins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,user_name,password,email")] SurveyAdmin surveyAdmin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(surveyAdmin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(surveyAdmin);
        }

        // GET: SurveyAdmins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyAdmin surveyAdmin = db.SurveyAdmin.Find(id);
            if (surveyAdmin == null)
            {
                return HttpNotFound();
            }
            return View(surveyAdmin);
        }

        // POST: SurveyAdmins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SurveyAdmin surveyAdmin = db.SurveyAdmin.Find(id);
            db.SurveyAdmin.Remove(surveyAdmin);
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
