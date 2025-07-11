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
    public class MenuBarBuilder
    {
        public int UIElementID { get; set; }
        public String UIElementHTML { get; set; }
        public String ApplicationUseType { get; set; }
        public String ApplicationPageURL { get; set; }
        public String UIElementContainer { get; set; }
        public int UIElementGroupID { get; set; }
        public int UIElementOrderInGroup { get; set; }
        public String UIElementValue { get; set; }
        public String UIElementInnerHTML { get; set; }
        public String UIElementClassList { get; set; }
        public String UIElementCSSText { get; set; }
        public String UIElementJavascript { get; set; }
        public String UIElementFunctionCall { get; set; }
        public String UIElementFunctionCallEventTrigger { get; set; }
    }


    public class ApplicationUIElementsController : Controller
    {
        private Entities db = new Entities();

        //public Task<ActionResult> MenuBar()
        //{
        //    return MenuBar(Request);
        //}

        public async Task<ActionResult> MenuBar()
        {
            //List<NameValueCollection> nameValueCollection =
            //    Request.QueryString.GetValues('uielementgroupid');

            string[] uiElementGroupIDStrings =
                Request.QueryString.GetValues("uielementgroupid").ToArray();

            bool didQueryStringParse =
                int.TryParse(uiElementGroupIDStrings[0], out int uielementgroupid);

            var asyncTaskResult =
            await MenuBuilder(uielementgroupid);

            asyncTaskResult.JsonRequestBehavior =
                JsonRequestBehavior.AllowGet;

            return View(asyncTaskResult);

        }

        //[HttpPost]
        //public async Task<ActionResult> MenuBar([Bind(Include = "UIElementGroupID")] MenuBarBuilder menuBarBuilder)
        //{
        //    int uielementgroupid =
        //        menuBarBuilder.UIElementGroupID;

        //    var asyncTaskResult =
        //        await MenuBuilder(uielementgroupid);

        //    asyncTaskResult.JsonRequestBehavior =
        //        JsonRequestBehavior.AllowGet;

        //    return View(asyncTaskResult);
        //}
        public async Task<JsonResult> MenuBuilder(int uiElementGroupID)
        {

            var applicationUIElements =
                await db.ApplicationUIElements
                    .Where(u => u.UIElementGroupID == uiElementGroupID)
                    .ToListAsync();

            var menuBarElements = new JsonResult();
            menuBarElements = Json(applicationUIElements);

            return Json(menuBarElements);
        }

        // GET: ApplicationUIElements
        public async Task<ActionResult> Index()
        {
            return View(await db.ApplicationUIElements.ToListAsync());
        }

        // GET: ApplicationUIElements/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUIElement applicationUIElement = await db.ApplicationUIElements.FindAsync(id);
            if (applicationUIElement == null)
            {
                return HttpNotFound();
            }
            return View(applicationUIElement);
        }

        // GET: ApplicationUIElements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationUIElements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UIElementID,UIElementHTMLType,ApplicationUseType,ApplicationPageURL,UIElementContainer,UIElementGroupID,UIElementOrderInGroup,UIElementValue,UIElementInnerHTML,UIElementClassList,UIElementCSSText,UIElementJavascript,UIElementFunctionCall,UIElementFunctionCallEventTrigger")] ApplicationUIElement applicationUIElement)
        {
            if (ModelState.IsValid)
            {
                db.ApplicationUIElements.Add(applicationUIElement);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(applicationUIElement);
        }

        // GET: ApplicationUIElements/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUIElement applicationUIElement = await db.ApplicationUIElements.FindAsync(id);
            if (applicationUIElement == null)
            {
                return HttpNotFound();
            }
            return View(applicationUIElement);
        }

        // POST: ApplicationUIElements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ApplicationUIElement> Edit([Bind(Include = "UIElementID,UIElementHTMLType,ApplicationUseType,ApplicationPageURL,UIElementContainer,UIElementGroupID,UIElementOrderInGroup,UIElementValue,UIElementInnerHTML,UIElementClassList,UIElementCSSText,UIElementJavascript,UIElementFunctionCall,UIElementFunctionCallEventTrigger")] ApplicationUIElement applicationUIElement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationUIElement).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return applicationUIElement;
            }
            return applicationUIElement;
        }

        // GET: ApplicationUIElements/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUIElement applicationUIElement = await db.ApplicationUIElements.FindAsync(id);
            if (applicationUIElement == null)
            {
                return HttpNotFound();
            }
            return View(applicationUIElement);
        }

        // POST: ApplicationUIElements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ApplicationUIElement applicationUIElement = await db.ApplicationUIElements.FindAsync(id);
            db.ApplicationUIElements.Remove(applicationUIElement);
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
