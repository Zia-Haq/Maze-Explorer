using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeExplorer.Core;

namespace MazeExplorer.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //handle any unhandled exceptions
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
                {
                   
                    Console.WriteLine("Unhandled Exception. Exception:" + (e.ExceptionObject as Exception).ToString());
                };

            try
            {
                var mazeResourceFile = ConfigurationManager.AppSettings["MazeResourceFile"];
                if (string.IsNullOrWhiteSpace(mazeResourceFile))
                {
                    Console.WriteLine("Maze resource file not configured. Press Enter key to exit.....");
                    Console.ReadLine();
                    return;
                }
                mazeResourceFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, mazeResourceFile);
                if (!File.Exists(mazeResourceFile))
                {
                    Console.WriteLine("Maze resource file doest not exist. Press Enter key to exit.....");
                    Console.ReadLine();
                    return;
                }

                var maze = new Maze();

                maze.CreateMazeMap(File.ReadAllLines(mazeResourceFile));
                if (!maze.IsValidMaz)
                {
                    Console.WriteLine("Maze resource file is not a valid file, must have exactly one start and finishing point. Press Enter key to exit.....");
                    Console.ReadLine();
                    return;
                    
                }
                else
                {
                    Console.WriteLine("Maze map has been created successfully.");
                    Console.WriteLine("Maze Walls:"+maze.TotalWalls());
                    Console.WriteLine("Maze Spaces:" + maze.TotalSpaces());
                    Console.WriteLine("Maze Width:" + maze.Width);
                    Console.WriteLine("Maze Height:" + maze.Height);
                    Console.WriteLine(string.Format("Maze Start Position, X:{0},Y:{1}" , maze.StartPosition.X,maze.StartPosition.Y));
                    Console.WriteLine(string.Format("Maze Finishing Position, X:{0},Y:{1}" , maze.FinishPosition.X, maze.FinishPosition.Y));
                   
                    Console.WriteLine();


                }

                var drawExplorerMovementsOnMaze = new DrawExplorerMovementsOnMaze();
                IAutoExplorer autoExplore = new AutoExplorer(maze, drawExplorerMovementsOnMaze);
                IExplorer explorer = autoExplore as IExplorer;
                
                Console.WriteLine("Shortly maze will be displayed.");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You can navigate from the start postion to finishing point using keyboard left, right, down and up arrow keys.");
                Console.ResetColor();
                Console.WriteLine("Press Enter key to continue.....");
                Console.ReadLine();
                Console.Clear();
                //Set the x, y coordinates and draw the maze
               explorer.ShowExplorerMovementsOnMaz();
               Console.SetCursorPosition(maze.StartPosition.X, maze.StartPosition.Y);
               while (!explorer.ReachedFinishingPoint)
               {
                   var key = Console.ReadKey().Key;

                   switch (key)
                   {
                       case ConsoleKey.DownArrow:
                           explorer.MoveDown();
                           break;
                       case ConsoleKey.UpArrow:
                           explorer.MoveUp();
                           break;
                       case ConsoleKey.RightArrow:
                           explorer.MoveRight();
                           break;
                       case ConsoleKey.LeftArrow:
                           explorer.MoveLeft();
                           break;
                        default:
                           Console.SetCursorPosition(explorer.CurrentPosition.X, explorer.CurrentPosition.Y);
                           break;
                   }

               }

               Console.Beep();
               Console.Beep();
            
               Console.WriteLine();
               Console.WriteLine();
               Console.WriteLine("You have successfully made to the exit. Press Enter key to see the path taken from start to finish.....");
               Console.ReadLine();
               Console.Clear();
               explorer.ShowExplorerMovementsOnMaz();
               Console.WriteLine();
               Console.WriteLine();
               Console.WriteLine("Auto explorer will run shortly and will display the path taken on Maze. Press Enter key to continue.....");
               Console.ReadLine();
               Console.Clear();
               Console.WriteLine("Running the autoexplorer now......");
               System.Threading.Thread.Sleep(1000);
               autoExplore.AutoExplore();
               Console.WriteLine();
               Console.WriteLine();
               Console.WriteLine("Press Enter key to exit the process.....");
               Console.ReadLine();
            }

            catch(Exception ex)
            {
                Console.WriteLine("Errored while exploring the Maze. Exception:" + ex.ToString());
                Console.ReadLine();
            }
        
        }
    }
}
