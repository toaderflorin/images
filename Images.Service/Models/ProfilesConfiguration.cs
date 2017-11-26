using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Images.Models
{
    public class ProfilesConfiguration
    {
        /// <summary>
        /// Gets or sets the array of configured color profiles.
        /// </summary>
        public ColorProfile[] Profiles { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the tolerance used in the matching process. Max value is 255.0.
        /// </summary>
        public double Tolerance { get; set; }
    }
}
