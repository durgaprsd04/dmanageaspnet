using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dmanage2.Models;

namespace dmanage2.Controllers
{
    public class CourseTypesModelsController : Controller
    {
        private dmanage2Context db = new dmanage2Context();

        // GET: CourseTypesModels
        public ActionResult Index()
        {
            return View(db.CourseTypesModels.ToList());
        }

        // GET: CourseTypesModels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseTypesModel courseTypesModel = db.CourseTypesModels.Find(id);
            if (courseTypesModel == null)
            {
                return HttpNotFound();
            }
            return View(courseTypesModel);
        }

        // GET: CourseTypesModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseTypesModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,coursename")] CourseTypesModel courseTypesModel)
        {
            if (ModelState.IsValid)
            {
                courseTypesModel.Id = Guid.NewGuid();
                db.CourseTypesModels.Add(courseTypesModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courseTypesModel);
        }

        // GET: CourseTypesModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseTypesModel courseTypesModel = db.CourseTypesModels.Find(id);
            if (courseTypesModel == null)
            {
                return HttpNotFound();
            }
            return View(courseTypesModel);
        }

        // POST: CourseTypesModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,coursename")] CourseTypesModel courseTypesModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseTypesModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseTypesModel);
        }

        // GET: CourseTypesModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseTypesModel courseTypesModel = db.CourseTypesModels.Find(id);
            if (courseTypesModel == null)
            {
                return HttpNotFound();
            }
            return View(courseTypesModel);
        }

        // POST: CourseTypesModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CourseTypesModel courseTypesModel = db.CourseTypesModels.Find(id);
            db.CourseTypesModels.Remove(courseTypesModel);
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
