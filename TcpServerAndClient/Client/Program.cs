﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;

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

            using (NetworkStream stream = client.GetStream())
            using (BinaryReader reader = new BinaryReader(stream))
            using (BinaryWriter writer = new BinaryWriter(stream))
             {
                Console.WriteLine("Please enter a number");
                int num = int.Parse(Console.ReadLine());
                writer.Write(num);

                int result = reader.ReadInt32();
                Console.WriteLine("Result = {0}", result);
             }
            client.Close();
        }
    }
}