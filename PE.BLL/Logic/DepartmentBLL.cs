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
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentBLL(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<DepartmentResponse>> GetDepartment()
        {

            var saveResponse = await _departmentRepository.GetDepartment();
            return saveResponse;
        }

        public async Task<ApiGenericResponse> SaveDepartment(Department department)
        {
            var saveResponse = await _departmentRepository.SaveDepartment(department);
            return saveResponse;
        }
    }
}
