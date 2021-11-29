using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Interfaces;
using WebAPI.Models;
using WebAPI.ViewModel;

namespace WebAPI.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly AppDbContext _context;

        public DepartmentServices(AppDbContext context)
        {
            this._context = context;
        }

        public List<DepartmentV2> GetAllDepartments() => _context.Departments.ToList();

        public DepartmentV2 GetDepartmentById(int id) => _context.Departments.FirstOrDefault(e => e.DepartmentId == id);

        public void AddDepartment(DepartmentV2 department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var department = _context.Departments.FirstOrDefault(e => e.DepartmentId == id);

            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"Department with id: {id} does not exist");
            }
        }

        public DepartmentV2 Update(DepartmentVM department, int id)
        {
            var _department = _context.Departments.FirstOrDefault(e => e.DepartmentId == id);

            if(_department != null)
            {
                _department.DepartmentName = department.DepartmentName;
            }

            return _department;
        }
    }
}
