using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Service;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly JobsService _service;
        private readonly ContractorsService _cService;

        public JobsController(JobsService service, ContractorsService cService)
        {
            _service = service;
            _cService = cService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Jobs>> GetAll()
        {
            try
            {
                return Ok(_service.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]  // NOTE '{}' signifies a var parameter
        public ActionResult<Jobs> Get(int id)
        {
            try
            {
                return Ok(_service.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost] // POST
        public ActionResult<Jobs> Create([FromBody] Jobs newJob)
        {
            try
            {
                return Ok(_service.Create(newJob));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id}")] //EDIT
        public ActionResult<Jobs> Edit([FromBody] Jobs updated, int id)
        {
            try
            {
                updated.Id = id;
                return Ok(_service.Edit(updated));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")] // DELETE
        public ActionResult<Jobs> Delete(int id)
        {
            try
            {
                return Ok(_service.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}/contractors")]  // NOTE '{}' signifies a var parameter
        public ActionResult<IEnumerable<ContractorJobsProductViewModel>> GetContractorsByJobId(int id)
        {
            try
            {
                return Ok(_cService.GetContractorsByJobId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}