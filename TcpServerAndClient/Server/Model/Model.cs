using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using MazeGeneratorLib;

namespace Server
{
    class Model : IModel
    {
        public Maze GenerateMaze(string name, int rows, int cols)
        {
            IMazeGenerator mazeGenerator = new DFSMazeGenerator();
            Maze maze = mazeGenerator.Generate(rows, cols);
            maze.Name = name;
            return maze;
            /*IMazeGenerator mazeGenerator = new MazeGenerator(); //implement!!!!
            Maze maze = mazeGenerator.Generate(rows, cols);
            maze.Name = name;*/
            //throw new NotImplementedException();
        }
    }
}
