using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MazeExplorer.Core
{
    public interface IDrawExplorerMovementsOnMaze
    {
        void ShowMovementOnMazeMap(IMaze maz, Position position);
        void ShowMovementsHistoryOnMazMap(IMaze maz, List<Position> path);
    }
}
