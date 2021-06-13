using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using monitorIntegration.Models;
using Newtonsoft.Json;

namespace monitorIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class monitorIntegrationItemsController : ControllerBase
    {
        private readonly monitorIntegrationContext _context;

        public monitorIntegrationItemsController(monitorIntegrationContext context)
        {
            _context = context;
        }


        // POST: api/monitorIntegrationItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<monitorInformationItem>> PostmonitorInformationItem(monitorInformationItem data)
        {
            _context.Items.Add(data);
            await _context.SaveChangesAsync();

            return Ok(data);
        }

        private bool monitorInformationItemExists(long id)
        {
            return _context.Items.Any(e => e.id == id);
        }
    }
}
