using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE.BO.Models.Request
{
    public class Employee
    {
        //public int EmployeeID { get; set; } //(int, not null)
        public string EmployeeCode { get; set; } //(varchar(50), not null)
        public string FirstName { get; set; } //(varchar(50), not null)
        public string LastName { get; set; } //(varchar(50), not null)
        public int FK_DepartmentID { get; set; } //(int, not null)
        public string Position { get; set; } //(varchar(50), not null)
        public string Signature { get; set; } //(varchar(200), not null)
    }

}
