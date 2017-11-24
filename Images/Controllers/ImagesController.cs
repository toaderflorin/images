using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Images.Services;
using System.Net.Http;
using System;
using System.Drawing;
using Images.Models;

namespace Images.Controllers
{
    [Produces("application/json")]
    [Route("api/Images")]
    public class ImagesController : Controller
    {
        private ImagesService _imagesService;

        public ImagesController(ImagesService imagesService)
        {
            _imagesService = imagesService;
        }

        [HttpGet]
        public async Task<ObjectResult> Get(string url)
        {
            using (var c = new HttpClient())
            {
                c.BaseAddress = new Uri(url);

                var res = await c.GetAsync(string.Empty);
                var content = res.Content;
                var stream = await content.ReadAsStreamAsync();

                var image = Image.FromStream(stream);
                var bitmap = new Bitmap(image);

                var closestProfile = _imagesService.GetProfileForImage(bitmap);
               

                if (closestProfile != null)
                {                    
                    return StatusCode(200, closestProfile);
                } else
                {
                    return StatusCode(404, "A matching profile wasn't found.");
                }                
            }            
        }
    }
}
