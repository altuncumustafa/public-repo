using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppMarsRover
{
    public class Plateau
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Plateau ()
        {

        }

        public Plateau(int _width, int _height)
        {
            this.Width = _width;
            this.Height = _height;
        }

        public bool BorderControl(int _width, int _height)
        {
            if(_width <0 || _width > this.Width)
            {
                return false;
            }
            if(_height < 0 || _height > this.Height)
            {
                return false;
            }
            return true;
        }
    }
}
