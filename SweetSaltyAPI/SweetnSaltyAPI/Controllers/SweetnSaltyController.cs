using Microsoft.AspNetCore.Mvc;
using SweetnSaltyBusiness;
using SweetnSaltyModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SweetnSaltyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class SweetnSaltyController : Controller
    {

        private readonly ISweetnSaltyBusinessClass _businessClass;
        //constructor
        public SweetnSaltyController(ISweetnSaltyBusinessClass ISweetnSaltyBusinessClass)
        {
            _businessClass = ISweetnSaltyBusinessClass;
        }


        [HttpPost]
        [Route("postaflavor/{flavor}")]
        public async Task<ActionResult<Flavor>> PostFlavor(string flavor)
        {
            Flavor f = await _businessClass.PostFlavor(flavor);
            if (f != null)
            {
                return Created($"http://5001/sweetnsalty/postaflavor/{f.flavorId}", f);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("postaperson/{fname}/{lname}")]
        public async Task<ActionResult<Person>> PostPerson(string fname, string lname)
        {
            Person p = await _businessClass.PostPerson(fname, lname);
            if (p != null)
            {
                return Created($"http://5001/sweetnsalty/postaperson/{p.fname}/{p.lname}", p);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("getaperson/{fname}/{lname}")]
        public async Task<ActionResult<Person>> GetPerson(string fname, string lname)
        {
            Person p = await _businessClass.GetPerson(fname, lname);
            if (p != null)
            {
                return Ok(p);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("getapersonandflavors/{id}")]
        public async Task<ActionResult<Person>> GetPersonAndFlavors(int id)
        {
            Person p = await _businessClass.GetPersonAndFlavors(id);
            if (p != null)
            {
                return Ok(p);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet]
        [Route("getlistofflavors")]
        public async Task<ActionResult<List<Flavor>>> GetAllFlavors()
        {
            List<Flavor> f = await _businessClass.GetAllFlavors();
            if (f.Count != 0)
            {
                return Ok(f);
            }
            else
            {
                return NotFound();
            }
        }



    }
}
