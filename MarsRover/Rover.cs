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
                if (command.CommandType == "MODE_CHANGE")
                {
                    this.Mode = command.NewMode;
                }
            }


            //Command newCommand = new Command();
            //Position = newCommand.NewPostion;
            //Mode = newCommand.NewMode;
        }

        //public Rover (Message message)
        //{
        //    Command newCommand = new Command();
        //    ReceiveMessage(new Message(name, commands));
        //    if (newCommand.CommandType == "Mode_Change")
        //    {
        //        Mode = newCommand.NewMode;
        //    }
        //}

        public override string ToString()
        {
            return "Position: " + Position + " - Mode: " + Mode + " - GeneratorWatts: " + GeneratorWatts; 
        }

        
    }
}
