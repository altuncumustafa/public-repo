using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ConsoleAppMarsRover
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public DirectionCode Direction { get; set; }
        public Position()
        {
        }
        public Position(int _x, int _y, DirectionCode _directionCode)
        {
            this.X = _x;
            this.Y = _y;
            this.Direction = _directionCode;
        }
    }

    public enum DirectionCode
    {
        [Description("North")]
        North = 'N',
        [Description("East")]
        East = 'E',
        [Description("South")]
        South = 'S',
        [Description("West")]
        West = 'W',
    }
}
