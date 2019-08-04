using ImageWriter.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LPA.Handlers
{
    public class ImageHandler
    {
        private readonly IImageWriter _imageWriter;
        public ImageHandler()
        {
            _imageWriter = new ImageWriter.Classes.ImageWriter();
        }

        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            var result = await _imageWriter.UploadImage(file);
            return new ObjectResult(result);
        }
    }
}
