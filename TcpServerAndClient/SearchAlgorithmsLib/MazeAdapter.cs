using System;
using System.Collections.Generic;
using System.Text;
using MazeLib;
using MazeGeneratorLib;

namespace SearchAlgorithmsLib
{
    public class MazeAdapter<Position> : ISearchable<Position>
    {
        Maze maze;
        State<Position> initialState;
        State<Position> goalState;
        List<State<Position>> possibleStates;

        public MazeAdapter (Maze maze2)
        {
            maze = maze2;
            //initialState = new State<Position>(maze.InitialPos);
            //goalState = new State<Position>(maze.GoalPos);
            possibleStates = new List<State<Position>>();
        }

        public List<State<Position>> getAllPossibleStates(State<Position> s)
        {
            throw new NotImplementedException();
        }

        public State<Position> getGoalState()
        {
            throw new NotImplementedException();
        }

        public State<Position> getInitialState()
        {
            throw new NotImplementedException();
        }
    }
}
