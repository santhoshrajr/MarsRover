using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    /// <summary>
    /// Plateau class contians information on the maximum boundary of the Mars.
    /// It also checks if a rover is present inside the boundary of Mars.
    /// </summary>
    public class Plateau
    {
        /// <summary>
        /// Static because these wont get changed.
        /// </summary>
        private static int _maxx;
        private static int _maxy;
        public Plateau(int _maxx,int _maxy)
        {
            Plateau._maxx = _maxx;
            Plateau._maxy = _maxy;
        }
        public static int getMaxx()
        {
            return _maxx;
        }

        public static int getMaxy()
        {
            return _maxy;
        }

       
        /// <summary>
        /// Checks if Rover is present inside the boundary conditions.
        /// </summary>
        /// <param name="rover"></param>
        /// <returns></returns>
        //public static bool isRoverInside(Rover rover)
        //{

        //    if (rover.getXcoord() > Plateau._maxx || rover.getYcoord() > Plateau._maxy ||
        //        rover.getXcoord() < 0 || rover.getYcoord() < 0)
        //    {
        //        return false;
        //    }
        //    else
        //        return true;
        //}
    }
}
