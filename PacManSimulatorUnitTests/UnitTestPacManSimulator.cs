using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacManSimulatorService.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using PacManSimulatorService.Service;

namespace PacManSimulatorUnitTests
{
    [TestClass]
    public  class UnitTestPacManSimulator
    {
        //Test the PacMan GenerateFinal Report root Method with Positive inputs
        [TestMethod]
        public void  IsValiedReportOutput()
        {
            int horizontalCordinate = 2;
            int verticalCordinate = 2;
            string faceDirectionInput = "NORTH";
            List<string> commands = new List<string>();
            commands.Add("PLACE");
            commands.Add("MOVE");
            commands.Add("MOVE");
            commands.Add("LEFT");
            commands.Add("REPORT");
            ReportOutPutEntity report = new ReportOutPutEntity();
            PacManMovementService service = new PacManMovementService();
            int actualHorizontalCordinate = 2;
            int actualVerticalCordinates = 4;
            string actualFaceDirection = "WEST";
            report = service.ProduceReport(horizontalCordinate, verticalCordinate, faceDirectionInput, commands);
            Assert.AreEqual(report.horizontalCordinate, actualHorizontalCordinate);
            Assert.AreEqual(report.verticalCordinate, actualVerticalCordinates);
            Assert.AreEqual(report.faceDirection, actualFaceDirection);



        }

        [TestMethod]
        public void IsPacManOutOfGrid()
        {
            int horizontalCordinate = 2;
            int verticalCordinate = 2;
            string faceDirectionInput = "EAST";
            List<string> commands = new List<string>();
            commands.Add("PLACE");
            commands.Add("MOVE");
            commands.Add("MOVE");
            commands.Add("MOVE");
            commands.Add("MOVE");
            commands.Add("REPORT");
            ReportOutPutEntity report = new ReportOutPutEntity();
            PacManMovementService service = new PacManMovementService();
            string actualResponceMessage = "Pac Man is Out of Grid";
            report = service.ProduceReport(horizontalCordinate, verticalCordinate, faceDirectionInput, commands);
            Assert.AreEqual(report.responceMessage, actualResponceMessage);



        }



        [TestMethod]
        public void IsCommandsInCorrectFormat()
        {
            int horizontalCordinate = 2;
            int verticalCordinate = 2;
            string faceDirectionInput = "DFDF";
            List<string> commands = new List<string>();
            commands.Add("FDFDDFD");
            commands.Add("DFDFDF");
            commands.Add("DFDFDF");
            commands.Add("MOVE");
            commands.Add("DFDFDF");
            commands.Add("REPORT");
            ReportOutPutEntity report = new ReportOutPutEntity();
            PacManMovementService service = new PacManMovementService();
            string actualResponceMessage = "Command is not in Correct Format";
            report = service.ProduceReport(horizontalCordinate, verticalCordinate, faceDirectionInput, commands);
            Assert.AreEqual(report.responceMessage, actualResponceMessage);



        }


        [TestMethod]
        public void IsRunningWithoutReportCommand()
        {
            int horizontalCordinate = 2;
            int verticalCordinate = 2;
            string faceDirectionInput = "NORTH";
            List<string> commands = new List<string>();
            commands.Add("MOVE");
            commands.Add("MOVE");
            ReportOutPutEntity report = new ReportOutPutEntity();
            PacManMovementService service = new PacManMovementService();
            string actualResponceMessage = "Command is not in Correct Format";
            report = service.ProduceReport(horizontalCordinate, verticalCordinate, faceDirectionInput, commands);
            Assert.AreEqual(report.responceMessage, actualResponceMessage);



        }


    }
}
