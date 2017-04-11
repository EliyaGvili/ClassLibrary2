using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Net.Sockets;

namespace Server
{
    class Controller
    {
        private Dictionary<string, ICommand> commands;
        private IModel model;

        public Controller (IModel model)
        {
            this.model = model;
            commands.Add("generate", new GenerateMazeCommand(model));
        }

        public string ExecuteCommand (string commandLine, TcpClient client)
        {
            string[] arr = commandLine.Split(' ');
            string commandKey = arr[0];
            if (!commands.ContainsKey(commandLine))
                return "Command not found";
            string[] args = arr.Skip(1).ToArray();
            ICommand command = commands[commandKey];
            return command.Execute(args, client);
        }
    }
}
