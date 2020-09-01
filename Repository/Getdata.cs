using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CustomerReport.Models;
using CustomerReport.Models.Common;

namespace CustomerReport.Repository
{
    public class Getdata 
    {
        #region ReportPayfinaloutput
        public IEnumerable<ReportData> GetReport()
        {
            List<ReportData> Reports = new List<ReportData>();
            try
            {
                CustomerDBEntities DB = new CustomerDBEntities();
                List<Invoice> invoices = new List<Invoice>();
                List<Invoice> invData = DB.Invoices.ToList();
                {
                    Models.Common.ReportData Report1;
                    int i = 0;
                    foreach (var Inv in invData)
                    {
                        Report1 = new Models.Common.ReportData();
                        var Cust = DB.Customers.FirstOrDefault(x => x.Customer_No == Inv.Customer_No);
                        Report1.DateOfMonthInvoice = new DateTime(Inv.Invoice_Date.Year, Inv.Invoice_Date.Month, 11);
                        Report1.DateOfMonth = Report1.DateOfMonthInvoice;
                        Report1.MonthYear = Report1.DateOfMonth.ToString("MMM-yy");

                        if (Cust != null)
                        {
                            Report1.CustomerNo = Inv.Customer_No;
                            Report1.CustomerName = Cust.Customer_Name;
                        }
                        Report1.NoOfInvoices = 1;
                        Boolean b = false;

                        foreach (var a in Reports)
                        {
                            if (a.DateOfMonthInvoice == Report1.DateOfMonthInvoice && a.CustomerNo == Report1.CustomerNo)
                            {
                                a.Sales = Inv.Invoice_Amount + a.Sales;
                                a.NoOfInvoices = a.NoOfInvoices + 1;
                                b = true;
                            }
                        }
                        if (b == false)
                        {
                            Report1.Sales = Inv.Invoice_Amount;
                            i++;
                            Report1.No = i;
                            Reports.Add(Report1);
                        }
                    }
                    List<Payment> Payments = new List<Payment>();
                    List<Payment> PayData = DB.Payments.ToList();

                    foreach (var PayInv in PayData)
                    {
                        Report1 = new Models.Common.ReportData();
                        var inv = DB.Invoices.FirstOrDefault(x => x.Invoice_No == PayInv.Invoice_No);

                        var Cust = DB.Customers.FirstOrDefault(x => x.Customer_No == inv.Customer_No);
                        if (PayInv != null)
                        {
                            Report1.DateOfMonthPay = new DateTime(PayInv.Payment_Date.Year, PayInv.Payment_Date.Month, 11);
                            Report1.DateOfMonth = Report1.DateOfMonthPay;
                            Report1.MonthYear = Report1.DateOfMonth.ToString("MMM-yy");

                        }

                        if (Cust != null)
                        {
                            Report1.CustomerNo = Cust.Customer_No;
                            Report1.CustomerName = Cust.Customer_Name;
                        }
                        Boolean b = false;

                        foreach (var a in Reports)
                        {
                            if ((a.DateOfMonth == Report1.DateOfMonthPay || a.DateOfMonthPay == Report1.DateOfMonthPay) && a.CustomerNo == Report1.CustomerNo)
                            {
                                if (PayInv != null)
                                {
                                    a.PaymentCollection = PayInv.Payment_Amount + a.PaymentCollection;
                                }
                                b = true;
                            }
                        }
                        if (b == false)
                        {
                            if (PayInv != null)
                            {
                                Report1.PaymentCollection = PayInv.Payment_Amount;
                            }
                            Reports.Add(Report1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Reports = Reports.OrderBy(e => e.DateOfMonth).ThenBy(e => e.CustomerName).ToList();
            return Reports;
        }
        #endregion
    }
}