using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PE.BO.Models.Request;
using PE.BO.Models.Response;

namespace PE.DAL.Repository
{
    public interface  IEmployeeBLL
    {
        public Task<ApiGenericResponse> SaveEmployee(Employee employee);

        public Task<IEnumerable<Position>> GetPosition();
        public Task<IEnumerable<Employee>> GetEmployee();
        public Task<IEnumerable<Employee>> UserLogin(Users users);
    }
}
