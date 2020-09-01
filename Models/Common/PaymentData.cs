using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerReport.Models.Common
{
    public class PaymentData
    {
        public string Payment_No { get; set; }
        public string Invoice_No { get; set; }
        public System.DateTime Payment_Date { get; set; }
        public int Payment_Amount { get; set; }
    }
}