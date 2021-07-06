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
            Rover newRover = new Rover(9000);
            Assert.AreEqual(9000, newRover.Position);
        }
        [TestMethod]
        public void ConstructorSetsDefaultMode()
        {
            Rover newRover = new Rover(0);
            Assert.AreEqual("NORMAL", newRover.Mode);

        }

        [TestMethod]
        public void ConstructorSetsDefaultGeneratorWatts()
        {
            Rover newRover = new Rover(0);
            Assert.AreEqual(110, newRover.GeneratorWatts);

        }
        [TestMethod]
        public void RespondsCorrectlyToModeChangeCommand()
        {
            Command[] commands = { new Command("MODE_CHANGE", "LOW_POWER")};
            Message message = new Message("Update 1", commands);
            Rover roverTest = new Rover(0);
            roverTest.ReceiveMessage(message);


            Assert.AreEqual("LOW_POWER", roverTest.Mode);
        }

        [TestMethod]
        public void DoesNotMoveInLowPower()
        {
            
            Command[] commands = { new Command("MODE_CHANGE", "LOW_POWER"), new Command("MOVE", 500) };
            Message message = new Message("Update 1", commands);
            Rover roverTest = new Rover(0);
            
            try
            {
                roverTest.ReceiveMessage(message);
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Does Not Move In LowPower", ex.Message);
            }
        }

        [TestMethod]
        public void PositionChangesFromMoveCommand()
        {
            Command[] commands = { new Command("MODE_CHANGE", "HIGH_POWER"), new Command("MOVE", 500) };
            Message message = new Message("Update 1", commands);
            Rover roverTest = new Rover(0);
            roverTest.ReceiveMessage(message);


            Assert.IsTrue(500 == roverTest.Position);
        }
        [TestMethod]
        public void RoverReturnsAMessageForAnUnknownCommand()
        {

            Command[] commands = { new Command("123", "LOW_POWER"), new Command("435", 500) };
            Message message = new Message("Update 1", commands);
            Rover roverTest = new Rover(0);

            try
            {
                roverTest.ReceiveMessage(message);
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Unknown Command", ex.Message);
            }
        }



    }
}
