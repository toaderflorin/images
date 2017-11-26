using Images.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Images.Services
{
    public class ColorProfilesService
    {
        private readonly ProfilesConfiguration _configuration;

        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="configuration">The color profile configuration object.</param>
        public ColorProfilesService(ProfilesConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Gets the matched color profile for the image.
        /// </summary>
        /// <param name="bitmap">The bitmap associated with the image.</param>
        /// <returns>The matched color profile or null if none of them matches withing the required tolerance.</returns>
        public ColorProfile GetProfileForImage(Bitmap bitmap)
        {
            double totalPixels = bitmap.Height * bitmap.Width;        
            double rAverage = 0;
            double gAverage = 0;
            double bAverage = 0;

            for (var x = 0; x < bitmap.Width; x++)
            {
                for (var y = 0; y < bitmap.Height; y++)
                {
                    var pixel = bitmap.GetPixel(x, y);
                    rAverage += (double)(pixel.R) / totalPixels;
                    gAverage += (double)(pixel.G) / totalPixels;
                    bAverage += (double)(pixel.B) / totalPixels;
                }
            }

            var minDistance = 255.0; // cannot be bigger than this

            ColorProfile closestProfile = null;

            foreach (var profile in this._configuration.Profiles)
            {
                var distance = Math.Sqrt(
                    Math.Pow(rAverage - profile.R, 2) + 
                    Math.Pow(gAverage - profile.G, 2) + 
                    Math.Pow(bAverage - profile.B, 2));

                if (distance < minDistance && distance < _configuration.Tolerance)
                {
                    minDistance = distance;
                    closestProfile = profile;
                }
            }
          
            return closestProfile;            
        }
    }
}
