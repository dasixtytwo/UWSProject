using System.Collections.Generic;
using System.Linq;
using dasixtytwo.lib;
using Microsoft.AspNetCore.Mvc;

namespace WebApp1.Controllers
{
  [Produces("application/json")]
  [Route("api/[controller]")]
  public class EmployeesController : Controller
  {
    private Northwind _context;

    public EmployeesController(Northwind context)
    {
      _context = context;
    }

    // GET: api/employees
    [HttpGet]
    public IEnumerable<Employee> GetEmployees()
    {
      IQueryable<Employee> query = _context.Employees;

      return query;
    }

    // GET: api/employees/id
    [HttpGet("{id}")]
    public Employee GetEmployee(int id)
    {
      Employee result = _context.Employees
        .FirstOrDefault(e => e.EmployeeID == id);    // find the employee with specific ID

      return result;
    }
  }
}