using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpServer server = new TcpServer(8000, new ClientHandler());
        }
    }
}
