using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class SolveMazeCommand : ICommand
    {
        private IModel model;

        public SolveMazeCommand (IModel model)
        {
            this.model = model;
        }

        public string Execute(string[] args, TcpClient client)
        {
            string name = args[0];
            int algorithm = int.Parse(args[1]);

            return "66868";



            //throw new NotImplementedException();
        }
    }
}
