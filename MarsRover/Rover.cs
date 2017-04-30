using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    /// <summary>
    /// Rover Class has information regarding corodinates and direction. It also has functions 
    /// of SpinLeft, Right and move which perfrom action according to the input of controller.
    /// </summary>
    public class Rover
    {
        private int _xcoord;
        private int _ycoord;
        private char _direction;

        public Rover(int _xcoord, int _ycoord, char _direction)
        {
            this._xcoord = _xcoord;
            this._ycoord = _ycoord;
            this._direction = _direction;
        }

        public int getXcoord()
        {
            return _xcoord;
        }

        public int getYcoord()
        {
            return _ycoord;
        }

        public char getDirection()
        {
            return _direction;
        }

        public void setXcoord(int _xcoord)
        {
            this._xcoord = _xcoord;
        }

        public void setYcoord(int _ycoord)
        {
            this._ycoord = _ycoord;
        }

        public void setDirection(char _direction)
        {
            this._direction = _direction;
        }
        /// <summary>
        /// SpinLeft to change the direction of Rover based on input of Controller.
        /// Skips the action of controller if it finds another rover for the action.
        /// </summary>
        public void spinLeft()
        {
            char currentDirection = getDirection();
            switch (currentDirection)
            {
                case 'N':
                    if(!(MarsHelper.checkCollision(_xcoord, _ycoord, 'W')))
                    setDirection('W');
                    break;
                case 'W':
                    if (!(MarsHelper.checkCollision(_xcoord, _ycoord, 'S')))

                        setDirection('S');
                    break;
                case 'S':
                    if (!(MarsHelper.checkCollision(_xcoord, _ycoord, 'E')))

                        setDirection('E');
                    break;
                case 'E':
                    if (!(MarsHelper.checkCollision(_xcoord, _ycoord, 'N')))

                        setDirection('N');
                    break;
            }
        }
        /// <summary>
        /// SpinRight to change the direction of Rover based on input of Controller.
        /// Skips the action of controller if it finds another rover for the action.
        /// </summary>
        public void spinRight()
        {
            char currentDirection = getDirection();
            switch (currentDirection)
            {
                case 'N':
                    if (!(MarsHelper.checkCollision(_xcoord, _ycoord, 'E')))
                                                setDirection('E');
                    break;
                case 'W':
                    if (!(MarsHelper.checkCollision(_xcoord, _ycoord, 'N')))
                        setDirection('N');
                    break;
                case 'S':
                    if (!(MarsHelper.checkCollision(_xcoord, _ycoord, 'W')))
                                                setDirection('W');
                    break;
                case 'E':
                    if (!(MarsHelper.checkCollision(_xcoord, _ycoord, 'S')))
                        setDirection('S');
                    break;
            }
        }
        /// <summary>
        /// Advance method to change the co-ordinates based on controller input.
        /// Skips the action of controller if it finds another rover for the action, 
        /// or crosses the boundary limits.
        /// </summary>
        public void advance()
        {
            char currentDirection = getDirection();
            switch (currentDirection)
            {
                case 'N':
                    if((_ycoord+1 <= Plateau.getMaxy()) && ( _ycoord+1 >= 0) &&(!(MarsHelper.checkCollision(_xcoord,_ycoord+1,_direction)) ))
                    _ycoord = _ycoord + 1;

                    break;
                case 'W':
                    if((_xcoord-1 <= Plateau.getMaxx())&& (_xcoord-1 >= 0) && (!(MarsHelper.checkCollision(_xcoord-1, _ycoord,_direction))))
                    _xcoord = _xcoord - 1;
                    break;
                case 'E':
                    if ((_xcoord + 1 <= Plateau.getMaxx()) && (_xcoord + 1 >= 0) && (!(MarsHelper.checkCollision(_xcoord+1, _ycoord,_direction))))
                        _xcoord = _xcoord + 1;
                    break;
                case 'S':
                    if ((_ycoord - 1 <= Plateau.getMaxy()) && (_ycoord - 1 >= 0) &&  (!(MarsHelper.checkCollision(_xcoord, _ycoord - 1,_direction))))

                        _ycoord = _ycoord - 1;
                    break;

            }

        }
    }
}
