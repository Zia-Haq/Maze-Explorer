using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeExplorer.Core;

namespace MazeExplorer
{
   public class AutoExplorer:Explorer, IAutoExplorer
    {
        public AutoExplorer(IMaze maze, IDrawExplorerMovementsOnMaze drawMovementsOnMaze)
            : base(maze, drawMovementsOnMaze)
        { }
        
        public bool AutoExplore()
        {
            var beenThere=new bool[_maze.Height,_maze.Width];
            SetExplorerStartingPosition(_maze.StartPosition);

            var foundExit= SolveMaze(CurrentPosition.X, CurrentPosition.Y, beenThere);
            if (foundExit)
                ShowExplorerMovementsOnMaz();
            return foundExit;

        }

        private bool SolveMaze(int x, int y, bool[,] beenThere)
        {
            bool correctPath = false;
            bool shouldCheck=true;
            
            //check for out of boundries
            var position = _maze.MazeMap.FirstOrDefault(m => m.Item1.X == x && m.Item1.Y == y);
            if (position == null)
                return false;
            else
            {
                //check if its finishing point then set shouldcheck to false as reached the exit point
                if(_maze.IsFinishingPoint(position.Item1))
                {
                    correctPath = true;
                    shouldCheck = false;
                }

                //check for a wall or if this position been visited already then return false as not a valid path
                if (_maze.IsWall(position.Item1) || beenThere[x, y])
                    shouldCheck = false;

            }

            //explore differenct directions from current position
            if (shouldCheck)
            {
                beenThere[x, y] = true;

                //move to right and check if its a valid path
                correctPath = correctPath || SolveMaze(x + 1, y, beenThere);

                //move down and check if its a valid path
                correctPath = correctPath || SolveMaze(x, y + 1, beenThere);

                //turn left and check if its a valid path
                correctPath = correctPath || SolveMaze(x - 1, y, beenThere);

                //move up and check if its a valid path
                correctPath = correctPath || SolveMaze(x, y - 1, beenThere);
            }

            //if correct path then add to the explorer path history

            if(correctPath)
                AddNewPositionToPathHistory(new Position() { X = x, Y = y });

            return correctPath;

        }
    }
}
