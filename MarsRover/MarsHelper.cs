using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    /// <summary>
    /// Mars Helper class contians functions for reading the file input and building 
    /// rover & controller objects and enqueues them into respective queues.
    /// </summary>
   public class MarsHelper
    {
        //Get the queue of rovers
        private static Queue<Rover> roverQueue = Mars.getRoverQueue();

        public static bool checkCollision(int _xcoord,int _ycoord, char direction)
        {
            Queue<Rover> collisionCheckQueue = new Queue<Rover>(roverQueue);
            if (collisionCheckQueue.Count == 1)
                return false;
             
            while (!(collisionCheckQueue.Count()==0))
            {
                   Rover rover = collisionCheckQueue.Peek();
                if((rover.getXcoord()==_xcoord) && rover.getYcoord()==_ycoord && rover.getDirection()==direction)
                {
                    return true;
                    
                }

                collisionCheckQueue.Dequeue();
                    
            }
            
            return false;
        }
        //Get the queue of Controllers
        private static Queue<Controller> controllerQueue = Mars.getControllerQueue();
        /// <summary>
        /// Builds Inputs from the file using Stream reader.
        /// </summary>
        /// <param name="args"></param>
        public static void readFromfile(string[] args)
        {

            StreamReader streamReader = null;
            string line = " ";
            int firstline = 0;
            try
            {
                streamReader = new StreamReader(args[0]);

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File Not Found" + e.Message);
                Environment.Exit(-1);
            }
            try
            {
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (firstline == 0)
                    {
                        string[] maxXY= line.Split(' ');
                        int maxX = Convert.ToInt32(maxXY[0]);
                        int maxY = Convert.ToInt32(maxXY[1]);
                        Plateau plateau = null;
                        if (maxX>0 && maxY>0)
                         plateau= new Plateau(maxX, maxY);
                        else
                        {
                            Console.WriteLine("Invalid Upper Right Co-ordinates");
                            Environment.Exit(-1);
                        }
                    }
                    else if((firstline % 2) !=0)
                    {
                        Rover rover = buildRover(line);
                        roverQueue.Enqueue(rover);
                    }
                    else
                    {
                        string controllerInput = line;
                        Controller controller=null;
                        int count = 0;
                        foreach(char ch in controllerInput)
                        {
                            if(ch=='L'||ch=='R'||ch=='M')
                            {
                                count++;
                            }
                        }
                        if(count==controllerInput.Length)
                        {
                            
                            controller = new Controller(line);
                            controllerQueue.Enqueue(controller);
                        }
                        else
                        {
                            
                            Console.WriteLine("Invalid Controller Input");
                            Environment.Exit(-1);
                        }
                       
                    }
                    firstline++;
                }
                
            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading Input" + e.Message);
                Environment.Exit(-1);
            }
            
        }
        /// <summary>
        /// Builds Rover objects by parsing the line
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static Rover buildRover(string line)
        {
            string[] partsOfline = line.Split(' ');
            if (partsOfline.Length != 3)
            {
                Console.WriteLine("Invalid Rover Input");
                Environment.Exit(-1);

            }
            try
            {
                int x = Convert.ToInt32(partsOfline[0]);
                int y = Convert.ToInt32(partsOfline[1]);
                char ch = Convert.ToChar(partsOfline[2]);
                if ((x <= Plateau.getMaxx() && x>=0) && (y<= Plateau.getMaxy() && y>=0) && (ch=='N'||ch=='W'||ch=='E'||ch=='S') )
                return new Rover(x,y,ch);
                else
                {
                    Console.WriteLine("Invalid Rover Input");
                    Environment.Exit(-1);
                    return null;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Rover Parsing"+ex.Message);

                Environment.Exit(-1);
                return null;

            }
            
        }



    }
}
