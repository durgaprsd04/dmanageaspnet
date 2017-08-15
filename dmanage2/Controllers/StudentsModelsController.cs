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
    public class StudentsModelsController : Controller
    {
        private dmanage2Context db = new dmanage2Context();

        // GET: StudentsModels
        public ActionResult Index()
        {
            var studentsModels = db.StudentsModels.Include(s => s.Department);
            return View(studentsModels.ToList());
        }

        // GET: StudentsModels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentsModel studentsModel = db.StudentsModels.Find(id);
            if (studentsModel == null)
            {
                return HttpNotFound();
            }
            return View(studentsModel);
        }

        // GET: StudentsModels/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentsModel = new SelectList(db.DepartmentsModels, "DepartmentId", "DepartmentName");
            return View();
        }

        // POST: StudentsModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RollNumber,Name,DepartmentsModel")] StudentsModel studentsModel)
        {
            if (ModelState.IsValid)
            {
                studentsModel.Id = Guid.NewGuid();
                db.StudentsModels.Add(studentsModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentsModel = new SelectList(db.DepartmentsModels, "DepartmentId", "DepartmentName", studentsModel.DepartmentsModel);
            return View(studentsModel);
        }

        // GET: StudentsModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentsModel studentsModel = db.StudentsModels.Find(id);
            if (studentsModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentsModel = new SelectList(db.DepartmentsModels, "DepartmentId", "DepartmentName", studentsModel.DepartmentsModel);
            return View(studentsModel);
        }

        // POST: StudentsModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RollNumber,Name,DepartmentsModel")] StudentsModel studentsModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentsModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentsModel = new SelectList(db.DepartmentsModels, "DepartmentId", "DepartmentName", studentsModel.DepartmentsModel);
            return View(studentsModel);
        }

        // GET: StudentsModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentsModel studentsModel = db.StudentsModels.Find(id);
            if (studentsModel == null)
            {
                return HttpNotFound();
            }
            return View(studentsModel);
        }

        // POST: StudentsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            StudentsModel studentsModel = db.StudentsModels.Find(id);
            db.StudentsModels.Remove(studentsModel);
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
