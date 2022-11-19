using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Erklärung
{
    internal class FetchApi : IAsyncRequestStrategy
    {
        public AsyncResponse SendRequest(string url)
        {
            AsyncResponse asyncResponse = new AsyncResponse();
            Console.WriteLine("Sent async network request using Fetch Api");
            return asyncResponse;
        }
    }
}
