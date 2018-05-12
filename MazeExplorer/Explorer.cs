using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeExplorer.Core;

namespace MazeExplorer
{
   public class Explorer : IExplorer
    {
        protected readonly IMaze _maze;
        protected List<Position> _explorerMovements;
        protected readonly IDrawExplorerMovementsOnMaze _drawMovementsOnMaze;

       public Position CurrentPosition { get; private set; }

        public Explorer(IMaze maze, IDrawExplorerMovementsOnMaze drawMovementsOnMaze)
        {
            _maze = maze;
            _drawMovementsOnMaze = drawMovementsOnMaze;
            SetExplorerStartingPosition(_maze.StartPosition);

        }

        protected void SetExplorerStartingPosition(Position startingPosition)
        {
            if (_explorerMovements == null)
                _explorerMovements = new List<Position>();
            else
                _explorerMovements.Clear();
            _explorerMovements.Add(startingPosition);//starting point
            CurrentPosition = startingPosition;
        }

        protected void AddNewPositionToPathHistory(Position newPosition)
        {
            if (!_explorerMovements.Contains(newPosition))
                _explorerMovements.Add(newPosition);

        }
        
        public void MoveLeft()
        {
            MoveToNewPosition(new Position() {X=CurrentPosition.X-1,Y=CurrentPosition.Y });
            _drawMovementsOnMaze.ShowMovementOnMazeMap(_maze, CurrentPosition);
        }

        public void MoveRight()
        {
            MoveToNewPosition(new Position() { X = CurrentPosition.X + 1, Y = CurrentPosition.Y });
            _drawMovementsOnMaze.ShowMovementOnMazeMap(_maze, CurrentPosition);
        }

        public void MoveUp()
        {
            MoveToNewPosition(new Position() { X = CurrentPosition.X , Y = CurrentPosition.Y-1 });
            _drawMovementsOnMaze.ShowMovementOnMazeMap(_maze, CurrentPosition);
        }
        public void MoveDown()
        {
            MoveToNewPosition(new Position() { X = CurrentPosition.X, Y = CurrentPosition.Y + 1 });
            _drawMovementsOnMaze.ShowMovementOnMazeMap(_maze, CurrentPosition);
        }

        private void MoveToNewPosition(Position newPosition)
        {
            if (newPosition.X < 0 || newPosition.Y < 0)//can not move forward, out of bound
                return;
            if (newPosition.Y > _maze.Height - 1)//at the edge can not go further
                return;
            if (newPosition.X > _maze.Width - 1)//at the edge can not go further
                return;

            if (_maze.IsWall(newPosition))//can not move to this position as it is a wall
                return;

            //can move to new position

            CurrentPosition = newPosition;
            AddNewPositionToPathHistory(CurrentPosition);
        }

        public void ShowExplorerMovementsOnMaz()
        {
            _drawMovementsOnMaze.ShowMovementsHistoryOnMazMap(_maze, _explorerMovements);
        }

        public bool ReachedFinishingPoint
        {
            get { return _maze.IsFinishingPoint(CurrentPosition); }
        }

        public char GetCharAtCurrentPosition()
        {
            var position= _maze.MazeMap.FirstOrDefault(m => m.Item1.X == CurrentPosition.X && m.Item1.Y == CurrentPosition.Y);

            return position != null ? position.Item2 : '\0';
        }



    }
}
