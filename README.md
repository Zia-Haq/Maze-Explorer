# Maze-Explorer
A maze explorer using .Net C#

A Maze Explorer built using C#. 

The project provides a simple way to navigate through the maze using the up/down and left/right arrow keys. Once maze successfully explores the path it will display the path taken by the explorer.

The project is using the following maze as default but can be changed to any other maze in the text file located at "MazeExplorer.ConsoleApp\Resources\ExampleMaze.txt".
______________________________________________________________
XXXXXXXXXXXXXXX
X             X
X XXXXXXXXXXX X
X XS        X X
X XXXXXXXXX X X
X XXXXXXXXX X X
X XXXX      X X
X XXXX XXXX X X
X XXXX XXXX X X
X X    XXXXXX X
X X XXXXXXXXX X
X X XXXXXXXXX X
X X         X X
X XXXXXXXXX   X
XFXXXXXXXXXXXXX
_______________________________________________________________

The Maze explorer is built to address the following requirements.

User Story 1
------------

As a world famous explorer of Mazes I would like a maze to exist so that I can explore it

Acceptance Criteria:

* A Maze (as illustrated in ExampleMaze.txt) consists of walls 'X', Empty spaces ' ', one and only one Start point 'S' and one and only one exit 'F'.

* After a maze has been created the number of walls and empty spaces should be available to me.

* After a maze has been created I should be able to put in a coordinate and know what exists at that point.


User Story 2
------------

As a world famous explorer of Mazes I would like to exist in a maze and be able to navigate it so that I can explore it

Acceptance Criteria:

* Given a maze the explorer should be able to drop in to the Start point.

* An explorer in a maze must be able to:
    Move forward;
    Turn left and right;
    Understand what is in front of them;
    Understand all movement options from their given location;
    Have a record of where they have been.


UserStory 3
-----------	
* An explorer must be able to automatically explore a maze and find the exit, and on exit they must be able to state the route they took in an understandable fashion.


