using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleApp71
{
    internal class ApiService
    {
        public string HelloApi(string host, string name)
        {
            string url = $@"{host}\api\Test\Hello?name={name}";
            return Get(url);
        }

        public string Get(string url)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";

            WebResponse response = request.GetResponse();

            string result = "";

            using (StreamReader sr = new StreamReader(response.GetResponseStream(),
                Encoding.UTF8))
            {
                result = sr.ReadToEnd();
            }

            return result;

        }

        public string Post(string url, string contentjson)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";
            byte[] bytes = Encoding.UTF8.GetBytes(contentjson);
            request.ContentLength = bytes.Length;
            using (Stream s = request.GetRequestStream())
            {
                s.Write(bytes, 0, bytes.Length);
            }
            WebResponse response = request.GetResponse();
            string result = "";
            using (StreamReader sr = new StreamReader(response.GetResponseStream(),
                Encoding.UTF8))
            {
                result = sr.ReadToEnd();

            }
            return result;

        }
        public bool Aut(string host, string log, string pass)
        {
            string url = $@"{host}\api\Test\authorization";
            var autRequst = new AutRequst() { login = log, password = pass };
            string json = JsonConvert.SerializeObject(autRequst);
            var res = Post(url, json);
            if (res == "true") { return true; }
            else { return false; }
        }

    }

    internal class AutRequst
    {
        public string login { get; set; }
        public string password { get; set; }
    }
}

  
    
  
        
     
         
 
