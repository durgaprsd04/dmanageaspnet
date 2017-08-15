using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dmanage2.Models;
/// <summary>
/// default controller commited
/// </summary>
namespace dmanage2.Controllers
{
    public class CoursesModelsController : Controller
    {
        private dmanage2Context db = new dmanage2Context();

        // GET: CoursesModels
        public ActionResult Index()
        {
            var coursesModels = db.CoursesModels.Include(c => c.coursesModel).Include(c => c.coursetypesmodel).Include(c => c.Department);
            return View(coursesModels.ToList());
        }

        // GET: CoursesModels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoursesModel coursesModel = db.CoursesModels.Find(id);
            if (coursesModel == null)
            {
                return HttpNotFound();
            }
            return View(coursesModel);
        }

        // GET: CoursesModels/Create
        public ActionResult Create()
        {
            ViewBag.CourseIdfk = new SelectList(db.CoursesModels, "CourseId", "CourseName");
            ViewBag.CourseTypeID = new SelectList(db.CourseTypesModels, "Id", "coursename");
            ViewBag.DepartmentId = new SelectList(db.DepartmentsModels, "DepartmentId", "DepartmentName");
            return View();
        }

        // POST: CoursesModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,CourseName,DepartmentId,CourseTypeID,CourseIdfk")] CoursesModel coursesModel)
        {
            if (ModelState.IsValid)
            {
                coursesModel.CourseId = Guid.NewGuid();
                db.CoursesModels.Add(coursesModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseIdfk = new SelectList(db.CoursesModels, "CourseId", "CourseName", coursesModel.CourseIdfk);
            ViewBag.CourseTypeID = new SelectList(db.CourseTypesModels, "Id", "coursename", coursesModel.CourseTypeID);
            ViewBag.DepartmentId = new SelectList(db.DepartmentsModels, "DepartmentId", "DepartmentName", coursesModel.DepartmentId);
            return View(coursesModel);
        }

        // GET: CoursesModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoursesModel coursesModel = db.CoursesModels.Find(id);
            if (coursesModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseIdfk = new SelectList(db.CoursesModels, "CourseId", "CourseName", coursesModel.CourseIdfk);
            ViewBag.CourseTypeID = new SelectList(db.CourseTypesModels, "Id", "coursename", coursesModel.CourseTypeID);
            ViewBag.DepartmentId = new SelectList(db.DepartmentsModels, "DepartmentId", "DepartmentName", coursesModel.DepartmentId);
            return View(coursesModel);
        }

        // POST: CoursesModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,CourseName,DepartmentId,CourseTypeID,CourseIdfk")] CoursesModel coursesModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coursesModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseIdfk = new SelectList(db.CoursesModels, "CourseId", "CourseName", coursesModel.CourseIdfk);
            ViewBag.CourseTypeID = new SelectList(db.CourseTypesModels, "Id", "coursename", coursesModel.CourseTypeID);
            ViewBag.DepartmentId = new SelectList(db.DepartmentsModels, "DepartmentId", "DepartmentName", coursesModel.DepartmentId);
            return View(coursesModel);
        }

        // GET: CoursesModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoursesModel coursesModel = db.CoursesModels.Find(id);
            if (coursesModel == null)
            {
                return HttpNotFound();
            }
            return View(coursesModel);
        }

        // POST: CoursesModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CoursesModel coursesModel = db.CoursesModels.Find(id);
            db.CoursesModels.Remove(coursesModel);
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
