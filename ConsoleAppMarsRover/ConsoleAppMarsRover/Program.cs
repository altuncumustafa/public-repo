using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppMarsRover
{
    public class Program
    {
        static Vehicle vehicle = null;
        static Position position = null;
        static DirectionCode directionCode;
        static int DONGU_SAYISI = 2;

        public static void Main()
        {
            try
            {
                #region Plateau 
                Console.WriteLine("Plateau Dimensions (W H):");
                string inputPlateauDimensions = Console.ReadLine();
                string[] arrPlateauDimensions = inputPlateauDimensions.Split(' ');
                if (arrPlateauDimensions.Length != 2)
                {
                    throw new Exception("Error:Plateau Dimensions Count");
                }
                int inputPlateauWidth = 0;
                if (!int.TryParse(arrPlateauDimensions[0], out inputPlateauWidth))
                {
                    throw new Exception("Error:Plateau Dimensions Width");
                }
                int inputPlateauHeiht = 0;
                if (!int.TryParse(arrPlateauDimensions[1], out inputPlateauHeiht))
                {
                    throw new Exception("Error:Plateau Dimensions Height");
                }
                Plateau plateau = new Plateau(inputPlateauWidth, inputPlateauHeiht);
                #endregion
                
                #region Vehicle
                Console.WriteLine("Vehicle Position (X Y D):");
                string inputVehiclePositions = Console.ReadLine();
                string[] arrVehiclePosition = inputVehiclePositions.Split(' ');
                if (arrVehiclePosition.Length != 3)
                {
                    throw new Exception("Error:Vehicle Position Count");
                }
                int inputVehiclePositionX = 0;
                if (!int.TryParse(arrVehiclePosition[0], out inputVehiclePositionX))
                {
                    throw new Exception("Error:Vehicle Position X");
                }
                int inputVehiclePositionY = 0;
                if (!int.TryParse(arrVehiclePosition[1], out inputVehiclePositionY))
                {
                    throw new Exception("Error:Vehicle Position Y");
                }
                directionCode = new DirectionCode();
                switch (arrVehiclePosition[2].Trim())
                {
                    case "N":
                        directionCode = DirectionCode.North;
                        break;
                    case "E":
                        directionCode = DirectionCode.East;
                        break;
                    case "S":
                        directionCode = DirectionCode.South;
                        break;
                    case "W":
                        directionCode = DirectionCode.West;
                        break;
                    default:
                        throw new Exception("Error:Vehicle Position D");
                }
                position = new Position(inputVehiclePositionX, inputVehiclePositionY, directionCode);
                #endregion

                #region Take Position
                vehicle = new Vehicle();
                vehicle.TakePosition(plateau, position);
                #endregion

                #region Command Vehicle
                Console.WriteLine("Commands:");
                string inputVehicleCommands = Console.ReadLine();
                vehicle.Command(inputVehicleCommands);
                string message = string.Format("Last Position : {0} {1} {2}",
                    vehicle.Position.X, vehicle.Position.Y, vehicle.Position.Direction.ToString());
                Console.WriteLine(message);
                #endregion

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
