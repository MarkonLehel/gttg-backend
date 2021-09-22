using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gttgBackend.Models
{
    public class Coordinate
    {
        private static int currentID = 0;

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
            CoordinateID = currentID;
            currentID++;
        }

        public int CoordinateID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }


        public static float CalcDistance(Coordinate cordOne, Coordinate cordTwo)
        {
            return (float) Math.Sqrt(Math.Pow((cordOne.X - cordTwo.X), 2) + Math.Pow((cordOne.Y - cordTwo.Y), 2));
        }
    }
}
