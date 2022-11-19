using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Erklärung
{
    public enum BrowserType
    {
        InternetExplorer = 1,
        Chrome = 2
    }
    class WebApplication
    {
        private BrowserType _browserType;
        public WebApplication(BrowserType browserType)
        {
            _browserType = browserType;
        }
        public AsyncResponse SendAsyncRequestToServer(String url)
        {
            IAsyncRequestStrategy asyncRequestStrategy;
            AsyncResponse asyncResponse = null;
            switch(_browserType)
            {
                case BrowserType.InternetExplorer:
                    asyncRequestStrategy = new XmlHttpRequestApi();
                    asyncResponse = asyncRequestStrategy.SendRequest(url);
                case BrowserType.Chrome:
                    asyncRequestStrategy = new FetchApi();
                    asyncResponse= asyncRequestStrategy.SendRequest(url);
            }
            
        }
    }
}
