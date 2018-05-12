using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeExplorer;
using MazeExplorer.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MazeExplorer.Tests
{
    [TestClass()]
    public class MazeTests
    {
        private IMaze _maze;
        string[] _lines;
        [TestInitialize]
        public void Initialize()
        {
            _maze = new Maze();
            _lines = new string[] 
            {   "XXXXXXXXXXXXXXX",
                "X             X",
                "X XXXXXXXXXXX X",
                "X XS        X X",
                "X XXXXXXXXX X X",
                "X XXXXXXXXX X X",
                "X XXXX      X X",
                "X XXXX XXXX X X",
                "X XXXX XXXX X X",
                "X X    XXXXXX X",
                "X X XXXXXXXXX X",
                "X X XXXXXXXXX X",
                "X X         X X",
                "X XXXXXXXXX   X",
                "XFXXXXXXXXXXXXX"
            };

            _maze.CreateMazeMap(_lines);
        }
        [TestMethod()]
        public void IsWallTest()
        {

            Assert.IsTrue(_maze.IsWall(new Position() {X=0,Y=0 }));
            Assert.IsFalse(_maze.IsWall(new Position() {X=1,Y=2 }));
        }

        [TestMethod()]
        public void IsFinishingPointTest()
        {
            Assert.IsTrue(_maze.IsFinishingPoint(new Position() { X = 1, Y = 14 }));
            Assert.IsFalse(_maze.IsFinishingPoint(new Position() { X = 2, Y = 14 }));
        }

      

        [TestMethod()]
        public void CreateMazeMapTest()
        {
            _maze.CreateMazeMap(_lines);
            Assert.AreEqual(_maze.Height, 15);
            Assert.AreEqual(_maze.Width, 15);
            Assert.AreEqual(_maze.StartPosition, new Position() { X = 3, Y = 3 });
        }

        [TestMethod()]
        public void GetCharAtPositionTest()
        {
            Assert.AreEqual(_maze.GetCharAtPosition(new Position() { X = 1, Y = 14 }), _maze.FinishSymbol);
        }

        [TestMethod()]
        public void TotalWallsTest()
        {
            Assert.AreEqual(_maze.TotalWalls(), 149);
        }

        [TestMethod()]
        public void TotalSpacesTest()
        {
            Assert.AreEqual(_maze.TotalSpaces(), 74);
        }
    }
}
