using PacManPresentaion;
using PacManSimulatorService.Entities;
using PacManSimulatorService.Service;
using System;
using System.Collections.Generic;

namespace PacManSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            PacManPresentation pacManPresentation = new PacManPresentation(new PacManMovementService());


            //Implement the UI
            Console.WriteLine("--Welcome to PacMan Simulator--");
            Console.Write("Please Enter Initial Place Command: ");
            string initialCommand = Console.ReadLine();
            

                try
                {
                    Console.Write("Please Enter X Cordination: ");
                    int xCordination = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Please Enter Y Cordination: ");
                    int yCordination = Convert.ToInt32(Console.ReadLine());




                    Console.Write("Please Enter Direction: ");
                    string direction = Console.ReadLine();

                    Console.Write("Please Enter Movement Commands(Comma Separated: ");
                    string movementCommands = Console.ReadLine();

                    //Add the all commands to List
                    List<string> commandsList = new List<string>();
                    commandsList.Add(initialCommand);
                    foreach (var item in movementCommands.Split(','))
                    {
                        commandsList.Add(item);
                    }







                    ReportOutPutEntity reportOutPut = pacManPresentation.FinalizePacManReport(xCordination, yCordination, direction, commandsList);
                    if (reportOutPut.isValiedCommands)
                    {
                        Console.WriteLine(reportOutPut.faceDirection);
                        Console.WriteLine(reportOutPut.horizontalCordinate);
                        Console.WriteLine(reportOutPut.verticalCordinate);
                    }

                    Console.WriteLine(reportOutPut.responceMessage);
                }

                catch (FormatException)
                {
                    Console.WriteLine("Input is not in correct Format");
                }




            }
        
    }
}
