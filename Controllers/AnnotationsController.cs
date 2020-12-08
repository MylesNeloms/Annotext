using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProject.DataContexts;
using FinalProject.Models;
using System.Security.Claims;

namespace FinalProject.Controllers
{
    public class AnnotationsController : Controller
    {
        public string file = PDFsController.filename;
        private int index = 0;
        private AnnoContext db = new AnnoContext();

        // GET: Annotations
        public ActionResult Index()
        {
           TempData["file"] = file;
            ViewBag.ShowNavBar = false;
            return View(db.annotations.ToList());
        }

        // GET: Annotations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Annotation annotation = db.annotations.Find(id);
            if (annotation == null)
            {
                return HttpNotFound();
            }
            return View(annotation);
        }

        [Authorize]
        // GET: Annotations/Create
        public ActionResult Create()
        {
            ViewBag.filename = new SelectList(db.PDFs, "filename", "filename");

            
                ViewBag.file = file;
            
               
            return View("Create");
        }


        // POST: Annotations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,content,pageNum,paragraph")] Annotation annotation)
        {
            annotation.VoteVal = 0;
            annotation.filename = file;
            annotation.author = this.User.Identity.Name.ToString();
           if (ModelState.IsValid)
            {

                db.annotations.Add(annotation);
                db.SaveChanges();
                ModelState.Clear();
  
            }
            ViewBag.file = file;

            
            ViewBag.filename = new SelectList(db.PDFs, "filename", "filename", annotation.filename);
            return View();
        }



        // GET: Annotations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Annotation annotation = db.annotations.Find(id);
            if (annotation == null)
            {
                return HttpNotFound();
            }
            return View(annotation);
        }

        // POST: Annotations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,VoteVal")] Annotation annotation)
        {
            Annotation an = db.annotations.Find(annotation.id);
            an.VoteVal = annotation.VoteVal;
            //if (ModelState.IsValid)
            //{
                db.Entry(an).State = EntityState.Modified;
             db.SaveChanges();
                return RedirectToAction("Index","PDFs");
            //}
          // return View(an);
        }

        // GET: Annotations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Annotation annotation = db.annotations.Find(id);
            if (annotation == null)
            {
                return HttpNotFound();
            }
            return View(annotation);
        }

        // POST: Annotations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Annotation annotation = db.annotations.Find(id);
            db.annotations.Remove(annotation);
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
