using System;
using System.Collections.Generic;
using System.Text;

namespace PacManSimulatorService.Entities
{
   public class ReportOutPutEntity
    {
        //holding the value for horizontal movement
        public int horizontalCordinate { get; set; }

        //holding the value for the vertical movement
        public int verticalCordinate { get; set; }

        //holding the value for the  face direction
        public string faceDirection { get; set; }

        //holding the boolean value for the  valied command check
        public bool isValiedCommands { get; set; }

        //holding the  value for the  responce message
        public string responceMessage { get; set; }
    }
}
