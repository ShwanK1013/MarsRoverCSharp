using System;
namespace MarsRover
{
    public class Message
    {
        public string Name { get; set; }
        public Command[] Commands { get; set; }

        public Message() { }

        public Message (string name) 
        {
            Name = name; 
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(name, "Message Name required.");
            }
        }

        public Message(string name, Command[] commands)
        {
            
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(name, "Message Name required.");
            }
            Name = name;
            Commands = commands;
        }

    }
}
