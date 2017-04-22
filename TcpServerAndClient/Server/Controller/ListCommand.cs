using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Server
{
    class ListCommand : ICommand
    {
        private IModel model;

        public ListCommand (IModel model2)
        {
            model = model2;
        }
        public string Execute(string[] args, TcpClient client)
        {
            return JsonConvert.SerializeObject(model.MazesNames());
        }
    }
}
