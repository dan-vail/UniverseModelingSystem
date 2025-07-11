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
    public class MajorWorldCitiesController : Controller
    {
        private Entities db = new Entities();

        // GET: MajorWorldCities
        public async Task<ActionResult> Index()
        {
            return View(await db.MajorWorldCities.ToListAsync());
        }

        // GET: MajorWorldCities/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MajorWorldCity majorWorldCity = await db.MajorWorldCities.FindAsync(id);
            if (majorWorldCity == null)
            {
                return HttpNotFound();
            }
            return View(majorWorldCity);
        }

        // GET: MajorWorldCities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MajorWorldCities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,City,City_Ascii,Latitude,Longitude,Country,CountryISO2,CountryISO3,AdministrativeName,Capital,Population,IconPath")] MajorWorldCity majorWorldCity)
        {
            if (ModelState.IsValid)
            {
                db.MajorWorldCities.Add(majorWorldCity);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(majorWorldCity);
        }

        // GET: MajorWorldCities/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MajorWorldCity majorWorldCity = await db.MajorWorldCities.FindAsync(id);
            if (majorWorldCity == null)
            {
                return HttpNotFound();
            }
            return View(majorWorldCity);
        }

        // POST: MajorWorldCities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,City,City_Ascii,Latitude,Longitude,Country,CountryISO2,CountryISO3,AdministrativeName,Capital,Population,IconPath")] MajorWorldCity majorWorldCity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(majorWorldCity).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(majorWorldCity);
        }

        // GET: MajorWorldCities/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MajorWorldCity majorWorldCity = await db.MajorWorldCities.FindAsync(id);
            if (majorWorldCity == null)
            {
                return HttpNotFound();
            }
            return View(majorWorldCity);
        }

        // POST: MajorWorldCities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MajorWorldCity majorWorldCity = await db.MajorWorldCities.FindAsync(id);
            db.MajorWorldCities.Remove(majorWorldCity);
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
