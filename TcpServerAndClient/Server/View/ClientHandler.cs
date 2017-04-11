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
                   Console.WriteLine("strm");
                   string commandLine = reader.ReadLine();
                   //int commandLine = reader.Read();
                   Console.WriteLine("Got command: {0}", commandLine);
                  //string s = "s1";
                   //int s = 5;
                   //writer.WriteLine(s);
               }
               client.Close();
           });
            task.Start();
            task.Wait();
        }
    }
}
