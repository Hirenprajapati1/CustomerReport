using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerReport.Models.Common
{
    public class ReportData
    {
        public int No { get; set; }
        //public int YearInvoice { get; set; }
        //public int MonthInvoice { get; set; }
        //public int YearPay { get; set; }
        //public int MonthPay { get; set; }
        public DateTime DateOfMonthInvoice { get; set; }
        public DateTime DateOfMonthPay { get; set; }
        public DateTime DateOfMonth { get; set; }

        public string MonthYear { get; set; }

        //public DateTime MonthInvoice { get; set; }
        //public DateTime MonthPayment { get; set; }
        public string CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public int NoOfInvoices { get; set; }
        public int Sales { get; set; }
        public int PaymentCollection { get; set; }

    }
}