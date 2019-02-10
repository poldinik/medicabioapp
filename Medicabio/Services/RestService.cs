using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Medicabio.Services
{
    public class RestService
    {
        HttpClient client;
        string access_token { get; set; }

        public RestService()
        {
            client = new HttpClient();
            // client.MaxResponseContentBufferSize = 256000;
            //access_token = Constants.access_token;
        }

        public async Task<T> PostResponse<T>(string weburl, string jsonstring) where T : class
        {
            string ContentType = "application/json";
            //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", access_token);
            try
            {
                var Result = await client.PostAsync(weburl, new StringContent(jsonstring, Encoding.UTF8, ContentType));
                if (Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var JsonResult = Result.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var ContentResp = JsonConvert.DeserializeObject<T>(JsonResult);
                        return ContentResp;
                    }
                    catch { return null; }
                }
            }

            catch
            {
                return null;
            }

            return null;

        }

        public async Task<T> GetResponse<T>(string weburl, bool isList) where T : class
        {
            //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", access_token);

            //try
            //{
            //    var response = await client.GetAsync(weburl);
            //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //    {
            //        var JsonResult = response.Content.ReadAsStringAsync().Result;
            //        Console.WriteLine(JsonResult);
            //        try
            //        {
            //            JObject result = JObject.Parse(JsonResult);

            //            var contentResp = JsonConvert.DeserializeObject<T>(JsonResult);
            //            Console.WriteLine(contentResp);
            //            return contentResp;
            //        }
            //        catch
            //        {
            //            Console.WriteLine("ERRORE: Deserializzazione non eseguita");
            //            return null;
            //        }
            //    }
            //}
            //catch
            //{
            //    Console.WriteLine("ERRORE: api calling error");
            //    return null;
            //}
            //return null;
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            var response = await client.GetAsync(weburl);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var JsonResult = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(JsonResult);
                //JObject result = JObject.Parse(JsonResult);


                if (isList)
                {
                    JArray result = JArray.Parse(JsonResult);
                    var contentResp = JsonConvert.DeserializeObject<T>(JsonResult, settings);
                    Console.WriteLine(contentResp);
                    return contentResp;
                }
                else
                {
                    JObject result = JObject.Parse(JsonResult);
                    var contentResp = JsonConvert.DeserializeObject<T>(JsonResult, settings);
                    Console.WriteLine(contentResp);
                    return contentResp;
                }
            }
            Console.WriteLine("Not ok request status");
            return null;
        }
    }
}
