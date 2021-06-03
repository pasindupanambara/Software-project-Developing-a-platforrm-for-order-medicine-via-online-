/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using E_Pharmacy.Data;
using E_Pharmacy.Models;


namespace E_Pharmacy.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyloginController : ControllerBase

    {
        private readonly PharmacyDataContext _context;

        private readonly IJwtAuthenticationManager jWTAuthenticationManager;

       
        public PharmacyloginController(IJwtAuthenticationManager jWTAuthenticationManager, PharmacyDataContext context)
        {
            this.jWTAuthenticationManager = jWTAuthenticationManager;
            _context = context;
        }


        /*

        // GET: api/Pharmacylogin
        [HttpGet]
        public IEnumerable<string> Get()
        {
       
            return new string[] { "value1", "value2" };
        }

        // GET: api/Pharmacylogin/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }*/

       /* [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
            var token = jWTAuthenticationManager.Authenticate(userCred.Email, userCred.Password);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }

       

        

        // GET: api/Pharmacylogin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pharmacy>>> GetPharmacy(string value)
        {
            return await _context.Pharmacy.Where(p => p.Email == value).ToListAsync();

        }


    }
}*/
