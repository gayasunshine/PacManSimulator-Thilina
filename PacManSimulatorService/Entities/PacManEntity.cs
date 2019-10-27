using System;
using System.Collections.Generic;
using System.Text;

namespace PacManSimulatorService.Entities
{
   public class PacManEntity
    {
        //holding the value for horizontal movement
        public int xCordinate { get; set; }

        //holding the value for the vertical movement
        public int yCordinate { get; set; }

        //holding the value for the  face direction
        public string faceDirection { get; set; }

        //holding the value for the movement direction
        public string movementDirection { get; set; }

        //holding the order of the commands by the user
        public IList<string> commandSequence { get; set; }

        //Property for the check the commands are provided or not
        public bool isCommandsEmpty { get; set; }


        //Property for the check the validity of the coomand format
        public bool isCommandsValidated { get; set; }

        //Property for the hold responce Message
        public string responceMessage { get; set; }

        //Property for the hold direction identifiere
        public int directionIdentifier { get; set; }

        //Property for the hold Out of Grid 
        public bool isOutOfGrid { get; set; }

        //Property for the hold the end of commands flags
        public bool isCommandsEnd { get; set; }




    }
}
