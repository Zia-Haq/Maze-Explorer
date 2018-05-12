using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeExplorer
{
   public struct Position:IEquatable<Position>
    {
        public int Y { get; set; }
        public int X { get; set;}
      
        public bool Equals(Position other)
        {
            return (this.X == other.X && this.Y == other.Y);
        }
        public override int GetHashCode()
        {
            return this.X.GetHashCode() ^ this.Y.GetHashCode();
        }
    }
}
