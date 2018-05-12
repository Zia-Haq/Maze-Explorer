using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeExplorer.Core;

namespace MazeExplorer
{
  public  class DrawExplorerMovementsOnMaze : IDrawExplorerMovementsOnMaze
    {
        public void ShowMovementOnMazeMap(IMaze maze, Position position)
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            if (!maze.IsFinishingPoint(position))
                Console.Write(maze.StartSymbol);
            Console.SetCursorPosition(position.X,position.Y);
        }

        public void ShowMovementsHistoryOnMazMap(IMaze maze, List<Position> path)
        {
            Console.Clear();
            for(int i=0;i < maze.Height;i++)
            {
               for(int j=0;j < maze.Width;j++)
               {
                   var position = maze.MazeMap.FirstOrDefault(m => m.Item1.X == j && m.Item1.Y == i);
                   Console.ResetColor();
                   if (path.Contains(position.Item1))
                   {
                       Console.ForegroundColor = ConsoleColor.Black;
                       if (position.Item2 == maze.StartSymbol || position.Item2 == maze.FinishSymbol)
                       {
                           Console.BackgroundColor = ConsoleColor.Red;
                           Console.Write(position.Item2);
                       }
                       else
                       {
                           Console.BackgroundColor = ConsoleColor.Yellow;
                           Console.Write("*");

                       }

                   }
                   else if (position.Item2 == maze.StartSymbol || position.Item2 == maze.FinishSymbol)
                   {
                       Console.BackgroundColor = ConsoleColor.Red;
                       Console.Write(position.Item2);
                   }
                   else
                       Console.Write(position.Item2);

               }
               Console.Write(Environment.NewLine);
            }
        }
    }
}
