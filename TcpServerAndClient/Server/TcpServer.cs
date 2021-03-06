﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Server
{
    class TcpServer
    {
        private int port;
        private TcpListener listener;
        private IClientHandler ch;

        public TcpServer (int port, IClientHandler ch)
        {
            this.port = port;
            this.ch = ch;
        }

        public void Start()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            listener = new TcpListener(ep);

            listener.Start();

            Console.WriteLine("Waiting for connections...");

            Task task = new Task(() =>
           {
               Console.WriteLine("$$$$$$#########$$$$$$$#######");
               while (true)
               {
                   Console.WriteLine("3333333333333333333333444444444");
                   try
                   {
                       Console.WriteLine("9999");
                       TcpClient client = listener.AcceptTcpClient();
                       Console.WriteLine("Got new connection");
                       //Thread.Sleep(86);
                       //break;
                       ch.HandleClient(client);
                       //client.Close();
                       //break;
                   }
                   catch (SocketException)
                   {
                       Console.WriteLine("xptn");
                       break;
                   }
               }
               Console.WriteLine("---");
           });
           task.Start();
           //task.Wait();
        }

        public void Stop()
        {
            Console.WriteLine("S");
            listener.Stop();
        }
    }
}
