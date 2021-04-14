using System;
using Microsoft.AspNetCore.Mvc;
using Models;
using Service;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractorsController : ControllerBase
    {
        private readonly ContractorsService _service;

        public ContractorsController(ContractorsService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<Contractors> Get()
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
        public ActionResult<Contractors> Get(int id)
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
        public ActionResult<Contractors> Create([FromBody] Contractors newContractor)
        {
            try
            {
                return Ok(_service.Create(newContractor));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id}")] //EDIT
        public ActionResult<Contractors> Edit([FromBody] Contractors updated, int id)
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
        public ActionResult<Contractors> Delete(int id)
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


    }
}