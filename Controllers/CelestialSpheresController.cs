using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using UniverseObjects.Models;

namespace CelestialSpheresController.Controllers
{
    public class CelestialSpheresController : Controller
    {
        private Entities db = new Entities();

        public class CelestialSpheresListWithActive
        {
            public List<CelestialSphere> CelestialSpheres { get; set; }
            public CelestialSphere ActiveSphere { get; set; }
        }
        public async Task<ActionResult> CelestialSpheresTable()
        {
            return View(await db.CelestialSpheres.ToListAsync());
        }

        public async Task<ActionResult> RenderPlanet()
        {
            return View(db.CelestialSpheres.ToListAsync());
        }

        public ActionResult CelestialSphereDetailsMenu()
        {
            return View();
        }

        public ActionResult _UniverseObjectRendererLayout()
        { return View(); }

        public async Task<ActionResult> CelestialSphereDetails(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            CelestialSphere celestialSphere = await db.CelestialSpheres.FindAsync(id);
            if (celestialSphere == null)
            {
                return HttpNotFound();
            } else
            {
                return View(celestialSphere);
            }
            //    CelestialSpheresListWithActive celestialSpheresListWithActive =
            //        new CelestialSpheresListWithActive();

            //celestialSpheresListWithActive.CelestialSpheres =
            //    await (db.CelestialSpheres.ToListAsync());

            //celestialSpheresListWithActive.ActiveSphere =
            //    celestialSphere;

            //return View(celestialSpheresListWithActive);
        }



        // GET: CelestialSpheres
        public async Task<ActionResult> Index()
        {
            return View(await db.CelestialSpheres.ToListAsync());
        }

        // GET: CelestialSpheres/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CelestialSphere celestialSphere = await db.CelestialSpheres.FindAsync(id);
            if (celestialSphere == null)
            {
                return HttpNotFound();
            }
            return View(celestialSphere);
        }

        // GET: CelestialSpheres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CelestialSpheres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Description,XCoord,YCoord,ZCoord,TCoord,YSpin,Radius,Mass,GeometryXSegments,GeometryYSegments,MaterialType,MaterialColor,EnvironmentMap,Reflectivity,Blending,Specular,MaterialCombine,TextureMapPath,VideoTexturePath,UseVideoTexture,NormalsMapPath,BumpMapPath,BumpScale,DisplacementMapPath,DisplacementScale,Transparent,Opacity,AlphaTest,DepthTest,Shininess,CastShadow,RecieveShadow,BlendingMode,ParentType,ParentID,DistanceFromParent,OrbitalPlane,OrbitalEccentricity,OrbitalSemiMajorAxis,OrbitalInclination,OrbitalOmegaLongitude,OrbitalArgumentOfPeriapsis,OrbitalTrueAnomoly,ImagePath,WikipediaArticle,InsertionDateTime,IconPath,VideoPath,environmentTexturePath,IsAtmosphere,HasAtmosphere,AtmosphereTexturePath,AtmosphereDisplacementTexturePath,AtmosphereDisplacementScale,AtmosphereRadius,AtmosphereOpacity,AtmosphereVelolcity,LowResolutionTextureMapPath,Enabled")] CelestialSphere celestialSphere)
        {
            if (ModelState.IsValid)
            {
                db.CelestialSpheres.Add(celestialSphere);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(celestialSphere);
        }

        // GET: CelestialSpheres/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CelestialSphere celestialSphere = await db.CelestialSpheres.FindAsync(id);
            if (celestialSphere == null)
            {
                return HttpNotFound();
            }
            return View(celestialSphere);
        }

        // POST: CelestialSpheres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Description,XCoord,YCoord,ZCoord,TCoord,YSpin,Radius,Mass,GeometryXSegments,GeometryYSegments,MaterialType,MaterialColor,EnvironmentMap,Reflectivity,Blending,Specular,MaterialCombine,TextureMapPath,VideoTexturePath,UseVideoTexture,NormalsMapPath,BumpMapPath,BumpScale,DisplacementMapPath,DisplacementScale,Transparent,Opacity,AlphaTest,DepthTest,Shininess,CastShadow,RecieveShadow,BlendingMode,ParentType,ParentID,DistanceFromParent,OrbitalPlane,OrbitalEccentricity,OrbitalSemiMajorAxis,OrbitalInclination,OrbitalOmegaLongitude,OrbitalArgumentOfPeriapsis,OrbitalTrueAnomoly,ImagePath,WikipediaArticle,InsertionDateTime,IconPath,VideoPath,environmentTexturePath,IsAtmosphere,HasAtmosphere,AtmosphereTexturePath,AtmosphereDisplacementTexturePath,AtmosphereDisplacementScale,AtmosphereRadius,AtmosphereOpacity,AtmosphereVelolcity,LowResolutionTextureMapPath,Enabled")] CelestialSphere celestialSphere)
        {
            if (ModelState.IsValid)
            {
                db.Entry(celestialSphere).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(celestialSphere);
        }

        // GET: CelestialSpheres/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CelestialSphere celestialSphere = await db.CelestialSpheres.FindAsync(id);
            if (celestialSphere == null)
            {
                return HttpNotFound();
            }
            return View(celestialSphere);
        }

        // POST: CelestialSpheres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CelestialSphere celestialSphere = await db.CelestialSpheres.FindAsync(id);
            db.CelestialSpheres.Remove(celestialSphere);
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
