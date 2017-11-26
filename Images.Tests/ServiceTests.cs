using Images.Models;
using Images.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace Images.Tests
{
    [TestClass]
    public class ServiceTests
    {
        private ColorProfilesService _service;
        private ColorProfile _redProfile;
        private ColorProfile _greenProfile;

        [TestInitialize()]
        public void Startup()
        {
            _redProfile = new ColorProfile { Name = "red", R = 255, G = 0, B = 0 };
            _greenProfile = new ColorProfile { Name = "green", R = 60, G = 170, B = 20 };

            var config = new ProfilesConfiguration
            {
                Tolerance = 20,
                Profiles = new ColorProfile[]
                {
                    _redProfile,        
                    _greenProfile                    
                }
            };

            _service = new ColorProfilesService(config);
        }

        [TestMethod]
        public void Red()
        {                       
            var image = Image.FromFile("Images\\red.jpg");
            var bitmap = new Bitmap(image);

            var profile = _service.GetProfileForImage(bitmap);

            Assert.AreEqual(profile, _redProfile);
        }

        [TestMethod]
        public void Green()
        {
            var image = Image.FromFile("Images\\green.jpg");
            var bitmap = new Bitmap(image);

            var profile = _service.GetProfileForImage(bitmap);

            Assert.AreEqual(profile, _greenProfile);
        }

        [TestMethod]
        public void NoMatch()
        {
            var image = Image.FromFile("Images\\sky.jpg");
            var bitmap = new Bitmap(image);

            var profile = _service.GetProfileForImage(bitmap);

            Assert.AreEqual(profile, null);
        }
    }
}
