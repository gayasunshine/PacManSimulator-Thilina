using PacManSimulatorService.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PacManSimulatorService.Intrfaces
{
  public  interface IPacManMovementService
    {
        ReportOutPutEntity ProduceReport(int horizontalCordinate, int verticalCordinate, string faceDirection, List<string> commandSet);
    }
}
