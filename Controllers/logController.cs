/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_Pharmacy.Data;
using E_Pharmacy.Models;
using Microsoft.Extensions.Configuration;
using E_Pharmacy.Services;

namespace E_Pharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        public readonly PharmacyDataContext _context;
        private readonly IConfiguration _config;
        private IJWTService _jwtService;

        public UserLoginController(IConfiguration config, IJWTService jwtservice, PharmacyDataContext context)
        {
            _config = config;
            _context = context;
            _jwtService = jwtservice;
        }


        // POST: api/UserLogin
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Login>> PostLogin(Login login)
        {
            try
            {

                var CheckCustomeEmil = _context.Customer.FirstOrDefault(m => m.Email.ToLower() == login.Email);
                var CheckCustomerPW = _context.Customer.FirstOrDefault(m => m.Password.ToLower() == login.Password);


                var CheckPharmacyEmail = _context.Pharmacy.FirstOrDefault(m => m.Email.ToLower() == login.Email);
                var CheckPharmacyPW = _context.Pharmacy.FirstOrDefault(m => m.Password.ToLower() == login.Password);


                if (((CheckCustomeEmil == null) || (CheckCustomerPW == null)) && ((CheckPharmacyEmail == null) || (CheckPharmacyPW == null)))
                {
                    return BadRequest();
                }

                else
                {
                    var tokenString = _jwtService.GenerateJWTtoken(login);
                    return Ok(new
                    {
                        token = tokenString
                    });
                }

            }


            catch (Exception ex)
            { throw ex; }

        }

    }
}*/