
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client");
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"),8000);
            TcpClient client = new TcpClient();
            Console.WriteLine("3523525");
            client.Connect(ep);
            Console.WriteLine("You are connected");

            //while (true)
            //{
                using (NetworkStream stream = client.GetStream())
                using (StreamReader reader = new StreamReader(stream))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    Console.WriteLine("Please enter a number");
                // int num = 7;// int.Parse(Console.ReadLine());
                //string num = "7";
                string num = Console.ReadLine();
                //writer.Write(num);
                writer.WriteLine(num);
                    Console.WriteLine("Num is: {0}", num);

                // Thread.Sleep(455);

                //int result = reader.Read();
                //string result = reader.ReadLine();
                //Console.WriteLine("Result = {0}", result);
                   // break;
                }
            //}
            client.Close();
        }
    }
}
