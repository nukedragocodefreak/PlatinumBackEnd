using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PE.BO.Models.Request;
using PE.BO.Models.Response;
using PE.DAL.Repositories;
using PE.DAL.Repository;

namespace PE.BLL.Logic
{
    public class DepartmentBLL : IDepartmentBLL
    {
        private readonly DepartmentRepository _departmentRepository;
        public DepartmentBLL(DepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<ApiGenericResponse> SaveDepartment(Department department)
        {
            var saveResponse = await _departmentRepository.SaveDepartment(department);
            return saveResponse;
        }
    }
}
