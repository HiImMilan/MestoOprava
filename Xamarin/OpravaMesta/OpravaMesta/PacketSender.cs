using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OpravaMesta
{
    
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectClass"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public class PacketSender<T,U>
        {
            private T _sendObject { get; set; }
            private U _getObject { get; set; }
            private string content { get; set; }
            private string url { get; set; }
            public PacketSender(T SendObject, string url)
            {
                this.url = url;
                this._sendObject = SendObject;
            }

            public HttpResponseMessage response;
            public async Task<string> SendRequest()
            {
                this.content = "";
                HttpClient client = new HttpClient();
                string serializedObject = JsonConvert.SerializeObject(this._sendObject);
                try
                {
                    var httpContent = new StringContent(serializedObject, Encoding.UTF8);

                    response = await client.GetAsync(url);
                    return await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException e)
                {
                    return "";
                }
            }

            public async Task<U> GetResponse()
            {
                SendRequest();
                return JsonConvert.DeserializeObject<U>(this.content);
            }
        }
    }
