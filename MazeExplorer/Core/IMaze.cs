using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeExplorer.Core
{
    public interface IMaze
    {
        List<Tuple<Position, char>> MazeMap { get; }
    
        Position FinishPosition { get; set; }
        Position StartPosition { get; set; }
        char FinishSymbol { get; }
        char StartSymbol { get; }
        char WallSymbol { get; }
        char SpaceSymbol { get; }
        int Width { get; }
        int Height { get; }
        void CreateMazeMap(string[] lines);
        char GetCharAtPosition(Position position);
        int TotalSpaces();
        int TotalWalls();
        bool IsWall(Position position);
        bool IsFinishingPoint(Position position);
    }
}
