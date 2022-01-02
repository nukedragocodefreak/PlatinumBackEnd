using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE.BO.Models.Response
{
    public class ApiGenericResponse
    {
        public int ReturnStatus { get; set; }
        public string ReturnMessage { get; set; }
    }
}
