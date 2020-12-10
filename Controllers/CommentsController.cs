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

namespace FinalProject.Controllers
{
    public class CommentsController : Controller
    {
        private AnnoContext db = new AnnoContext();

        // GET: Comments
        public ActionResult Index()
        {
            ViewBag.ShowNavBar = false;
            return View(db.comments.ToList());
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            TempData.Keep("content");
            ViewBag.Content = TempData["content"];
            TempData.Keep("Annotation");
            TempData.Keep("file");
            ViewBag.file = TempData["file"];
            ViewBag.use = db.annotations.Find(int.Parse(TempData["Annotation"].ToString())).author;
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentId,content")] Comment comment)
        {
            // if (ModelState.IsValid)
            //{
            TempData.Keep("content");
            ViewBag.Content = TempData["content"];
            TempData.Keep("file");
            TempData.Keep("Annotation");
                comment.author = this.User.Identity.Name.ToString();
                comment.VoteVal = 0;
            comment.AnnotationId = TempData["Annotation"].ToString();
                db.comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Create");
           // }

            
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            //Annotation an = db.annotations.Find(int.Parse(TempData["Annotation"].ToString()));
            //TempData.Keep("Annotation");
            TempData.Keep("content");
            ViewBag.Content = TempData["content"].ToString();
            TempData["comment"] = db.comments.Find(id).CommentId;
            TempData.Keep("comment");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentId,VoteVal")] Comment com)
        {
            TempData.Keep("content");
            TempData.Keep("comment");
            ViewBag.Content = TempData["content"].ToString();
            TempData.Keep("file");
            Comment comment = db.comments.Find(int.Parse(TempData["comment"].ToString()));
            if(comment != null)
            comment.VoteVal = com.VoteVal;
            //if (ModelState.IsValid)
            //{
            db.Entry(comment).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Create");
            //}
            // return View(an);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.comments.Find(id);
            db.comments.Remove(comment);
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
