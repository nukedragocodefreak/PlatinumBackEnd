using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE.BO.Models.Request
{
    public class Company
    {
        public int CompanyID { get; set; } //(int, not null)
        public string Name { get; set; } //(varchar(50), null)
        public string Address { get; set; } //(varchar(100), null)
        public string Email { get; set; } //(varchar(50), null)
        public string Phonenumbers { get; set; } //(varchar(100), null)
    }

}
