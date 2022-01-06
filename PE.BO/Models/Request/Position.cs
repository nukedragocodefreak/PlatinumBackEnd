using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE.BO.Models.Request
{
    public class Position
    {
        public int PositionID { get; set; } //(int, not null)
        public string PositionName { get; set; } //(varchar(50), null)
    }
}
