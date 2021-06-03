/*using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using E_Pharmacy.Data;
using E_Pharmacy.Models;
using Microsoft.EntityFrameworkCore;


namespace E_Pharmacy
{
   

    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {

        private readonly PharmacyDataContext _context;


        private readonly IDictionary<string, string> users = new Dictionary<string, string>
        {
            { "test1", "password1" },
            { "test2", "password2" },
            { "megapharmacy@gmail.com", "mega123" }
        };

        private readonly string tokenKey;

        public JwtAuthenticationManager( string tokenKey)
       {
           
           this.tokenKey = tokenKey;

       }

        /*public JwtAuthenticationManager(PharmacyDataContext context, string tokenKey)
        {
            _context = context;
            this.tokenKey = tokenKey;
           
        }

        public string Authenticate( string Email, string password)
        {
            /*var CheckEmailcustomer = _context.Customer.FirstOrDefault(m => m.Email.ToLower() == Email.ToLower()); 
            var CheckPasswordcustomer = _context.Customer.FirstOrDefault(m => m.Password == password);

            var CheckEmailpharmacy = _context.Pharmacy.FirstOrDefault(m => m.Email.ToLower() == Email.ToLower()); 
            var CheckPasswordpharmacy = _context.Pharmacy.FirstOrDefault(m => m.Password == password);

            if ((CheckEmailcustomer == null || CheckPasswordcustomer == null) && (CheckEmailpharmacy == null || CheckPasswordpharmacy == null))
            {
                return null;
            }


            if (!users.Any(u => u.Key == Email && u.Value == password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(tokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, Email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}


*/