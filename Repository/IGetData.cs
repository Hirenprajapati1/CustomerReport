using CustomerReport.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerReport.Repository
{
    public interface IGetData
    {
         List<ReportData> GetReport();
    }
}
