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
    public class EmployeeControllerV2 : ControllerBase
    {
        private EmployeeServices _services;

        public EmployeeControllerV2(EmployeeServices services)
        {
            this._services = services;
        }

        public IActionResult GetAllEmployees()
        {
            var employee = _services.GetAllEmployees();
            return Ok(employee);
        }

        public IActionResult AddEmployee(EmployeeV2 employee)
        {
            _services.AddEmployee(employee);
            return Ok();
        }

        public IActionResult UpdateEmployee([FromBody] EmployeeVM employee, int id)
        {
            var _employee = _services.UpdateEmployee(employee, id);

            return Ok(_employee);
        }

        public IActionResult DeleteEmployee(int id)
        {
            _services.Delete(id);
            return Ok();
        }
    }
}
