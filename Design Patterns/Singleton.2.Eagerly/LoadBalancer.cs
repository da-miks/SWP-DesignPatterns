using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton._2.Eagerly
{
    /// <summary>
    /// The 'Singleton' class
    /// </summary>
    public sealed class LoadBalancer
    {
        // Static members are 'eagerly' initialized', that is,
        // immediately when class is loaded for the first time.
        // .NET guarantees thread safety for static initialization
        private static readonly LoadBalancer instance = new();

        private readonly List<Server> servers;
        private readonly Random random = new();

        // Note: Constructor is 'private'
        private LoadBalancer()
        {
            servers = new()
            {
                new("Server1","120.14.220.18"),
                new("Server2","120.14.220.19"),
                new("Server3","120.14.220.20"),
                new("Server4","120.14.220.21"),
                new("Server5","120.14.220.22")
            };
        }
        public static LoadBalancer GetLoadBalancer()
        {
            return instance;
        }
        // Simple, but effective load balancer
        public Server NextServer
        {
            get
            {
                return servers[random.Next(servers.Count)];
            }
        }
    }

    /// <summary>
    /// represents the server machine
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Ip"></param>
    public record Server(string Name, string Ip);
}
