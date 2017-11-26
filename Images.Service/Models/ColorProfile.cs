using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Images.Models
{
    public class ColorProfile
    {
        /// <summary>
        /// Gets or sets the name of the color profile.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value for the red channel of the color profile.
        /// </summary>
        public byte R { get; set; }

        /// <summary>
        /// Gets or sets the value for the green channel of the color profile.
        /// </summary>
        public byte G { get; set; }

        /// <summary>
        /// Gets or sets the value for the blue channel of the color profile.
        /// </summary>
        public byte B { get; set; }
    }
}
