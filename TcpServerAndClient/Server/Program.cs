using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server");
            TcpServer server = new TcpServer(8000, new ClientHandler());
            server.Start();
        }
    }
}
