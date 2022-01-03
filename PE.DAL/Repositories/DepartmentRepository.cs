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
    public class DepartmentRepository : IDepartmentRepository
    {
        public Task<ApiGenericResponse> SaveDepartment(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
