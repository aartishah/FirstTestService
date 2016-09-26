

using System.Collections.Generic;

using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FirstTestService.Controllers

{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    public class EmployeesController : Controller

    {

        [HttpGet]
        public IEnumerable<Employee> GetEmployees()

        {

            return Employee.GetEmployees().AsEnumerable();

        }

    }

}

