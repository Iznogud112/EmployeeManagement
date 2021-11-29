using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.ViewModel;

namespace WebAPI.Interfaces
{
    public interface IEmployeeServices
    {
        void AddEmployee(EmployeeV2 employee);
        void Delete(int id);
        List<EmployeeV2> GetAllEmployees();
        EmployeeV2 GetEmployeeById(int id);
        EmployeeV2 UpdateEmployee(EmployeeVM employee, int id);
    }
}
