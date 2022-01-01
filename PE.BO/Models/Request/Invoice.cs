using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE.BO.Models.Request
{
    public class Invoice
    {
        public int InvoiceID { get; set; } //(int, not null)
        public string InvoiceNumber { get; set; } //(varchar(50), null)
        public DateTime Date { get; set; } //(datetime, null)
        public string location { get; set; } //(varchar(100), null)
        public string FIleName { get; set; } //(varchar(50), null)
        public int FK_CoverSheetID { get; set; } //(int, null)
        public int FK_SupplierID { get; set; } //(int, null)
    }

}
