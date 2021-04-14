using Microsoft.AspNetCore.Mvc;
using Models;
using Service;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractorJobsController : ControllerBase
    {
        private readonly ContractorJobsService _service;

        public ContractorJobsController(ContractorJobsService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<ContractorJobs> Create([FromBody] ContractorJobs newCJ)
        {
            try
            {
                return Ok(_service.Create(newCJ));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok("deleted");
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}