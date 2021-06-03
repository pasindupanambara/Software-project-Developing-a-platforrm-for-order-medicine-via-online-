using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Pharmacy.Data;
using E_Pharmacy.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace E_Pharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmaciesController : ControllerBase
    {
        private readonly PharmacyDataContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PharmaciesController(PharmacyDataContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: api/Pharmacies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pharmacy>>> GetPharmacy(string field, string value)
        {
            if (field == "district")
            {
                return await _context.Pharmacy.Where(p => p.District == value).ToListAsync();
            }

            else if (field == "name")
            {
                return await _context.Pharmacy.Where(p => p.Pharmacyname == value)
                     .Select(x => new Pharmacy()
                     {
                         Id = x.Id,
                         Pharmacyname = x.Pharmacyname,
                         Address = x.Address,
                         District = x.District,
                         TeleNo = x.TeleNo,
                         Email = x.Email,
                         RegNo = x.RegNo,
                         ImageSrc = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.Pharmacyimagename)
                     })
                     .ToListAsync();
            }

            else if (field == "all")
            {
                return await _context.Pharmacy.ToListAsync();
            }

            return NotFound();
        }


        // GET: api/Pharmacies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pharmacy>> GetPharmacy(int id)
        {
            var pharmacy = await _context.Pharmacy.FindAsync(id);

            if (pharmacy == null)
            {
                return NotFound();
            }

            return pharmacy;
        }

        // PUT: api/Pharmacies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPharmacy(int id, Pharmacy pharmacy)
        {
            if (id != pharmacy.Id)
            {
                return BadRequest();
            }

            _context.Entry(pharmacy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PharmacyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pharmacies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Pharmacy>> PostPharmacy([FromForm]Pharmacy pharmacy)
        {

            var pharmacyWithSameEmail = _context.Pharmacy.FirstOrDefault(m => m.Email.ToLower() == pharmacy.Email.ToLower()); //check email already exit or not


            if (pharmacyWithSameEmail == null)
            {
                pharmacy.Pharmacyimagename = await SaveImage(pharmacy.Pharmacyimagefile);
                _context.Pharmacy.Add(pharmacy);
                await _context.SaveChangesAsync();

                return StatusCode(201);
                //return CreatedAtAction("GetPharmacy", new { id = pharmacy.Id }, pharmacy);

            }

            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/Pharmacies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pharmacy>> DeletePharmacy(int id)
        {
            var pharmacy = await _context.Pharmacy.FindAsync(id);
            if (pharmacy == null)
            {
                return NotFound();
            }

            _context.Pharmacy.Remove(pharmacy);
            await _context.SaveChangesAsync();

            return pharmacy;
        }

        private bool PharmacyExists(int id)
        {
            return _context.Pharmacy.Any(e => e.Id == id);
        }

        /*[NonAction]
        public async Task<string> SaveImage(IFormFile Pharmacyimagefile)
        {
            string PharmacyimageName = new string(PathString.GetFileNameWithoutExtension(Pharmacyimagefile.Filename).Take(10).ToArray()).Replace('', '-');
            PharmacyimageName = PharmacyimageName + DateTime.Now.Tostring("yymmssfff") + Path.GetExtension(Pharmacyimagefile.Filename);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", PharmacyimageName);
            using (var fileStream = new FileStream(imagePath, FileMode.create))
            {
                await Pharmacyimagefile.CopyToasync(filestream);
            }
            return PharmacyimageName;

        }*/

        [NonAction]
        public async Task<string> SaveImage(IFormFile Pharmacyimagefile)
        {
            string Pharmacyimagename = new String(Path.GetFileNameWithoutExtension(Pharmacyimagefile.FileName).Take(10).ToArray()).Replace(' ', '-');
            Pharmacyimagename = Pharmacyimagename + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(Pharmacyimagefile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", Pharmacyimagename);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await Pharmacyimagefile.CopyToAsync(fileStream);
            }
            return Pharmacyimagename;
        }

    }
}
