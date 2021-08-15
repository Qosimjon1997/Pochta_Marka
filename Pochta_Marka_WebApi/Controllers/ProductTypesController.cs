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
    public class ProductTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductType>>> GetProductTypes()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        // GET: api/ProductTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductType>> GetProductType(int id)
        {
            ProductType productType = await _context.ProductTypes.Where(x=>x.Id ==id).FirstOrDefaultAsync();

            if (productType == null)
            {
                return NotFound();
            }

            return new ObjectResult(productType);
        }

        // PUT: api/ProductTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> PutProductType(int id, ProductType productType)
        {
            var v = await (from a in _context.ProductTypes
                     where a.Id == id
                     select a).FirstOrDefaultAsync();

            if(v==null)
            {
                return false;
            }
            if (!_context.Branches.Any(x => x.Id == id))
            {
                return false;
            }
            v.Name = productType.Name;
            v.Price = productType.Price;
            v.ProductId = productType.ProductId;
            await _context.SaveChangesAsync();
            return true;
        }

        // POST: api/ProductTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<bool>> PostProductType(ProductType productType)
        {
            _context.ProductTypes.Add(productType);
            await _context.SaveChangesAsync();

            return true;
        }

        // DELETE: api/ProductTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteProductType(int id)
        {
            var productType = await _context.ProductTypes.FindAsync(id);
            if (productType == null)
            {
                return false;
            }

            _context.ProductTypes.Remove(productType);
            await _context.SaveChangesAsync();

            return true ;
        }

       
    }
}
