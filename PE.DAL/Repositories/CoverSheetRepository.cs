using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PE.BO.Models.Request;
using PE.BO.Models.Response;
using PE.DAL.Repository;

namespace PE.DAL.Repositories
{
    public class CoverSheetRepository : ICoverSheetRepository
    {
        public Task<ApiGenericResponse> SaveCoverSheet(CoverSheet coverSheet)
        {
            throw new NotImplementedException();
        }
    }
}
