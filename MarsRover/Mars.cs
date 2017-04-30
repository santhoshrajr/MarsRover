using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    /// <summary>
    /// Mars class is the start point of the porgram. It has information of all Rovers and Controller
    /// in global queues. It has function which calcualtes output of Rover.
    /// </summary>
    public class Mars
    {
        //Queue of Rovers
        private static Queue<Rover> RoverQueue = new Queue<Rover>();
        public static Queue<Rover> getRoverQueue()
        {
            return RoverQueue;
        }
        //Queue of COntrollers
        private static Queue<Controller> ControllerQueue = new Queue<Controller>();
        public static Queue<Controller> getControllerQueue()
        {
            return ControllerQueue;
        }
        /// <summary>
        /// Entry point of program
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            MarsHelper.readFromfile(args);
            List<string> printRovers=getFinalCoords(RoverQueue, ControllerQueue);
            foreach(string s in printRovers)
            {
                Console.WriteLine(s);
            }

        }
        /// <summary>
        /// Stores output of Rovers in Output list of strings.
        /// </summary>
        /// <param name="roverQueue"></param>
        /// <param name="controllerQueue"></param>
        /// <returns></returns>
        private static List<string> getFinalCoords(Queue<Rover> roverQueue, Queue<Controller> controllerQueue)
        {
            List<string> output = new List<string>();
            Queue<Rover> roverQueueC = new Queue<Rover>(RoverQueue);
            Queue<Controller> controllerQueueC = new Queue<Controller>(ControllerQueue);


            while (!(roverQueueC.Count()==0))
            {
                Rover rover = roverQueueC.Peek();
                Controller controller = controllerQueueC.Peek();
                string commands = controller.getCommands();
                foreach(char ch in commands)
                {
                    switch(ch)
                    {
                        case 'L':rover.spinLeft();
                            break;
                        case 'R':rover.spinRight();
                            break;
                        case 'M':rover.advance();
                            break;
                    }
                   
                }
                output.Add(rover.getXcoord() + " " + rover.getYcoord() + " " + rover.getDirection());
                
                roverQueueC.Dequeue();
                controllerQueueC.Dequeue();
            }
            return output;
           
        }
    }
}
