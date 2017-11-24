using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Images.Models
{
    public class ProfilesConfiguration
    {
        public ColorProfile[] Profiles { get; set; }

        public double Tolerance { get; set; }
    }
}
