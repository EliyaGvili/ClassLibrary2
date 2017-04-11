using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;

namespace Server
{
    interface IModel
    {
        Maze GenerateMaze(string name, int rows, int cols);
    }
}
