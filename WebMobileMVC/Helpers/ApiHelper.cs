using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace WebMobileMVC.Helpers
{
    public static class ApiHelper
    {
        public enum ApiType
        {
            Post,
            Get,
            Put,
            Delete
        }

        /// <inheritdoc />
        public static TOutputModel Post<TOutputModel>(string apiUrl, string bodyJson = "")
        {
            return CallApi<TOutputModel>(apiUrl, ApiType.Post, bodyJson);
        }

        /// <inheritdoc />
        public static TOutputModel Put<TOutputModel>(string apiUrl, string bodyJson = "")
        {
            return CallApi<TOutputModel>(apiUrl, ApiType.Put, bodyJson);
        }

        /// <inheritdoc />
        public static TOutputModel Get<TOutputModel>(string apiUrl)
        {
            return CallApi<TOutputModel>(apiUrl, ApiType.Get);
        }

        /// <inheritdoc />
        public static TOutputModel Delete<TOutputModel>(string apiUrl)
        {
            return CallApi<TOutputModel>(apiUrl, ApiType.Delete);
        }


        /// <summary>
        /// Call a API
        /// </summary>
        /// <typeparam name="TOutputModel">Datatype of model</typeparam>
        /// <param name="apiUrl">api url</param>
        /// <param name="apiType">enum of ApiType</param>
        /// <param name="bodyJson">json to pass in the body</param>
        /// <returns>the result of Api</returns>
        private static TOutputModel CallApi<TOutputModel>(string apiUrl, ApiType apiType, string bodyJson = "")
        {
            if (string.IsNullOrEmpty(apiUrl))
            {
                throw new ArgumentNullException(nameof(apiUrl));
            }

            //use to pass SSL
            System.Net.ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Tls12 |
                SecurityProtocolType.Tls11 |
                SecurityProtocolType.Tls;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(apiUrl);

                //use to pass SSL
                client.DefaultRequestHeaders.Add("User-Agent", "Your application name");

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (!string.IsNullOrEmpty(Helpers.ConstantVariable.token))
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Helpers.ConstantVariable.token);
                }

                HttpResponseMessage res = null;
                StringContent content = null;
                if (apiType == ApiType.Post || apiType == ApiType.Put)
                {
                    content = new StringContent(bodyJson, Encoding.UTF8, "application/json");
                }

                switch (apiType)
                {
                    case ApiType.Post:
                        var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<TOutputModel>(bodyJson);
                        res = client.PostAsJsonAsync<TOutputModel>(apiUrl, obj).Result;
                        break;
                    case ApiType.Get:
                        res = client.GetAsync(apiUrl).Result;
                        break;
                    case ApiType.Delete:
                        res = client.DeleteAsync(apiUrl).Result;
                        break;
                    case ApiType.Put:
                        res = client.PutAsync(apiUrl, content).Result;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(apiType), apiType, null);
                }

                if (res != null && res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<TOutputModel>(response);
                }
                else
                {
                    throw new Exception();
                }
            }
        }
    }
}
