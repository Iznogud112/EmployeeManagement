using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Services;
using WebAPI.ViewModel;

namespace WebAPI.Controllers.V2
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class DepartmentControllerV2 : ControllerBase
    {
        private DepartmentServices _services;

        public DepartmentControllerV2(DepartmentServices services)
        {
            this._services = services;
        }

        public IActionResult GetAllDepartments()
        {
            var department = _services.GetAllDepartments();
            return Ok(department);
        }

        public IActionResult AddDepartment(DepartmentV2 department)
        {
            _services.AddDepartment(department);
            return Ok();
        }

        public IActionResult UpdateDepartment([FromBody] DepartmentVM department, int id)
        {
            var _department = _services.Update(department, id);

            return Ok(_department);
        }

        public IActionResult DeleteDepartment(int id)
        {
            _services.Delete(id);
            return Ok();
        }
    }
}
