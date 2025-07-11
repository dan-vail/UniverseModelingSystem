using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniverseObjects.Models;

namespace UniverseObjects.Controllers
{
    public class UniverseObjectGeometriesController : Controller
    {
        private Entities db = new Entities();

        // GET: UniverseObjectGeometries
        public async Task<ActionResult> Index()
        {
            return View(await db.UniverseObjectGeometries.ToListAsync());
        }

        // GET: UniverseObjectGeometries/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniverseObjectGeometry universeObjectGeometry = await db.UniverseObjectGeometries.FindAsync(id);
            if (universeObjectGeometry == null)
            {
                return HttpNotFound();
            }
            return View(universeObjectGeometry);
        }

        // GET: UniverseObjectGeometries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UniverseObjectGeometries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "GeometryID,UniverseObjectID,GeometryType,GeometryComplexity,GeometryRadius,GeometryTube,GeometryArc,GeometryDetail,GeometryLength,GeometryHeight,GeometryRadiusTop,GeometryRadiusBottom,GeometrySteps,GeometryDepth,GeometryInnerRadius,GeometryOuterRadius,GeometryThresholdAngle,GeometrySegments,GeometryXSegments,GeometryYSegments,GeometryHeightSegments,GeometryRadialSegments,GeometryTubularSegnments,GeometryCapSegments,GeometryThetaSegments,GeometryPhiSegments,GeometryBevelSegments,GeometryBevelSize,GeometryBevelOffset,GeometryBevelThickness,GeometryPhiStart,GeometryPhiEnd,GeometryThetaStart,GeometryThetaEnd,GeometryThetaLength,GeometryOpenEnded,GeometryOrigin,GeometryP,GeometryQ")] UniverseObjectGeometry universeObjectGeometry)
        {
            if (ModelState.IsValid)
            {
                db.UniverseObjectGeometries.Add(universeObjectGeometry);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(universeObjectGeometry);
        }

        // GET: UniverseObjectGeometries/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniverseObjectGeometry universeObjectGeometry = await db.UniverseObjectGeometries.FindAsync(id);
            if (universeObjectGeometry == null)
            {
                return HttpNotFound();
            }
            return View(universeObjectGeometry);
        }

        // POST: UniverseObjectGeometries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "GeometryID,UniverseObjectID,GeometryType,GeometryComplexity,GeometryRadius,GeometryTube,GeometryArc,GeometryDetail,GeometryLength,GeometryHeight,GeometryRadiusTop,GeometryRadiusBottom,GeometrySteps,GeometryDepth,GeometryInnerRadius,GeometryOuterRadius,GeometryThresholdAngle,GeometrySegments,GeometryXSegments,GeometryYSegments,GeometryHeightSegments,GeometryRadialSegments,GeometryTubularSegnments,GeometryCapSegments,GeometryThetaSegments,GeometryPhiSegments,GeometryBevelSegments,GeometryBevelSize,GeometryBevelOffset,GeometryBevelThickness,GeometryPhiStart,GeometryPhiEnd,GeometryThetaStart,GeometryThetaEnd,GeometryThetaLength,GeometryOpenEnded,GeometryOrigin,GeometryP,GeometryQ")] UniverseObjectGeometry universeObjectGeometry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(universeObjectGeometry).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(universeObjectGeometry);
        }

        // GET: UniverseObjectGeometries/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniverseObjectGeometry universeObjectGeometry = await db.UniverseObjectGeometries.FindAsync(id);
            if (universeObjectGeometry == null)
            {
                return HttpNotFound();
            }
            return View(universeObjectGeometry);
        }

        // POST: UniverseObjectGeometries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UniverseObjectGeometry universeObjectGeometry = await db.UniverseObjectGeometries.FindAsync(id);
            db.UniverseObjectGeometries.Remove(universeObjectGeometry);
            await db.SaveChangesAsync();
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
