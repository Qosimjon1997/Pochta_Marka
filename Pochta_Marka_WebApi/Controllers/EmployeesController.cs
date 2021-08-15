using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pochta_Marka_WebApi.Data;
using Pochta_Marka_WebApi.Models;

namespace Pochta_Marka_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            Employee employee = await (from a in _context.Employees
                                  .Include(x => x.Branch)
                                  where a.Id == id
                                  select a).FirstOrDefaultAsync();
            if (employee == null)
            {
                return NotFound();
            }

            return new ObjectResult(employee);
        }

        [HttpGet("{login}/{passw}")]
        public async Task<ActionResult<Employee>> GetEmployeeByLoginPassw(string login, string passw)
        {
            var employee = await _context.Employees.Where(x => x.Login == login && x.Passw == passw).FirstOrDefaultAsync();

            return employee;
        }


        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> PutEmployee(int id, Employee employee)
        {
            var v = await _context.Employees.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (employee == null)
            {
                return false;
            }
            if (!_context.Employees.Any(x => x.Id == id))
            {
                return false;
            }
            v.FullName = employee.FullName;
            v.Login = employee.Login;
            v.Passw = employee.Passw;
            v.Dostup = employee.Dostup;
            v.BranchId = employee.BranchId;
            await _context.SaveChangesAsync();
            return true;

        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<bool>> PostEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return true;
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteEmployee(int id)
        {
            Employee employee = _context.Employees.FirstOrDefault(x => x.Id == id);
            if (employee == null)
            {
                return false;
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
