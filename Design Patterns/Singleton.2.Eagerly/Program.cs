using System.Net.WebSockets;

namespace Singleton._2.Lazy
{
    /// <summary>
    /// Represents a server machine
    /// </summary>
    /// <param name="name">The name of the server</param>
    /// <param name="Ip">The IP Address of the server</param>
    public record Server(string Name, string Ip);

    /// <summary>
    /// The 'Singleton' class
    /// </summary>
    public sealed class LoadBalancer
    {
        // Static members are 'eagerly initialized', that is,
        // immediately when class is loaded for the first time.
        // .NET guarantees thread safety for static initialization
        private static readonly LoadBalancer instance = new();

        private readonly List<Server> servers;

        // Note: Constructor is private
        private LoadBalancer()
        {
            // Load list of available servers
            servers = new()
            {
                new(Name: "Server 1", Ip: "120.14.220.11"),
                new(Name: "Server 2", Ip: "120.14.220.12"),
                new(Name: "Server 3", Ip: "120.14.220.13"),
                new(Name: "Server 4", Ip: "120.14.220.14"),
                new(Name: "Server 5", Ip: "120.14.220.15")
            };

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
}