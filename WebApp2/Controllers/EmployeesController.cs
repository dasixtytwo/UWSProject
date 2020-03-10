using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using dasixtytwo.lib;
using System.Linq;
using WebApp2.Models.Binding;
using System.Threading.Tasks;

namespace WebApp2.Controllers
{
  [Produces("application/json")]
  [Route("api/employees")]
  public class EmployeesController : Controller
  {
    private Northwind _context;

    // constructor injects registered repository 
    public EmployeesController(Northwind ctx)
    {
      _context = ctx;
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

    // Post: api/employees
    // BODY: Employee (JSON, XML)
    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromBody] EmployeeData empData)
    {
      if (ModelState.IsValid)
      {
        Employee e = empData.Employee;
        _context.Add(e);
        await _context.SaveChangesAsync();
        return Ok(e.EmployeeID); // 200 OK 
      }
      else
      {
        return BadRequest(ModelState); // return error
      }
    }

    // PUT: api/employees/id
    // BODY: Employee (JSON, XML)
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeData empData)
    {
      if (ModelState.IsValid)
      {
        Employee e = empData.Employee;
        e.EmployeeID = id;
        _context.Update(e);       // Update employee
        await _context.SaveChangesAsync();   // and save any changes made it
        return Ok();              // 200 OK 
      }
      else
      {
        return this.BadRequest(ModelState);
      }
    }

    // DELETE: api/employees/id
    [HttpDelete("{id}")]
    public void DeleteEmployee(int id)
    {
      _context.Employees.Remove(new Employee { EmployeeID = id });  // remove employe with specific ID from database
      _context.SaveChanges(); // Save the changes made it
    }
  }
}