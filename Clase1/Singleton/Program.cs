using System;
using System.Collections.Generic;

namespace Singleton
{
    class Program
    {
        public static void Main(string[] args)
        {
            LoadBalancer loadBalancer = LoadBalancer.GetInstance();

            Server server = loadBalancer.GetServer();

            string value = $"Host: {server.GetAddress()}";

            Console.WriteLine(value);
        }
    }

    class LoadBalancer
    {
        private readonly List<Server> servers = new List<Server>();
        private static LoadBalancer instance;
        private static readonly object padlock = new object();

        private LoadBalancer()
        {
            this.servers.Add(new Server("192.168.0.2"));
            this.servers.Add(new Server("192.168.0.3"));
            this.servers.Add(new Server("192.168.0.4"));
            this.servers.Add(new Server("192.168.0.5"));
            this.servers.Add(new Server("192.168.0.6"));
        }
        public Server GetServer()
        {
            return servers[new Random().Next(0, 4)];
        }

        public static LoadBalancer GetInstance()
        {
            if (instance == null)
            {
                lock (padlock)
                {
                    if (instance == null)
                        instance = new LoadBalancer();
                }
            }
            return instance;
        }
    }

    class Server
    {
        private readonly string address;

        public Server(string address)
        {
            this.address = address;
        }

        public string GetAddress()
        {
            return this.address;
        }
    }

}

