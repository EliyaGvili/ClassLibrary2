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
           Task task =  new Task(() =>
           {
               Console.WriteLine("ch tsk");
               using (NetworkStream stream = client.GetStream())
               using (StreamReader reader = new StreamReader(stream))
               using (StreamWriter writer = new StreamWriter(stream))
               {
                   /*Console.WriteLine("Waiting for a number");
                   string s = reader.ReadLine();
                   Console.WriteLine("Number accepted {0}", s);

                   s = "890";
                   writer.WriteLine(s);*/
                   Console.WriteLine("strm");
                   string commandLine = reader.ReadLine();
                   //int commandLine = reader.Read();
                   Console.WriteLine("Got command: {0}", commandLine);
                   string result = controller.ExecuteCommand(commandLine, client);
                   //int s = 5;
                   //writer.Flush();
                   //writer.WriteLine(result);
                   Console.WriteLine(result);


               }
               client.Close();
           });
            task.Start();
            //task.Wait();
        }
    }
}
