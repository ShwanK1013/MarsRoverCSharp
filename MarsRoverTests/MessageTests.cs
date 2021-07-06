using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;

namespace MarsRoverTests
{
    [TestClass]
    public class MessageTests
    {
        Command[] commands = { new Command("foo", 0), new Command("bar", 20) };

        [TestMethod]
        public void ArgumentNullExceptionThrownIfNameNotPassedToConstructor()
        {
            try
            {
                new Message("", commands);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Message Name required.", ex.Message);
            }
        }
        [TestMethod]
        public void ConstructorSetsName()
        {
            Message newMessage = new Message("New Message Added", commands);
            Assert.AreEqual("New Message Added", newMessage.Name);
        }

        [TestMethod]
        public void ConstructorSetsCommandsField()
        {
            Command[] commands = { new Command("MODE_CHANGE", "LOW_POWER"), new Command("MOVE", 500) };
            Message newMessage = new Message("New Message Added",commands);
            Assert.AreEqual(commands, newMessage.Commands);

        }
    }  
}
