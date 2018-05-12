using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeExplorer;
using MazeExplorer.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
namespace MazeExplorer.Tests
{
    /// <summary>
    /// Integration Tests
    /// </summary>
    [TestClass()]
    public class ExplorerIntegrationTests
    {
        private IExplorer _explorer;
        private IAutoExplorer _autoExplorer;
        private IMaze _maze;
        private IDrawExplorerMovementsOnMaze _drawMovementsOnMaz;
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

           _drawMovementsOnMaz = new Mock<DrawExplorerMovementsOnMaze>().Object;
  
            _maze.CreateMazeMap(_lines);
            _autoExplorer = new AutoExplorer(_maze, _drawMovementsOnMaz);
            _explorer = _autoExplorer as IExplorer;  
        }


        [TestMethod()]
        public void MoveLeftTest()
        {
            var currentPosition = _explorer.CurrentPosition;
            _explorer.MoveLeft();
            Assert.AreEqual(_explorer.CurrentPosition, currentPosition);//should not change position is as there is a wall at left
     
        }

        [TestMethod()]
        public void MoveRightTest()
        {
            var currentPosition = _explorer.CurrentPosition;
            _explorer.MoveRight();
            Assert.AreEqual(_explorer.CurrentPosition, new Position() {X=currentPosition.X+1,Y=currentPosition.Y });//should move to right
     
        }

        [TestMethod()]
        public void MoveUpTest()
        {
            var currentPosition = _explorer.CurrentPosition;
            _explorer.MoveUp();
            Assert.AreEqual(_explorer.CurrentPosition, currentPosition);//should not change position is as there is a wall up
     
        }

        [TestMethod()]
        public void MoveDownTest()
        {
            var currentPosition = _explorer.CurrentPosition;
            _explorer.MoveDown();
            Assert.AreEqual(_explorer.CurrentPosition, currentPosition );//should not change position as there is a wall down
        }

      

        [TestMethod()]
        public void GetCharAtCurrentPositionTest()
        {
            var charAt=_maze.MazeMap.FirstOrDefault(m=>m.Item1.X==_explorer.CurrentPosition.X && m.Item1.Y==_explorer.CurrentPosition.Y);

            Assert.AreEqual(_explorer.GetCharAtCurrentPosition(), charAt.Item2);
          
        }

        [TestMethod()]
        public void AutoExploreTest()
        {
            Assert.AreEqual(_autoExplorer.AutoExplore(), true);//should be able to find an exit
        }
    }
}
