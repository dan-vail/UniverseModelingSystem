using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web.DynamicData;
using System.Web.Http.Results;
using System.Web.Mvc;
using UniverseObjects.Models;

namespace UniverseObjects.Controllers
{

public class DataColumn
    {
        public int ColumnId { get; set; }
        public string ColumnName { get; set; }
        public string ColumnDataType { get; set; }
        public string ColumnDBDataType { get; set; }
        public string ColumnParentTableName { get; set; }
        public string ColumnValue { get; set; }

    }

        public class FullScreenNavigationItem
    {
        public string Text { get; set; }
        public string url { get; set; }
    }

    public class HomeController : Controller
    {
        private Entities db = new Entities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UniverseObjectCreateObject()
        {
            return View();
        }

        public ActionResult VR()
        {
            return View();
        }

        public ActionResult GetTablesList() 
        {
            string dynamicQuery = "SELECT * FROM sysObjects WHERE type='U'";

            JsonResult sqlQueryResults =
                Json(db.Database.SqlQuery<JsonResult>(dynamicQuery).ToListAsync());

            return sqlQueryResults;

        }

        public ActionResult AutoCRUD(string tablename)
        {
            if (tablename == null)
            {
                tablename = "UniverseObjects";
            }
            var jsonResult = new JsonResult();
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            jsonResult = JSONTableContents(tablename);

            return View(jsonResult);
        }

        public JsonResult JSONTableContents(string tablename)
        {
            if (tablename == null)
            {
                tablename = "UniverseObjects";
            }

            string dynamicQuery = "SELECT * FROM [UniverseObjects].[dbo].[MajorWorldCities]";
            var resultGrid = new List<Dictionary<string, object>>();

            DbConnection dbConnection = db.Database.Connection;
            dbConnection.Open();

            SqlCommand command = new SqlCommand(dynamicQuery, (SqlConnection)dbConnection);

            
            SqlDataReader reader = command.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            while (reader.Read())
            {

            }
            JsonResult jsonResult = Json(schemaTable);
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return jsonResult;
        }

        //    DbConnection dbConnection = db.Database.Connection;
        //    dbConnection.Open();

        //    SqlCommand command = new SqlCommand(dynamicQuery, (SqlConnection)dbConnection);

        //    using (SqlDataReader reader = await command.ExecuteReaderAsync())
        //    {
        //        //dynamic DataStructure = new ExpandoObject();

        //        //DataColumn.AddProperty("ColumnID");
        //        //DataColumn.AddProperty("RowGroupID");
        //        //DataColumn.AddProperty("ColumnName");
        //        //DataColumn.AddProperty("DataType");
        //        //DataColumn.AddProperty("DataBaseDataType");
        //        //DataColumn.AddProperty("ParentTableName");
        //        //DataColumn.AddProperty("ParentDataBaseName");

        //        //dynamic dataGrid = new ExpandoObject();

        //        //dynamic DataRow = new ExpandoObject();
        //        //DataRow.AddProperty("RowGroupID");

        //        List<DataColumn> dataColumns = new List<DataColumn>();
        //        int columnCount = reader.FieldCount;

        //        while (await reader.ReadAsync())
        //        {

        //            for (int i = 0; i < columnCount; i++)
        //            {
        //                DataColumn dataColumn = new DataColumn();
        //                dataColumn.ColumnId = i;
        //                dataColumn.ColumnName = (reader.GetName(i));
        //                dataColumn.ColumnDataType = (reader.GetDataTypeName(i));
        //                dataColumn.ColumnDBDataType =
        //                    (reader.GetProviderSpecificFieldType(i).ToString());
        //                dataColumn.ColumnParentTableName = tablename;
        //                dataColumns.Append(dataColumn);
        //            }

        //        }
        //        return Json(dataColumns);
        //    }

        //}
        ////while (reader.Read()) 
        ////{
        ////    dynamic dataRow = new ExpandoObject();
        ////    for (int i = 0; i < columnCount; i++)
        ////    {
        ////        dataRow.AddProperty(reader.GetValue(i));
        ////    }

        ////}
        ////}


        public ActionResult RenderStar()
        {
            return View();
        }

        public ActionResult DeviceAVObjects()
        {
            return View();
        }

        public ActionResult DeviceOrientation()
        {
            return View();
        }

        public ActionResult UniverseObjectsNavigation(string NavigationType)
        {

            return View();
        }

        public ActionResult PureLayout()
        {
            return View();
        }

        public ActionResult UniverseObjectsFullScreenNavigation()
        {
            return View();
        }

        public ActionResult SunTest()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}