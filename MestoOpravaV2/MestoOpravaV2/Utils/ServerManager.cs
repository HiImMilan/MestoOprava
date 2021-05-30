using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MestoOpravaV2.Utils
{
    public class ServerManager
    {
        private static ServerManager _serverManager;
        public static ServerManager serverManager
        {
            get
            {
                if ( _serverManager == null )
                {
                    //http://158.255.29.10/Server
                    _serverManager = new ServerManager("http://158.255.29.10:8142/api/v1");
                }
                return _serverManager;
            }
        }

        private string Ip;
        public ServerManager(string ip)
        {
            this.Ip = ip;
        }

        public async Task<HttpWebRequest> SendResponse(string url,Dictionary<string,string> data)
        {
            string targetUrl = $"{Ip}/{url}";

            foreach (var item in data)
            {
                targetUrl += $"/{item.Value}";
            }
            Console.WriteLine(targetUrl);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(targetUrl);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            httpWebRequest.Timeout = 5000;
            return httpWebRequest;
        }

        public void checkDebug()
        {
            var result = "";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://158.255.29.10:8142/api/v1/connectivityCheck");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            httpWebRequest.Timeout = 5000;
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
        }
        
        private string GetResponseString(HttpWebRequest httpWebRequest)
        {
            var result = "";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            Console.WriteLine(result); 
            return result;
        }
        private T GetResponseTemplate<T>(HttpWebRequest httpWebRequest)
        {
            return JsonConvert.DeserializeObject<T>(GetResponseString(httpWebRequest));
        }

        public async Task<List<Post>> TryGetPostData()
        {
            Dictionary<string, string> data = new Dictionary<string, string>()
            {
                {"latitude","50" },
                {"longitude","60" }
            };
            HttpWebRequest httpWebRequest = await SendResponse("getNearest", data);
            
            return GetResponseTemplate<List<Post>>(httpWebRequest);
        }

        public async Task<List<Dictionary<string, string>>> GetPostById(string postId)
        {
            Dictionary<string, string> data = new Dictionary<string, string>()
            {
                {"postId", postId },
                {"operation", "getPost" }
            };
            
            HttpWebRequest httpWebRequest = await SendResponse("post", data);

            return GetResponseTemplate<List<Dictionary<string,string>>>(httpWebRequest);
        }

    }
}
