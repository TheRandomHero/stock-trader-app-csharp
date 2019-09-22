using System.Net;

namespace stockTrader
{
    public class RemoteURLReader
    {
        private WebClient _webClient;

        public RemoteURLReader(WebClient webClient)
        {
            _webClient = webClient;
        }
        public string ReadFromUrl(string endpoint) {
            using(var client = _webClient) {
                return client.DownloadString(endpoint);
            }
        }
    }
}