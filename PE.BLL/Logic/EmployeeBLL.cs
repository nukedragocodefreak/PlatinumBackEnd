﻿using System;
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
    public class EmployeeBLL : IEmployeeBLL
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeBLL(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetEmployee()
        {
            var saveResponse = await _employeeRepository.GetEmployee();
            return saveResponse;
        }

        public async Task<IEnumerable<Position>> GetPosition()
        {
            var saveResponse = await _employeeRepository.GetPosition();
            return saveResponse;
        }

        public async Task<ApiGenericResponse> SaveEmployee(Employee employee)
        {
            var saveResponse = await _employeeRepository.SaveEmployee(employee);
            return saveResponse;
        }

        public async Task<IEnumerable<Employee>> UserLogin(Users users )
        {
            var saveResponse = await _employeeRepository.UserLogin(users);
            return saveResponse;
        }
    }
}
