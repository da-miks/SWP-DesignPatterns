namespace Singleton._2.Eagerly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var b1 = LoadBalancer.GetLoadBalancer();
            var b2 = LoadBalancer.GetLoadBalancer();
            var b3 = LoadBalancer.GetLoadBalancer();
            var b4 = LoadBalancer.GetLoadBalancer();
            // Confirm these are the same instance
            if(b1 == b2 && b2 == b3 && b3 == b4)
            {
                Console.WriteLine("Loadbalancer are equal");
            }
            
            //Next, load balance 15 requests for a server
            var balancer = LoadBalancer.GetLoadBalancer();
            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine($"Dispatch request to: {balancer.NextServer.Name}");
            }

        }
        
    }
}