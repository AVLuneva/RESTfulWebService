using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTfulWebService.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace RESTfulWebService.Controllers
{
    public class SuppliersController : ApiControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SuppliersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IAsyncEnumerable<Supplier> GetSuppliers()
        {
            return _context.Suppliers;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSupplier(long id)
        {
            Supplier supplier = await _context.Suppliers.Include(s => s.Products).FirstAsync(s => s.SupplierId == id);

            if (supplier == null)
            {
                return NotFound();
            }
            
            foreach (Product product in supplier.Products)
            {
                product.Supplier = null;
            };

            return Ok(supplier);
        }

        [HttpPatch("{id}")]
        public async Task<Supplier> UpdateSupplier(long id, JsonPatchDocument<Supplier> patchDoc)
        {
            Supplier supplier = await _context.Suppliers.FindAsync(id);
            if (supplier != null)
            {
                patchDoc.ApplyTo(supplier);
                await _context.SaveChangesAsync();
            }
            return supplier;
        }
    }
}
