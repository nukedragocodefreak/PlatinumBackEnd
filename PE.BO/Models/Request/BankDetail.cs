using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE.BO.Models.Request
{
    public class BankDetail
    {
        public int BankID { get; set; } //(int, not null)
        public int FK_CompanyID { get; set; } //(int, null)
        public string BankName { get; set; } //(varchar(50), null)
        public string BranchCode { get; set; } //(varchar(50), null)
        public string AccountNumber { get; set; } //(varchar(50), null)
    }
}
