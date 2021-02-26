using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.IO;

namespace Fedsearch
{
    class API
    {
        public static string content { get; set; }
        public static string Request(string query)
        {
            try
            {
                // Post Request
                var request = (HttpWebRequest)WebRequest.Create("https://fedsearch.cf/API/search_api.php");

                // Post data
                var postData = "search=" + Uri.EscapeDataString(query);
                postData += "&submit=" + Uri.EscapeDataString("");
                postData += "&key=" + Uri.EscapeDataString($"{Program.API_KEY}");

                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                // Response content
                content = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return content;
            }
            catch { }

            // Will return null
            return content;
        }
    }
    class Json
    {
        public string id { get; set; }
        public string ip { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string token { get; set; }
        public string database { get; set; }
    }
}
