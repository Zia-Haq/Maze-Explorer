using System;
namespace MazeExplorer.Core
{
    public interface IExplorer
    {
        Position CurrentPosition { get; }
        char GetCharAtCurrentPosition();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void MoveUp();
        bool ReachedFinishingPoint { get; }
        void ShowExplorerMovementsOnMaz();
    }
}
