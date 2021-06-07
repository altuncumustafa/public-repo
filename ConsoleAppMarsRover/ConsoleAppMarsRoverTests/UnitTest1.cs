using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppMarsRoverTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodPosition()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                var expected = new ConsoleAppMarsRover.Position()
                {
                    X = 1,
                    Y = 2,
                    Direction = ConsoleAppMarsRover.DirectionCode.North
                };

                var actual = new ConsoleAppMarsRover.Position(1, 2, ConsoleAppMarsRover.DirectionCode.North);
                
                Assert.IsTrue(expected.X == actual.X);
            }
        }
        
        [TestMethod]
        public void TestMethodPlateauBorderControl()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                var expected = false;

                ConsoleAppMarsRover.Plateau plateau = new ConsoleAppMarsRover.Plateau()
                {
                    Width = 5,
                    Height = 5
                };

                var actual = plateau.BorderControl(7, 7);

                Assert.IsTrue(expected == actual);
            }
        }

        [TestMethod]
        public void TestMethodVehicleMove()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                ConsoleAppMarsRover.Position expectedPosition = new ConsoleAppMarsRover.Position()
                {
                    X = 1,
                    Y = 3,
                    Direction = ConsoleAppMarsRover.DirectionCode.North
                };

                ConsoleAppMarsRover.Position position = new ConsoleAppMarsRover.Position()
                {
                    X = 1,
                    Y = 2,
                    Direction = ConsoleAppMarsRover.DirectionCode.North
                };
                ConsoleAppMarsRover.Plateau plateau = new ConsoleAppMarsRover.Plateau()
                {
                    Width = 5,
                    Height = 5                };

                ConsoleAppMarsRover.Vehicle vehicle = new ConsoleAppMarsRover.Vehicle()
                {
                    Position = position,
                    Plateau = plateau
                };

                vehicle.Move();

                Assert.IsTrue(expectedPosition.Y == vehicle.Position.Y);
            }
        }
    }
}
