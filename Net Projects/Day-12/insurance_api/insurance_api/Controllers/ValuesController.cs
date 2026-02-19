using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using insurance_api.Data;
using insurance_api.Models;

namespace insurance_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PoliciesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _context.Policies.ToListAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Policy policy)
        {
            _context.Policies.Add(policy);
            await _context.SaveChangesAsync();
            return Ok(policy);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Policies.FindAsync(id);
            if (item == null) return NotFound();

            _context.Policies.Remove(item);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
