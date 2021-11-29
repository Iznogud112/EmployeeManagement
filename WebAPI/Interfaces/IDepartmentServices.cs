using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.ViewModel;

namespace WebAPI.Interfaces
{
    public interface IDepartmentServices
    {
        void AddDepartment(DepartmentV2 department);
        void Delete(int id);
        List<DepartmentV2> GetAllDepartments();
        DepartmentV2 GetDepartmentById(int id);
        DepartmentV2 Update(DepartmentVM department, int id);
    }
}
