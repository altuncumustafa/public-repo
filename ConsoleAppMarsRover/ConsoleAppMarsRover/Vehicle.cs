using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel;

namespace ConsoleAppMarsRover
{
    public class Vehicle
    {
        public Plateau Plateau { get; set; }
        public Position Position { get; set; }

        public Vehicle()
        {
        }

        public void TakePosition(Plateau _plateau, Position _position)
        {
            try
            {
                this.Plateau = _plateau;
                this.Position = _position;
            }
            catch(Exception ex)
            {
                throw new Exception("Error: TakePosition - " + ex.Message);
            }
        }

        public void Command(string command)
        {
            try
            {
                string nextCommand = "";
                for (int i = 0; i < command.Length; i++)
                {
                    nextCommand = command.Substring(i, 1);
                    switch (nextCommand)
                    {
                        case "M":
                            this.Move();
                            break;
                        case "L":
                            this.TurnLeft();
                            break;
                        case "R":
                            this.TurnRight();
                            break;
                        default:
                            throw new Exception("Error: Wrong Command");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: Command - " + ex.Message);
            }
        }

        public void Move()
        {
            try
            {
                int newPositionX = this.Position.X,
                    newPositionY = this.Position.Y;

                switch (this.Position.Direction)
                {
                    case DirectionCode.North:
                        newPositionY = this.Position.Y + 1;
                        break;
                    case DirectionCode.East:
                        newPositionX = this.Position.X + 1;
                        break;
                    case DirectionCode.South:
                        newPositionY = this.Position.Y - 1;
                        break;
                    case DirectionCode.West:
                        newPositionX = this.Position.X - 1;
                        break;
                }

                if(!this.Plateau.BorderControl(newPositionX, newPositionY))
                {
                    string message = string.Format("Can't leave area.Last Position : {0} {1} {2}", 
                                    this.Position.X, this.Position.Y, this.Position.Direction.ToString());
                    throw new Exception(message);
                }

                this.Position.X = newPositionX;
                this.Position.Y = newPositionY;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: Move - " + ex.Message);
            }
        }

        public void TurnRight()
        {
            try
            {
                switch(this.Position.Direction)
                {
                    case DirectionCode.North:
                        this.Position.Direction = DirectionCode.East;
                        break;
                    case DirectionCode.East:
                        this.Position.Direction = DirectionCode.South;
                        break;
                    case DirectionCode.South:
                        this.Position.Direction = DirectionCode.West;
                        break;
                    case DirectionCode.West:
                        this.Position.Direction = DirectionCode.North;
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: TurnRight - " + ex.Message);
            }
        }

        public void TurnLeft()
        {
            try
            {
                switch (this.Position.Direction)
                {
                    case DirectionCode.North:
                        this.Position.Direction = DirectionCode.West;
                        break;
                    case DirectionCode.East:
                        this.Position.Direction = DirectionCode.North;
                        break;
                    case DirectionCode.South:
                        this.Position.Direction = DirectionCode.East;
                        break;
                    case DirectionCode.West:
                        this.Position.Direction = DirectionCode.South;
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: TurnLeft - " + ex.Message);
            }
        }
    }

    
}
