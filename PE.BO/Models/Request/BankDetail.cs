using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE.BO.Models.Request
{
    public class BankDetail
    {
        public int BankDetailID { get; set; } //(int, not null)
        public int FK_BankID { get; set; } //(int, not null)
        public int FK_CompanyID { get; set; } //(int, null)
        public string BranchName { get; set; } //(varchar(50), null)
        public string BranchCode { get; set; } //(varchar(50), null)
        public int AccountNumber { get; set; } //(int, not null)
    }
}
