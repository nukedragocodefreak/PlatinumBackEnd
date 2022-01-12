using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE.BO.Models.Request
{
    public class Users
    {
        public int UserID { get; set; } //(int, not null)
        public string EmployeeCode { get; set; } //(varchar(50), not null)
        public string Password { get; set; } //(varchar(50), not null)
        public int Position { get; set; } //(varchar(50), not null)
    }
}
