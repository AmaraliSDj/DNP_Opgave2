﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNP.Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace DNP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultController: ControllerBase
    {
        private IAdultData adultData;

        public AdultController(IAdultData adultData)
        {
            this.adultData = adultData;
        }
        
         [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdults()
        {
            try
            {
                IList<Adult> adults = await adultData.GetAdults();
                Console.WriteLine(adults);
                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
           
        }
        
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Adult>> GetAdultById([FromRoute] int id)
        {
            try
            {
                Adult adult =  await adultData.Get(id);
                return Ok(adult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        
        [HttpPost]
        public async Task<ActionResult<Adult>> AddAdult([FromBody] Adult adult)
        {
            try
            {
                Adult adultAdded = await adultData.AddAdults(adult);
                return Created($"/{adultAdded.Id}", adultAdded);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteAdultById([FromRoute] int id)
        {

            try
            {
                adultData.RemoveAdults(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
            
            
        }

        [HttpPatch]
        [Route("{id:int}")]
        public async Task<ActionResult<Adult>> UpdateAdult([FromBody] Adult adult)
        {
            try
            {
                Adult update = await adultData.Update(adult);
                return Ok(update);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
            
            
        }

    }
}