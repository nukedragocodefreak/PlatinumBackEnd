using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE.BO.Models.Request
{
    public class CoverSheet
    {
        public int CoverSheetID { get; set; } //(int, not null)
        public string FirstName { get; set; } //(varchar(50), null)
        public string LastName { get; set; } //(varchar(50), null)
        public int DepartmentID { get; set; } //(int, null)
        public DateTime DateOfInvoce { get; set; } //(datetime, null)
        public DateTime DateOfPayment { get; set; } //(datetime, null)
        public int ManagerID { get; set; } //(int, null)
        public int CompanyID { get; set; } //(int, null)
        public int FK_PaymentStatusID { get; set; } //(int, null)
    }

}
