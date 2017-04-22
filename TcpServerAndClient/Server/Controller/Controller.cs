using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Net.Sockets;
using MazeLib;
using SearchAlgorithmsLib;

namespace Server
{
     class Controller
    {
        private IModel model;
        private Dictionary<string, ICommand> commands;
        private Dictionary<string, Maze> mazes;
        private Dictionary<string, Solution> solutions;

        public Controller ()
        {
            //Controller c = this;
            model = new Model(this);
            commands = new Dictionary<string, ICommand>();
            commands.Add("generate", new GenerateMazeCommand(model));
            commands.Add("solve", new SolveMazeCommand(model));
            commands.Add("list", new ListCommand(model));
            mazes = new Dictionary<string, Maze>();
            /*mazes.Add("maze", null);
            mazes.Add("maze3", null);
            mazes.Add("maze2", null);*/
            solutions = new Dictionary<string, Solution>();
        }

        public string ExecuteCommand (string commandLine, TcpClient client)
        {
            string[] arr = commandLine.Split(' ');
            string commandKey = arr[0];
            if (!commands.ContainsKey(commandKey))
                return "Command not found";
            string[] args = arr.Skip(1).ToArray();
            ICommand command = commands[commandKey];
            return command.Execute(args, client);
        }

        public void AddMaze (string name, Maze maze)
        {
            mazes.Add(name, maze);
        }

        public void AddSolution(string mazeName, Solution solution)
        {
            solutions.Add(mazeName, solution);
        }

        public Maze GetMaze (string name)
        {
            if (mazes.ContainsKey(name))
            {
                return mazes[name];
            }

            return null;
        }

        public Solution GetSolution (string name)
        {
            if (solutions.ContainsKey(name))
            {
                return solutions[name];
            }

            return null;
        }

        public List<string> GetMazesNames ()
        {
            return new List<string>(mazes.Keys);
        }
    }
}
