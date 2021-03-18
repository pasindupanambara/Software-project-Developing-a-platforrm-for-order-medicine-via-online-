using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace E_Pharmacy.Service
{
    public class OrderService : IOrderService
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        public OrderService(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }


        [NonAction]

        public async Task<string> SaveImage(IFormFile ImageData)
        {
            string imageName = new string(Path.GetFileNameWithoutExtension(ImageData.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssff") + Path.GetExtension(ImageData.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await ImageData.CopyToAsync(fileStream);
            }
            return imageName;
        }

        [NonAction]
        public void DeleteImage(String imageName)
        {
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
            if (File.Exists(imagePath))
                File.Delete(imagePath);


        }
    }
}
