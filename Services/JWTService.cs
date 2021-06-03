using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using E_Pharmacy.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using E_Pharmacy.Data;


namespace E_Pharmacy.Services
{
    public class JWTService : IJWTService
    {
        private readonly IConfiguration _config;
        private readonly PharmacyDataContext _context;
        public JWTService(IConfiguration config, PharmacyDataContext context)
        {
            _config = config;
            _context = context;
        }

        public string GenerateJWTtoken(Login user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Find User role

            var isCustomer = _context.Customer.FirstOrDefault(m => m.Email.ToLower() == user.Email.ToLower());
            var isPharmacy = _context.Pharmacy.FirstOrDefault(m => m.Email.ToLower() == user.Email.ToLower());


            var currentUserRole = new object();
            var currentUserId = new object();

            if (isCustomer != null)
            {
                currentUserRole = isCustomer.UserRole;
                currentUserId = isCustomer.CustId;
            }


            else
            {
                currentUserRole = isPharmacy.UserRole;
                currentUserId = isPharmacy.Id;
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim("id", currentUserId.ToString()),
                new Claim("role", currentUserRole.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}

