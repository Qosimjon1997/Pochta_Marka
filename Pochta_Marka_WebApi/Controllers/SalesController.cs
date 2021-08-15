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
    public class SalesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Sales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sale>>> GetSales()
        {
            return await (from a in _context.Sales
                          select a).ToListAsync();
        }

        // GET: api/Sales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetSale(int id)
        {
            var v = await (from a in _context.Sales
                           where a.Id == id
                           select a).FirstOrDefaultAsync();
            return new ObjectResult(v);

        }

        // PUT: api/Sales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> PutSale(int id, Sale sale)
        {
            var v = await (from a in _context.Sales
                           where a.Id == id
                           select a).FirstOrDefaultAsync();

            if(sale==null)
            {
                return false;
            }
            if (!_context.Sales.Any(x => x.Id == id))
            {
                return false;
            }
            v.BranchId = sale.BranchId;
            v.EmployeeId = sale.EmployeeId;
            v.ProductId = sale.ProductId;
            v.ProductTypeId = sale.ProductTypeId;
            v.Soni = sale.Soni;
            v.Summasi = sale.Summasi;
            await _context.SaveChangesAsync();
            return true;
        }

        // POST: api/Sales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<bool>> PostSale(IEnumerable<Sale> sale)
        {
            if (sale == null)
            {
                return false;
            }
            await _context.Sales.AddRangeAsync(sale);
            await _context.SaveChangesAsync();
            return true;
        }

        // DELETE: api/Sales/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteSale(int id)
        {
            var v = await (from a in _context.Sales
                           where a.Id == id
                           select a).FirstOrDefaultAsync();
            if(v==null)
            {
                return false;
            }
            _context.Sales.Remove(v);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
