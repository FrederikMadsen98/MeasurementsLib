using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeasurementsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasurementsLib.Tests
{
    [TestClass()]
    public class MeasurementsTests
    {

        private readonly Measurements _measurements = new() { id = 1, ppm = 450 };

        [TestMethod()]
        public void ValidatePPMTest()
        {
            Measurements ppmTooHigh = new()
            {
                id = 1,
                ppm = 1001,
            };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ppmTooHigh.ValidatePPM());

            Measurements ppmPerfect = new()
            {
                id = 1,
                ppm = 450,
            };
            Assert.ThrowsException<ArgumentException>(() => ppmPerfect.ValidatePPM());
        }

        [TestMethod()]
        public void ValidateTest()
        {
            _measurements.Validate();
        }
    }
}