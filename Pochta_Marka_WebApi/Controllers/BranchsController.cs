using Microsoft.AspNetCore.Mvc;
using Pochta_Marka_WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pochta_Marka_WebApi.Data;

namespace Pochta_Marka_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public BranchsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Branch>>> GetAll()
        {
            return await _context.Branches.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Branch>> Get(int id)
        {
            Branch v = await _context.Branches.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (v == null)
            {
                return NotFound();
            }
            return new ObjectResult(v);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Post(Branch branch)
        {
            if (branch == null)
            {
                return false;
            }
            _context.Branches.Add(branch);
            await _context.SaveChangesAsync();
            return true; 
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Put(int id, Branch branch)
        {
            var v = await _context.Branches.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(branch == null)
            {
                return false;
            }
            if(!_context.Branches.Any(x=>x.Id == id))
            {
                return false;
            }
            v.Sales = branch.Sales;
            v.Employees = branch.Employees;
            v.BranchNumber = branch.BranchNumber;
            v.BranchAddress = branch.BranchAddress;
            await _context.SaveChangesAsync();
            return true;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            Branch branch = _context.Branches.FirstOrDefault(x => x.Id == id);
            if(branch == null)
            {
                return false;
            }
            _context.Branches.Remove(branch);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
