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
    public class UniverseObjectsController : Controller
    {
        private Entities db = new Entities();

        // GET: UniverseObjects
        public async Task<ActionResult> Index()
        {
            return View(await db.UniverseObjects.ToListAsync());
        }

        public async Task<ActionResult> _RenderObjectLayout()
        {
            return View();
        }

        public async Task<ActionResult> RenderGalaxy()
        {
            return View();
        }

        public async Task<ActionResult> RenderGLBObject()
        {
            return View();
        }

        public async Task<ActionResult> RenderUniverseObjectControls()
        {
            return View();
        }

        public ActionResult _UniverseObjectLayout()
        {
            return View();
        }

        public ActionResult Home ()
        {
            return View();
        }

        public ActionResult UniverseObjectRendererMenu()
        {
            return View();
        }

        public async Task<ActionResult> RenderObject()
        {
            return View();
        }


        public async Task<ActionResult> RenderStar(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniverseObject universeObject = await db.UniverseObjects.FindAsync(id);
            if (universeObject == null)
            {
                return HttpNotFound();
            }

            JsonResult universeObjectJson = Json(universeObject);
            universeObjectJson.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return universeObjectJson;

        }

        // GET: UniverseObjects/Details/5
        public JsonResult UniverseObjectJSON(long? id)
        {
            if (id == null)
            {
                return null;
            }
            UniverseObject universeObject = new UniverseObject();
            UniverseObject dbUniverseObject = db.UniverseObjects.Find(id);

            JsonResult universeObjectJson = new JsonResult();

            if (dbUniverseObject != null)
            {
                universeObjectJson = Json(dbUniverseObject, JsonRequestBehavior.AllowGet);
            } else
            {
                universeObjectJson = Json(universeObject, JsonRequestBehavior.AllowGet);
            }
            return universeObjectJson;
        }

        public async Task<ActionResult> Renderer(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniverseObject universeObject = await db.UniverseObjects.FindAsync(id);
            if (universeObject == null)
            {
                return HttpNotFound();
            }
            return View(universeObject);
        }

        // GET: UniverseObjects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UniverseObjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UniverseObjectID,UniverseObjectName,UniverseObjectDescription,UniverseObjectPositionVectorX,UniverseObjectPositionVectorY,UniverseObjectPositionVectorZ,UniverseObjectQuaternionVectorX,UniverseObjectQuaternionVectorY,UniverseObjectQuaternionVectorZ,UniverseObjectQuaternionVectorW,UniverseObjectIsSpheroid,UniverseObjectIsPlasma,UniverseObjectHasEventHorizon,UniverseObjectParentID,UniverseObjectOrbitalEccentricity,UniverseObjectAregumentOfPeriapsis,UniverseObjectOrbitalTrueAnomoly,UniverseObjectOrbitalOmegaLongitude,UniverseObjectOrbitalSemiMajorAxis,UniverseObjectOrbitalInclination,UniverseObjectMass,UniverseObjectEquirectangularTextureMapPath,UniverseObjectParentDescription,UniverseObjectEquirectangularVectorDisplacementMapPath,UniverseObjectUseEquirectangularVectorDisplacementMap,UniverseObjectUseEquirectangularTextureMap,UniverseObjectUseEquirectangularVideoTextureMap,UniverseObjectWireframeColor,UniverseObjectHasAtmosphere,UniverseObjectEquirectangularVideoTexturePath,UniverseObjectAtmosphereEquirectangularVectorDisplacementMap,UniverseObjectUseAtmosphereEquirectangularTextureMap,UniverseObjectAtmosphereEquirectangularTextureMapPath,UniverseObjectGLBObjectID,UniverseObjectInitialTemporalArgument,UniverseObjectRendererMaterialID,UniverseObjectGeometryID,UniverseObjectTypeID,UniverseObjectRecordBorn,UniverseObjectUniverseContainerID,UniverseObjectRecordCreatedByUserID,UnierseObjectRecordModified,UniverseObjectRecordModifiedByUserID")] UniverseObject universeObject)
        {
            if (ModelState.IsValid)
            {
                db.UniverseObjects.Add(universeObject);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(universeObject);
        }

        // GET: UniverseObjects/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniverseObject universeObject = await db.UniverseObjects.FindAsync(id);
            if (universeObject == null)
            {
                return HttpNotFound();
            }
            return View(universeObject);
        }

        // POST: UniverseObjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UniverseObjectID,UniverseObjectName,UniverseObjectDescription,UniverseObjectPositionVectorX,UniverseObjectPositionVectorY,UniverseObjectPositionVectorZ,UniverseObjectQuaternionVectorX,UniverseObjectQuaternionVectorY,UniverseObjectQuaternionVectorZ,UniverseObjectQuaternionVectorW,UniverseObjectIsSpheroid,UniverseObjectIsPlasma,UniverseObjectHasEventHorizon,UniverseObjectParentID,UniverseObjectOrbitalEccentricity,UniverseObjectAregumentOfPeriapsis,UniverseObjectOrbitalTrueAnomoly,UniverseObjectOrbitalOmegaLongitude,UniverseObjectOrbitalSemiMajorAxis,UniverseObjectOrbitalInclination,UniverseObjectMass,UniverseObjectEquirectangularTextureMapPath,UniverseObjectParentDescription,UniverseObjectEquirectangularVectorDisplacementMapPath,UniverseObjectUseEquirectangularVectorDisplacementMap,UniverseObjectUseEquirectangularTextureMap,UniverseObjectUseEquirectangularVideoTextureMap,UniverseObjectWireframeColor,UniverseObjectHasAtmosphere,UniverseObjectEquirectangularVideoTexturePath,UniverseObjectAtmosphereEquirectangularVectorDisplacementMap,UniverseObjectUseAtmosphereEquirectangularTextureMap,UniverseObjectAtmosphereEquirectangularTextureMapPath,UniverseObjectGLBObjectID,UniverseObjectInitialTemporalArgument,UniverseObjectRendererMaterialID,UniverseObjectGeometryID,UniverseObjectTypeID,UniverseObjectRecordBorn,UniverseObjectUniverseContainerID,UniverseObjectRecordCreatedByUserID,UnierseObjectRecordModified,UniverseObjectRecordModifiedByUserID")] UniverseObject universeObject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(universeObject).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(universeObject);
        }

        // GET: UniverseObjects/UniverseObjectRenderer/5
        public async Task<ActionResult> UniverseObjectRenderer(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniverseObject universeObject = await db.UniverseObjects.FindAsync(id);
            if (universeObject == null)
            {
                return HttpNotFound();
            }
            return View(universeObject);
        }

        // POST: UniverseObjects/UniverseObjectRenderer/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> UniverseObjectRenderer([Bind(Include = "UniverseObjectID,UniverseObjectName,UniverseObjectDescription,UniverseObjectPositionVectorX,UniverseObjectPositionVectorY,UniverseObjectPositionVectorZ,UniverseObjectQuaternionVectorX,UniverseObjectQuaternionVectorY,UniverseObjectQuaternionVectorZ,UniverseObjectQuaternionVectorW,UniverseObjectIsSpheroid,UniverseObjectIsPlasma,UniverseObjectHasEventHorizon,UniverseObjectParentID,UniverseObjectOrbitalEccentricity,UniverseObjectAregumentOfPeriapsis,UniverseObjectOrbitalTrueAnomoly,UniverseObjectOrbitalOmegaLongitude,UniverseObjectOrbitalSemiMajorAxis,UniverseObjectOrbitalInclination,UniverseObjectMass,UniverseObjectEquirectangularTextureMapPath,UniverseObjectParentDescription,UniverseObjectEquirectangularVectorDisplacementMapPath,UniverseObjectUseEquirectangularVectorDisplacementMap,UniverseObjectUseEquirectangularTextureMap,UniverseObjectUseEquirectangularVideoTextureMap,UniverseObjectWireframeColor,UniverseObjectHasAtmosphere,UniverseObjectEquirectangularVideoTexturePath,UniverseObjectAtmosphereEquirectangularVectorDisplacementMap,UniverseObjectUseAtmosphereEquirectangularTextureMap,UniverseObjectAtmosphereEquirectangularTextureMapPath,UniverseObjectGLBObjectID,UniverseObjectInitialTemporalArgument,UniverseObjectRendererMaterialID,UniverseObjectGeometryID,UniverseObjectTypeID,UniverseObjectRecordBorn,UniverseObjectUniverseContainerID,UniverseObjectRecordCreatedByUserID,UnierseObjectRecordModified,UniverseObjectRecordModifiedByUserID")] UniverseObject universeObject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(universeObject).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(universeObject);
        }


        // GET: UniverseObjects/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniverseObject universeObject = await db.UniverseObjects.FindAsync(id);
            if (universeObject == null)
            {
                return HttpNotFound();
            }
            return View(universeObject);
        }

        // POST: UniverseObjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            UniverseObject universeObject = await db.UniverseObjects.FindAsync(id);
            db.UniverseObjects.Remove(universeObject);
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
