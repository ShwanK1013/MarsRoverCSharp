using System;
namespace MarsRover
{
    public class Rover
    {
        public string Mode { get; set; }
        public int Position { get; set; }
        public int GeneratorWatts { get; set; }

        public Rover(int position)
        {
            Position = position;
            Mode = "NORMAL";
            GeneratorWatts = 110;
        }
        
        public void ReceiveMessage(Message message)
        {
            foreach (Command command in message.Commands)
            {
                if (command.CommandType != "MODE_CHANGE" && command.CommandType != "MOVE")
                {
                    throw new InvalidOperationException("Unknown Command");
                }
                if (command.CommandType == "MODE_CHANGE")
                {
                    this.Mode = command.NewMode;
                }

                if (command.NewMode=="LOW_POWER")
                {

                    throw new InvalidOperationException("Does Not Move In LowPower");
                    
                }
                else
                {
                    this.Position = command.NewPostion;
                }
            }


            //Command newCommand = new Command();
            //Position = newCommand.NewPostion;
            //Mode = newCommand.NewMode;
        }

        

        public override string ToString()
        {
            return "Position: " + Position + " - Mode: " + Mode + " - GeneratorWatts: " + GeneratorWatts; 
        }

        
    }
}
