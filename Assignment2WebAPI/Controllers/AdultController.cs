using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment2WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Assignment2WebAPI.Models;

namespace Assignment2WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultController : ControllerBase
    {
        private IAdultData adultData;

        public AdultController(IAdultData adultData)
        {
            this.adultData = adultData;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Adult>>>
            GetAdults()
        {
            try
            {
                IList<Adult> adults = await adultData.GetAdultsAsync();
                return Ok(adults);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Adult>> AddAdult([FromBody] Adult adult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Adult added = await adultData.AddAdultAsync(adult);
                return Created($"/{added.Id}", added);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteAdult([FromRoute] int id)
        {
            try
            {
                await adultData.RemoveAdultAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        [Route("{id:int}")]
        public async Task<ActionResult> UpdateAdult([FromBody] Adult adult)
        {
            try
            {
                Adult updatedAdult = await adultData.EditAdultAsync(adult);
                return Ok(updatedAdult);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}