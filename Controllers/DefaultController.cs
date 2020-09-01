using CustomerReport.Models;
using CustomerReport.Models.Common;
using CustomerReport.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerReport.Controllers
{
    public class DefaultController : Controller
    {
  //      private readonly IGetData _GetDataRepository;

        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        #region Comment
        //public ActionResult DataList()
        //{
        //    CustomerDBEntities DB = new CustomerDBEntities();
        //    #region
        //    //var datajoins = from P in DB.Payments
        //    //                join I in DB.Invoices on P.Invoice_No equals I.Invoice_No
        //    //                join C in DB.Customers on I.Customer_No equals C.Customer_No
        //    //                select new {
        //    //                    C.Customer_No,
        //    //                    C.Customer_Name,
        //    //                    I.Invoice_No,
        //    //                    I.Invoice_Amount,
        //    //                    I.Invoice_Date,
        //    //                    P.Payment_Date,
        //    //                    P.Payment_Amount,

        //    //                };
        //    #endregion
        //    List<Getdata> data = DB.Customers.ToList()
        //    return View(data);

        //}
        #endregion
        [HttpGet]
        public ActionResult GetList()
        {
            Getdata gd = new Getdata();
            IEnumerable<ReportData> data = gd.GetReport();
            //  return View(data);
            return Json(new{data = data}, JsonRequestBehavior.AllowGet);

        }

        #region Old
        //public JsonResult GetList()
        //{
        //    Getdata gd = new Getdata();
        //    return Json(gd.GetReport(), JsonRequestBehavior.AllowGet);
        //}

        //public object GetReport()
        //{
        //    DemoResponse d = new DemoResponse();
        //    Getdata report = new Getdata();
        //    List<ReportData> lst = report.GetReport();

        //    if (lst.Count == 0)
        //    {
        //        d.ReqStatus = "FAIL";
        //        d.ReqMsg = "Unable to retrive product list";
        //        d.ResponseData = null;
        //    }
        //    else
        //    {
        //        d.ReqStatus = "PASS";
        //        d.ReqMsg = "Product List Retrived";
        //        d.ResponseData = lst;
        //    }
        //    return d;

        //}
        #endregion
    }
    #region Old

    public class DemoResponse
    {
        public string ReqStatus { get; set; }
        public string ReqMsg { get; set; }
        public object ResponseData { get; set; }
    }
    #endregion

}