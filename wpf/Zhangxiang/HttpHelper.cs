using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

namespace Zhangxiang
{
    public class HttpHelper
    {
        public static async Task PostMethod()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("ContentType", "application/json");
                    string str = JsonConvert.SerializeObject(new { username = "", password = "" });
                    HttpContent content = new StringContent(str);
                    content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    var response = await client.PostAsync("httpurl", content);
                    string resStr = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrWhiteSpace(resStr))
                    {
                        //var data = JsonConvert.DeserializeObject<>(resStr);

                    }

                }
            }
            catch (Exception ex)
            {
                
            }
            
        }

        public static async Task GetMethod()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //client.DefaultRequestHeaders.Add("Authorization", "token");
                    var response = await client.GetAsync("url");
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string resStr = await response.Content.ReadAsStringAsync();

                        //var data = JsonConvert.DeserializeObject<>(resStr);
                    }
                }
            }
            catch (Exception ex)
            {
                
            }

        }


    }
}
