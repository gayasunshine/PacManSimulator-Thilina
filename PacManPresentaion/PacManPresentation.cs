using PacManSimulatorService.Entities;
using PacManSimulatorService.Intrfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PacManPresentaion
{
   public class PacManPresentation
    {
        public IPacManMovementService pacManMovementService;
        public PacManPresentation(IPacManMovementService pacManMovementService)
        {
            this.pacManMovementService = pacManMovementService;
        }

        public ReportOutPutEntity FinalizePacManReport(int horizontalCordinate , int verticalCordinate , string faceDirection , List<string> commandSet)
        {


            return pacManMovementService.ProduceReport(horizontalCordinate, verticalCordinate, faceDirection, commandSet);
        }
    }
}
