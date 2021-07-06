using System;
using System.Collections.Generic;
using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTests
{
    [TestClass]
    public class RoverTests
    {
        [TestMethod]
        public void ConstructorSetsDefaultPosition()
        {
            Rover newrover = new Rover(9000);
            Assert.AreEqual(9000, newrover.Position);
        }
        [TestMethod]
        public void ConstructorSetsDefaultMode()
        {
            Rover newrover = new Rover(0);
            Assert.AreEqual("NORMAL", newrover.Mode);

        }

        [TestMethod]
        public void ConstructorSetsDefaultGeneratorWatts()
        {
            Rover newrover = new Rover(0);
            Assert.AreEqual(110, newrover.GeneratorWatts);

        }


    }
}
