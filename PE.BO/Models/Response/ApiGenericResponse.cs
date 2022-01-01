using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE.BO.Models.Response
{
    public class ApiGenericResponse
    {
        public int ResponseType { get; set; }
        public object ResponseObject { get; set; }
        public string ResponseMessage { get; set; }
    }
}
