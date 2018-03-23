using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Angulartable.Models;
using System.Data;
using System.Data.SqlClient;
namespace Angulartable.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        database_Access_layer.db dblayer = new database_Access_layer.db();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getrecord()
        {
            DataSet ds = dblayer.Getrecord();
            List<registration> listreg = new List<registration>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                listreg.Add(new registration
                {
                    Sr_no=Convert.ToInt32(dr["Sr_no"]),
                    Email=dr["Email"].ToString(),
                    Password=dr["Password"].ToString(),
                    Name=dr["Name"].ToString(),
                    Address=dr["Address"].ToString(),
                    City=dr["City"].ToString()
                });
            }
            return Json(listreg, JsonRequestBehavior.AllowGet);
        }
    }
}
