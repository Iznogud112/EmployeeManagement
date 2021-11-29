using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Interfaces;
using WebAPI.Models;
using WebAPI.ViewModel;

namespace WebAPI.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly AppDbContext _context;

        public EmployeeServices(AppDbContext context)
        {
            this._context = context;
        }

        public List<EmployeeV2> GetAllEmployees() => _context.Employees.ToList();

        public EmployeeV2 GetEmployeeById(int id) => _context.Employees.FirstOrDefault(e => e.EmployeeId == id);

        public void AddEmployee(EmployeeV2 employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);

            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"Employee with id: {id} does not exist");
            }
        }

        public EmployeeV2 UpdateEmployee(EmployeeVM employee, int id)
        {
            var _employee = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);

            if (_employee != null)
            {
                _employee.EmployeeName = employee.EmployeeName;
                _employee.Department = employee.Department.DepartmentName;
                _employee.DateOfJoining = employee.DateOfJoining.Date;
                _employee.PhotoFileName = employee.PhotoFileName;

                _context.SaveChanges();
            }

            return _employee;
        }
    }
}
