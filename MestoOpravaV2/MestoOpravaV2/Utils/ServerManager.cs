﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using MestoOpravaV2.JsonTempates;
using Newtonsoft.Json;

namespace MestoOpravaV2.Utils
{
    class ServerManager
    {
        private string Ip;
        public ServerManager(string ip)
        {
            this.Ip = ip;
        }

        private HttpWebRequest SendResponse<T>(string url,T jsonTemplate)
        {
            string targetUrl = $"{Ip}/{url}";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(targetUrl);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(jsonTemplate);
                streamWriter.Write(json);
            }

            return httpWebRequest;
        }

        private string GetResponseString(HttpWebRequest httpWebRequest)
        {
            var result = "";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            return result;
        }
        private T GetResponseTemplate<T>(HttpWebRequest httpWebRequest)
        {
            return JsonConvert.DeserializeObject<T>(GetResponseString(httpWebRequest));
        }
        public string Add_Post()
        {
            HttpWebRequest httpWebRequest = SendResponse("GetPostData.php/", new LocationArgsTemplate("50","60"));
            string temp = "";
            GetResponseTemplate<List<PostDataTemplate>>(httpWebRequest).ForEach(p=> temp += p.postTitle);
            
            return temp;
        }

    }
}