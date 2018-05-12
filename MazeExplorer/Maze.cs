using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeExplorer.Core;

namespace MazeExplorer
{
   public class Maze:IMaze
    {
        protected readonly char _wall;
        protected readonly char _space;
        protected readonly char _start;
        protected readonly char _finish;

        public char WallSymbol { get { return _wall; } }
        public char SpaceSymbol { get { return _space; } }
        public char StartSymbol { get { return _start; } }
        public char FinishSymbol { get { return _finish; } }

        public List<Tuple<Position, char>> MazeMap { get; private set; }

        public virtual Position StartPosition {get;set;}
        public virtual Position FinishPosition { get; set; }

        public virtual int Width { get; private set; }
        public virtual int Height { get; private set; }
        public virtual bool IsWall(Position position)
        {
            return MazeMap.Exists(m => m.Item1.Equals(position) && m.Item2 == WallSymbol);
        }

        public virtual bool IsFinishingPoint(Position position)
        {
            return MazeMap.Exists(m => m.Item1.Equals(position) && m.Item2 == FinishSymbol);
        }

        public virtual bool IsValidMaz
        {
            //there must be exactly one start and finish points
            get
            {

                return
                    ((MazeMap.FindAll(m => m.Item2 == StartSymbol).Count == 1) &&
                       (MazeMap.FindAll(m => m.Item2 == FinishSymbol).Count == 1));
            }

        }
        public Maze()
        {
            _wall = 'X';
            _space = ' ';
            _start = 'S';
            _finish = 'F';
            MazeMap = new List<Tuple<Position, char>>();
        }

        public void CreateMazeMap(string[] lines)
        {
            if (lines == null && lines.Length == 0)
                throw new ArgumentException("The 'lines' argument should not be null");
            
            Width = lines[0].Length;
            Height = lines.Length;
            MazeMap.Clear();

            for(int i=0; i < lines.Length; i++)
            {
                var line = lines[i];
                for(int j=0; j < line.Length;j++)
                {
                    MazeMap.Add(new Tuple<Position, char>(new Position() { Y = i, X = j }, line[j]));
                    if (line[j] == StartSymbol)
                        StartPosition = new Position() { Y = i, X = j };
                    else if (line[j] == FinishSymbol)
                        FinishPosition = new Position() { Y = i, X = j };
                   

                }

            }

        }

        public char GetCharAtPosition(Position position)
        {
            if (position.X < 0 || position.Y < 0)
                throw new ArgumentOutOfRangeException("Arguments 'Position' coordinates must be a positive number");
            if (position.X > Height || position.Y > Width)
                throw new IndexOutOfRangeException("Position does not exist on Maz's map");
            
            var positionToFind = MazeMap.FirstOrDefault(m=>m.Item1.X==position.X && m.Item1.Y==position.Y);
            if (positionToFind == null)
                throw new IndexOutOfRangeException("Position does not exist on Maz's map");

            return positionToFind.Item2;

        }

        public int TotalWalls()
        {
            return MazeMap.FindAll(m=>m.Item2==WallSymbol).Count;
        }

        public int TotalSpaces()
        {
            return MazeMap.FindAll(m => m.Item2 == SpaceSymbol).Count;
        }

    }
}
