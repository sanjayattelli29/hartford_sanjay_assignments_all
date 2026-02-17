using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoliciesCrudApi.Data;
using PoliciesCrudApi.Models;

namespace PoliciesCrudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesController : ControllerBase
    {
        private readonly PolicyContext _context;

        public PoliciesController(PolicyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Policy>>> GetPolicies()
        {
            return await _context.Policies.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Policy>> GetPolicy(int id)
        {
            var policy = await _context.Policies.FindAsync(id);
            if (policy == null) return NotFound();
            return policy;
        }

        [HttpPost]
        public async Task<ActionResult<Policy>> CreatePolicy(Policy policy)
        {
            _context.Policies.Add(policy);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPolicy),
                new { id = policy.Id }, policy);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePolicy(int id, Policy policy)
        {
            if (id != policy.Id) return BadRequest();

            _context.Entry(policy).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolicy(int id)
        {
            var policy = await _context.Policies.FindAsync(id);
            if (policy == null) return NotFound();

            _context.Policies.Remove(policy);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
