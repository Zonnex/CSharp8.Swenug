using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Demo.NullableReferenceTypes.Project.Controllers
{
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly SampleContext sampleContext;

        public SampleController(SampleContext sampleContext)
        {
            this.sampleContext = sampleContext;
        }

        [HttpGet]
        public Task<Company[]> Get()
        {
            return sampleContext.Companies
                .Include(c => c.Employees)
                .ToArrayAsync();
        }

        [HttpGet("employees/{id}")]
        public Task<Person> Get(int id)
        {
            /*
             EF Core's public API surface has not yet been annotated for nullability (the public API is "null-oblivious"), 
             making it sometimes awkward to use when the NRT feature is turned on. 
             This notably includes the async LINQ operators exposed by EF Core, such as FirstOrDefaultAsync. 
             We plan to address this for the 5.0 release.
             */
            return sampleContext.People
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        [HttpGet("employees/{id}/boss")]
        public Task<Person> GetBoss(int id)
        {
            return sampleContext.People
                .Include(p => p.Boss)
                .Where(p => p.Id == id)
                .Select(p => p.Boss)
                .FirstAsync();
        }
    }
}
