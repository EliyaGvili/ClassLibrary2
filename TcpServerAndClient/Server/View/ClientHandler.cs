using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Server
{
    class ClientHandler : IClientHandler
    {
        Controller controller;

        public ClientHandler()
        {
            controller = new Controller();
        }

        public void HandleClient (TcpClient client)
        {
            Console.WriteLine("ch");
           new Task(() =>
           {
               Console.WriteLine("ch tsk");
               NetworkStream stream = client.GetStream();

               BinaryReader reader = new BinaryReader(stream);
               BinaryWriter writer = new BinaryWriter(stream);

               //StreamReader reader = new StreamReader(stream);
               //StreamWriter writer = new StreamWriter(stream);

               //string commandLine = reader.ReadLine();

               string commandLine = reader.ReadString();
               Console.WriteLine("Got command: {0}", commandLine);
               string result = controller.ExecuteCommand(commandLine, client);

               //writer.WriteLine(result);
               writer.Write(result);
               Console.WriteLine(result);

               client.Close();
           }).Start();
            //task.Wait();
        }
    }
}
