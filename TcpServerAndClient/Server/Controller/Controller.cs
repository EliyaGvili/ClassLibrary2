using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Net.Sockets;
using MazeLib;

namespace Server
{
     class Controller
    {
        private IModel model;
        private Dictionary<string, ICommand> commands;
        private Dictionary<string, Maze> mazes;
        //private Dictionary<string, Solution> solutions;

        public Controller ()
        {
            //Controller c = this;
            model = new Model(this);
            commands = new Dictionary<string, ICommand>();
            commands.Add("generate", new GenerateMazeCommand(model));
            mazes = new Dictionary<string, Maze>();
            //solutions = new Dictionary<string, Solution>();
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

        /*public void AddSolution(string mazeName, Solution solution)
        {
            solutions.Add(mazeName, solution);
        }*/
    }
}
