using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator
{
    /// <summary>
    /// Direction of the robot to face
    /// </summary>
    enum Direction
    {
        NORTH,
        EAST,
        SOUTH,
        WEST
    }

    internal class Robot
    {
        private int _x, _y;
        private bool _isplaced;
        private Direction _direction;

        /// <summary>
        /// Creates an object of the class Robot
        /// </summary>
        public Robot() 
        {
            _isplaced = false;  
        }

        /// <summary>
        /// Checks if the robot is placed or not.
        /// </summary>
        /// <returns>returns true if the robot is placed, else returns false</returns>
        public bool isPlaced() 
        {
            return _isplaced; 
        }  

        /// <summary>
        /// Sets the robot at a position with x and y coordinates with direction NORTH, EAST, SOUTH or WEST
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="direction"></param>
        public void SetPosition(int x, int y, Direction direction)
        {
            _isplaced = true;
            if (x >= 0 && x <= 4 && y >= 0 && y <= 4)
            {
                _x = x;
                _y = y;
                _direction = direction;
            }
            else
            {
                Console.WriteLine("Out of bounds!");
            }
        }

        /// <summary>
        /// Displays the positions and direction of the robot
        /// </summary>
        public void ReportPosition()
        {
            Console.WriteLine($"Current Position: {_x},{_y},{_direction}");
        }

        /// <summary>
        /// Turns the robot clockwise
        /// </summary>
        public void TurnRight()
        {
            if (_direction == Direction.WEST)
            {
                _direction = Direction.NORTH;
            }
            else 
            {
                _direction++;
            }
        }

        /// <summary>
        /// Turns the robot counterclockwise
        /// </summary>
        public void TurnLeft()
        {
            if (_direction == Direction.NORTH)
            {
                _direction= Direction.WEST;    
            }
            else
            {
                _direction--;
            }
        }

        /// <summary>
        /// Moves the robot forward depending on the direction it is facing
        /// </summary>
        public void MovePosition()
        {
            switch (_direction)
            {
                case Direction.NORTH:
                    if (_y == 4)
                    {
                        Console.WriteLine("Invalid direction! Out of bounds!");
                        ReportPosition();
                        return;
                    }
                    _y++;
                    break;
                case Direction.SOUTH:
                    if (_y == 0)
                    {
                        Console.WriteLine("Invalid direction! Out of bounds!");
                        ReportPosition();
                        return;
                    }
                    _y--;
                    break;
                case Direction.EAST:
                    if (_x == 4) {
                        Console.WriteLine("Invalid direction! Out of bounds!");
                        ReportPosition();
                        return;
                    }
                    _x++;
                    break;
                case Direction.WEST:
                    if (_x == 0)
                    {
                        Console.WriteLine("Invalid direction! Out of bounds!");
                        ReportPosition();
                        return;
                    }    
                    _x--;
                    break;
                default:
                    break;
            }
        }
    }
}
