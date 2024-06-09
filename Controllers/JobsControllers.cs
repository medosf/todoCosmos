using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoComos.Service;

namespace TodoComos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly JobsService _jobsService;

        public JobsController(JobsService jobsService)
        {
            _jobsService = jobsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            var jobs = await _jobsService.GetJobs();
            return Ok(jobs);
        }
    }
}
