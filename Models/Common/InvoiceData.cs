using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerReport.Models.Common
{
    public class InvoiceData
    {
        public string Invoice_No { get; set; }
        public string Customer_No { get; set; }
        public System.DateTime Invoice_Date { get; set; }
        public int Invoice_Amount { get; set; }
        public Nullable<System.DateTime> Payment_Due_Date { get; set; }
    }
}