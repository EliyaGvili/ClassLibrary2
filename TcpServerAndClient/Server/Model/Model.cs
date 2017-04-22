using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using MazeGeneratorLib;
using SearchAlgorithmsLib;
namespace Server
{
    class Model : IModel
    {
        private Controller controller;

        public Model (Controller controller2)
        {
            controller = controller2;
        }

        public Maze GenerateMaze(string name, int rows, int cols)
        {
            IMazeGenerator mazeGenerator = new DFSMazeGenerator();

            Maze maze = mazeGenerator.Generate(rows, cols);
            maze.Name = name;
            controller.AddMaze(name, maze);
            return maze;
            /*IMazeGenerator mazeGenerator = new MazeGenerator(); //implement!!!!
            Maze maze = mazeGenerator.Generate(rows, cols);
            maze.Name = name;*/
            //throw new NotImplementedException();
        }

        public List<string> MazesNames()
        {
            return controller.GetMazesNames();
        }

        public Solution SolveMaze(string name, int algorithm)
        {
            Solution solution = controller.GetSolution(name);
            if(!(solution == null))
            {
                return solution;
            }

            Maze maze = controller.GetMaze(name);

            //Searcher<Position> searcher;
            Searcher<string> searcher = null;

            if (algorithm==0)
            {
                //BFS<Position> bfs = new BFS<Position>();
                BFS<string> bfs = new BFS<string>();
                bfs.set("BFS");
                searcher = bfs;
            }
            else if (algorithm==1)
            {
                //DFS
            }

            //MazeAdapter<Position> mazeAdapter = new MazeAdapter<Position>(maze);

            MazeAdapter<string> mazeAdapter = new MazeAdapter<string>(maze);

            //solution = searcher.search(mazeAdapter);

            solution = searcher.search(mazeAdapter);

            controller.AddSolution(name, solution);

            return solution;
        }


    }
}
