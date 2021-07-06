using System;
namespace MarsRover
{
    public class Command
    {
        public string CommandType { get; set; }
        public int NewPostion { get; set; }
        public string NewMode { get; set; }


        public Command() { }
        public string[] command = new string[] { };
        public Command(string commandType)
        {
            CommandType = commandType;
            if (String.IsNullOrEmpty(commandType))
            {
                throw new ArgumentNullException(commandType, "Command type required.");
            }
        }

        public Command(string commandType, int value)
        {
            CommandType = commandType;
            if (String.IsNullOrEmpty(commandType))
            {
                throw new ArgumentNullException(commandType, "Command type required.");
            }
            NewPostion = value;
        }

        public Command(string commandType, string modeType)
        {
            Rover newRover = new Rover(0);
            if (String.IsNullOrEmpty(commandType))
            {
                throw new ArgumentNullException(commandType, "Command type required.");
            }
            CommandType = commandType;
            NewMode = modeType;
            newRover.Mode = modeType;

        }
        

        
    }
}
