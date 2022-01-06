using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE.BO.Models.Response
{
    public class DepartmentResponse
    {
        public int DepartmentID { get; set; } //(int, not null)
        public string DepartmentName { get; set; } //(varchar(50), null)
    }

}
