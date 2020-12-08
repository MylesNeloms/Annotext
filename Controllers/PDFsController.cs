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
    public class PDFsController : Controller
    {
        public static string filename = "";

        private AnnoContext db = new AnnoContext();

        //GET: PDFs
        [Authorize]
        public ActionResult Index()
        {
            return View(db.PDFs.ToList());
        }

        [Authorize]// GET: PDFs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PDF pDF = db.PDFs.Find(id);
            if (pDF == null)
            {
                return HttpNotFound();
            }

            // filename = pDF.filename.ToString();
            TempData["file"] = pDF.filename;
            TempData.Keep("file"); //filename;


            return RedirectToAction("Create", "Annotations");
        }


       


        // GET: PDFs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PDFs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,filename")] PDF pDF)
        {
            if (ModelState.IsValid)
            {
                db.PDFs.Add(pDF);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pDF);
        }

        // GET: PDFs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PDF pDF = db.PDFs.Find(id);
            if (pDF == null)
            {
                return HttpNotFound();
            }
            return View(pDF);
        }

        // POST: PDFs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,filename")] PDF pDF)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pDF).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pDF);
        }

        // GET: PDFs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PDF pDF = db.PDFs.Find(id);
            if (pDF == null)
            {
                return HttpNotFound();
            }
            return View(pDF);
        }

        // POST: PDFs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PDF pDF = db.PDFs.Find(id);
            db.PDFs.Remove(pDF);
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


        //public ActionResult RenderView()
        //{

        //    return PartialView("AnnotationForm");
        //}

        //public ActionResult ViewPDF()
        //{
        //    string embed = "<object data=\"{0}\" type=\"application/pdf\" width=\"500px\" height=\"300px\">";
        //    embed += "If you are unable to view file, you can download from <a href = \"{0}\">here</a>";
        //    embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
        //    embed += "</object>";
        //    TempData["Embed"] = string.Format(embed, VirtualPathUtility.ToAbsolute("~/Files/Mudassar_Khan.pdf"));

        //    return RedirectToAction("Details");
        //}

    }
}
