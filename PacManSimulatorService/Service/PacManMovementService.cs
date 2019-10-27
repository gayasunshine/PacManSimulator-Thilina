using PacManSimulatorService.Entities;
using PacManSimulatorService.Intrfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PacManSimulatorService.Service
{

 

    public class PacManMovementService:IPacManMovementService
    {
        //Constant Variables region
        public const string PlaceCommand = "PLACE";
        public const string SucsessMessage = "Command is in valid Format";
        public const string FalierMessage = "Command is not in Correct Format";
        public const string MoveCommand = "MOVE";
        public const string DirectionCommandLeft = "LEFT";
        public const string DirectionCommandRight = "RIGHT";

        public const string DirectionNorth = "NORTH";
        public const string DirectionEast = "EAST";
        public const string DirectionSouth = "SOUTH";
        public const string DirectionWest = "WEST";
        public const string ReportCommand = "REPORT";
        public const string OutOfGridText = "Pac Man is Out of Grid";



        //Produsing the final outcome based on the user commands
        public ReportOutPutEntity ProduceReport(int horizontalCordinate, int verticalCordinate, string faceDirection, List<string> commandSet)
        {
            //Initiating the new pacMan Report instance to return final outcome.
            ReportOutPutEntity pacManReport = new ReportOutPutEntity();
            pacManReport = GenerateReportOutPut(horizontalCordinate, verticalCordinate, faceDirection, commandSet);
            
            

            return pacManReport;
        }

        private ReportOutPutEntity GenerateReportOutPut(int horizontalCordinate, int verticalCordinate, string faceDirection, List<string> commandSet)
        {
            ReportOutPutEntity pacManReport = new ReportOutPutEntity();
            PacManEntity populatedEntity = PopulatePacManEntity(horizontalCordinate, verticalCordinate, faceDirection, commandSet);

            //resolved location
            populatedEntity = locationResolver(populatedEntity);

            //Check wheter PacMan is out of Grid
            if(populatedEntity.isOutOfGrid)
            {
                pacManReport.responceMessage = OutOfGridText;
               
            }

            else
            {
                pacManReport.horizontalCordinate = populatedEntity.xCordinate;
                pacManReport.verticalCordinate = populatedEntity.yCordinate;
                pacManReport.responceMessage = populatedEntity.responceMessage;
                pacManReport.faceDirection = populatedEntity.faceDirection;
                pacManReport.isValiedCommands = populatedEntity.isCommandsValidated;
                pacManReport.responceMessage = populatedEntity.responceMessage;
            }

            return pacManReport;
        }

        //Populate the Pacman Entity based on the User inputs by UI
        private PacManEntity PopulatePacManEntity(int horizontalCordinate, int verticalCordinate, string faceDirection, List<string> commandSet)
        {
            //Populate Entity Properties based on arguments
            PacManEntity pacManData = new PacManEntity();

            pacManData = ValidateAllUserInputs(horizontalCordinate, verticalCordinate, faceDirection, commandSet);

            if (pacManData != null && !pacManData.isCommandsEmpty && pacManData.isCommandsValidated)
            {
                //Set First level user inputs
                pacManData.xCordinate = horizontalCordinate;
                pacManData.yCordinate = verticalCordinate;

                //set commmand level inputs
                if (commandSet != null && commandSet.Count > 0)
                {
                    List<string> commandList = new List<string>();
                    foreach (var item in commandSet)
                    {
                        commandList.Add(item);
                        //Check whether is Report Command is exist on Command List
                        if(item.ToLower() != ReportCommand.ToLower())
                        {
                            pacManData.isCommandsValidated = false;
                            pacManData.responceMessage = FalierMessage;
                        }

                        else
                        {
                            pacManData.isCommandsValidated = true;
                            pacManData.responceMessage = SucsessMessage;
                        }
                    }
                    pacManData.commandSequence = commandList;
                }

                else
                {
                    pacManData.isCommandsEmpty = false;
                }
            }
           

            return pacManData;
        }

        //Validate all User Inputs in Correct Format
        public PacManEntity ValidateAllUserInputs(int horizontalCordinate, int verticalCordinate, string faceDirection, List<string> commandSet)
        {
            PacManEntity validatedPacManData = new PacManEntity();
            if(string.IsNullOrEmpty(faceDirection))
            {
                validatedPacManData.isCommandsEmpty = true;
                return validatedPacManData;
            }

            else if(!string.IsNullOrEmpty(faceDirection))
            {
                if(IsFaceDirectionValied(faceDirection))
                {
                    validatedPacManData.isCommandsValidated = true;
                    validatedPacManData.faceDirection = faceDirection.ToUpper();
                    
                    
                }

                else
                {
                    validatedPacManData.isCommandsValidated = false;
                    validatedPacManData.faceDirection = string.Empty;
                    validatedPacManData.responceMessage = FalierMessage;
                    return validatedPacManData;
                }
            }

            if (commandSet != null && commandSet.Count > 0)
            {
                //check whether first command is in correct format

                    string firstCommand = commandSet[0];
                    if (firstCommand.ToLower() == PlaceCommand.ToLower())
                    {
                        validatedPacManData.isCommandsValidated = true;
                       

                    //Validate other User Inputs
                    foreach (var item in commandSet)
                    {
                        if(item.ToLower() ==  MoveCommand.ToLower())
                        {
                            validatedPacManData.isCommandsValidated = true;
                        }

                        else if(item.ToLower() == DirectionCommandLeft.ToLower())
                        {
                            validatedPacManData.isCommandsValidated = true;
                        }

                        else if (item.ToLower() == DirectionCommandRight.ToLower())
                        {
                            validatedPacManData.isCommandsValidated = true;
                        }

                        else if (item.ToLower() != MoveCommand.ToLower() && item.ToLower() != DirectionCommandLeft.ToLower() && item.ToLower() != DirectionCommandRight.ToLower() && item.ToLower() != ReportCommand.ToLower() && item.ToLower() != PlaceCommand.ToLower())
                        {
                            validatedPacManData.isCommandsValidated = false;
                            return validatedPacManData;
                        }

                        else if (item.ToLower() == ReportCommand.ToLower())
                        {
                            
                            return validatedPacManData;
                        }

                        else 
                        {
                            validatedPacManData.isCommandsValidated = false;
                            
                        }
                    }
                    }

                    else
                    {
                        validatedPacManData.isCommandsValidated = false;
                        validatedPacManData.responceMessage = FalierMessage;
                    }
                
            }

            else
            {
                validatedPacManData.isCommandsValidated = false;
                validatedPacManData.responceMessage = FalierMessage;
            }


            return validatedPacManData;
        }


        //Validate face direction

        private bool IsFaceDirectionValied(string direction)
        {
            if(direction.ToLower() == DirectionNorth.ToLower())
            {
                return true;
            }

           else if (direction.ToLower() == DirectionEast.ToLower())
            {
                return true;
            }

           else if (direction.ToLower() == DirectionSouth.ToLower())
            {
                return true;
            }

           else if (direction.ToLower() == DirectionWest.ToLower())
            {
                return true;
            }

            else
            {
              return  false;
            }
        }

        //Location Resolver

        private PacManEntity locationResolver(PacManEntity pacManData)
        {
            //Validate against face direction
            if(pacManData != null)
            {
                if(pacManData.faceDirection.ToLower() == DirectionNorth.ToLower() && pacManData.isCommandsEnd == false)
                {
                    //call to property seeter based on commands
                    pacManData.directionIdentifier = 1;
                    propertySetterForLocation(pacManData);

                }

                if (pacManData.faceDirection.ToLower() == DirectionEast.ToLower() && pacManData.isCommandsEnd == false)
                {
                    //call to property seeter based on commands
                    pacManData.directionIdentifier = 2;
                    propertySetterForLocation(pacManData);

                }

                if (pacManData.faceDirection.ToLower() == DirectionSouth.ToLower() && pacManData.isCommandsEnd == false)
                {
                    //call to property seeter based on commands
                    pacManData.directionIdentifier = 3;
                    propertySetterForLocation(pacManData);

                }

                if (pacManData.faceDirection.ToLower() == DirectionWest.ToLower() && pacManData.isCommandsEnd == false)
                {
                    //call to property seeter based on commands
                    pacManData.directionIdentifier = 4;
                    propertySetterForLocation(pacManData);

                }
            }
            return pacManData;
        }

        //Property setter against commands by user

        private PacManEntity propertySetterForLocation(PacManEntity pacManData)
        {
            if (pacManData.commandSequence != null)
            {
                if (pacManData.commandSequence.Count > 0)
                {

                    foreach (var item in pacManData.commandSequence)
                    {
                        //If report command find loop will exit
                        if (item.ToLower() == ReportCommand.ToLower())
                        {
                            pacManData.isCommandsEnd = true;
                            break;
                        }

                        if (item.ToLower() == MoveCommand.ToLower())
                        {
                            if (pacManData.directionIdentifier == 1)
                            {
                                pacManData.yCordinate += 1;
                            }

                            else if (pacManData.directionIdentifier == 2)
                            {
                                pacManData.xCordinate += 1;
                            }

                            else if (pacManData.directionIdentifier == 3)
                            {
                                pacManData.yCordinate -= 1;
                            }

                            else if (pacManData.directionIdentifier == 4)
                            {
                                pacManData.xCordinate -= 1;
                            }
                        }


                        if (item.ToLower() == DirectionCommandLeft.ToLower())
                        {
                            if (pacManData.directionIdentifier == 1)
                            {
                                pacManData.directionIdentifier = 1 + 3;
                                pacManData.faceDirection = DirectionWest;
                                continue;
                            }

                            if (pacManData.directionIdentifier == 2)
                            {
                                pacManData.directionIdentifier = 2 - 1;
                                pacManData.faceDirection = DirectionNorth;
                                continue;
                            }

                            if (pacManData.directionIdentifier == 3)
                            {
                                pacManData.directionIdentifier = 3 - 1;
                                pacManData.faceDirection = DirectionEast;
                                continue;
                            }

                            if (pacManData.directionIdentifier == 4)
                            {
                                pacManData.directionIdentifier = 4 - 1;
                                pacManData.faceDirection = DirectionSouth;
                                continue;
                            }
                        }


                        if (item.ToLower() == DirectionCommandRight.ToLower())
                        {
                            if (pacManData.directionIdentifier == 1)
                            {
                                pacManData.directionIdentifier = 1 + 1;
                                pacManData.faceDirection = DirectionEast;
                                continue;
                            }

                            if (pacManData.directionIdentifier == 2)
                            {
                                pacManData.directionIdentifier = 2 + 1;
                                pacManData.faceDirection = DirectionSouth;
                                continue;
                            }

                            if (pacManData.directionIdentifier == 3)
                            {
                                pacManData.directionIdentifier = 3 + 1;
                                pacManData.faceDirection = DirectionWest;
                                continue;
                            }

                            if (pacManData.directionIdentifier == 4)
                            {
                                pacManData.directionIdentifier = 4 - 3;
                                pacManData.faceDirection = DirectionNorth;
                                continue;
                            }
                        }




                    }
                }

                if (pacManData.xCordinate > 5)
                {
                    pacManData.isOutOfGrid = true;
                }

                
            }
            return pacManData;
        }
    }
}
