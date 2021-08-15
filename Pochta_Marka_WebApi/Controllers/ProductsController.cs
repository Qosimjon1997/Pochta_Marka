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
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var v = await (from a in _context.Products
                     .Include(x => x.Sales)
                     .Include(x => x.ProductTypes)
                     select a
                     ).FirstOrDefaultAsync();
            if(v == null)
            {
                return NotFound();
            }
            return new ObjectResult(v);

        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> PutProduct(int id, Product product)
        {
            var v = await (from a in _context.Products
                     where a.Id == id
                     select a).FirstOrDefaultAsync();
            if (product == null)
            {
                return false;
            }
            if (!_context.Products.Any(x => x.Id == id))
            {
                return false;
            }
            v.ProductName = product.ProductName;
            _context.SaveChanges();
            return true;

        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<bool>> PostProduct(Product product)
        {
            if(product == null)
            {
                return false;
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return true;
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteProduct(int id)
        {
            var v = await (from a in _context.Products
                     where a.Id == id
                     select a).FirstOrDefaultAsync();
            if(v==null)
            {
                return false;
            }
            _context.Products.Remove(v);
            _context.SaveChanges();
            return true;
        }

    }
}
