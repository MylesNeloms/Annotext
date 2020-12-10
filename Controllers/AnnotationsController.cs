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
       // public string file = PDFsController.filename;
       // private int index = 0;
        private AnnoContext db = new AnnoContext();

        // GET: Annotations
        public ActionResult Index()
        {
           //TempData["file"] = file;
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

            
                ViewBag.file = TempData["file"];
            TempData.Keep("file");
               
            return View("Create");
        }


        // POST: Annotations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AnnotationId,content,pageNum,paragraph")] Annotation annotation)
        {
            annotation.VoteVal = 0;
            annotation.filename = TempData["file"].ToString();//=file;
            annotation.author = this.User.Identity.Name.ToString();
          // if (ModelState.IsValid)
           // {

                db.annotations.Add(annotation);
                db.SaveChanges();
                ModelState.Clear();
  
          //  }
            ViewBag.file = TempData["file"];// = file;
            TempData.Keep("file");
            
            ViewBag.filename = new SelectList(db.PDFs, "filename", "filename", annotation.filename);
            return View();
        }


        public ActionResult GoToComments(int? id)
        {
            TempData["content"] =  db.annotations.Find(id).content;
            TempData.Keep("content");
            TempData.Keep("file");
            TempData["Annotation"] = id;
            TempData.Keep("Annotation");
            return RedirectToAction("Create", "Comments");
        }
            // GET: Annotations/Edit/5
            public ActionResult Edit(int? id)
        {
            TempData.Keep("file");
            TempData["Annotation"] = db.annotations.Find(id).AnnotationId;
            TempData.Keep("Annotation");
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
        public ActionResult Edit([Bind(Include = "AnnotationId,VoteVal")] Annotation annotation)
        {
            TempData.Keep("file");
            TempData.Keep("Annotation");
            ViewBag.wtf = annotation.VoteVal;
            var an = db.annotations.Find(int.Parse(TempData["Annotation"].ToString()));
            an.VoteVal = annotation.VoteVal;
            //if (ModelState.IsValid)
            //{
                db.Entry(an).State = EntityState.Modified;
             db.SaveChanges();
                return RedirectToAction("Create");
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
