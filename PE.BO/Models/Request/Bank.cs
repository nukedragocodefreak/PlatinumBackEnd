using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE.BO.Models.Request
{
    public class Bank
    {
        public int BankID { get; set; } //(int, not null)
        public string BankName { get; set; } //(int, null)
    }
}
