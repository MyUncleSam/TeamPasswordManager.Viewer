using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TeamPassword.Library.Rest
{
    public class RestClass
    {
        Instance inst = null;
        public bool LoginSuccess { get; set; }
        private RestClient CurrentClient { get; set; }
        public Version GetVersion = null;

        public RestClass(Instance _inst)
        {
            inst = _inst;

            string urlToUse = null;

            if (inst.LoginInfo.URL.AbsoluteUri.TrimEnd('/').EndsWith("/index.php", StringComparison.OrdinalIgnoreCase))
                urlToUse = string.Format("{0}/", inst.LoginInfo.URL.AbsoluteUri.TrimEnd('/'));
            else
                urlToUse = string.Format("{0}/{1}", inst.LoginInfo.URL.AbsoluteUri.TrimEnd('/'), "index.php/");

            RestClient rc = new RestClient(urlToUse);
            rc.AddDefaultHeader("Content-Type", "application/json; charset=utf-8");

            CurrentClient = rc;
        }

        public RestRequest CreateNewRequest(Method m, string jsonUrl, Dictionary<string, string> urlParameters = null, Dictionary<string, object> parameters = null, Dictionary<string, string> headers = null, string apiVersion = "v4")
        {
            string relUrl = string.Format("api/{0}/{1}", apiVersion, jsonUrl.TrimStart('/'));
            string hashUrl = relUrl; // because url segments could be used we always need to have the full url part here!

            RestRequest rr = new RestRequest(relUrl, m);

            if (urlParameters != null)
                foreach (KeyValuePair<string, string> ue in urlParameters)
                {
                    rr.AddUrlSegment(ue.Key, ue.Value);
                    hashUrl = hashUrl.Replace(string.Format("{{{0}}}", ue.Key), ue.Value);
                }
            
            if (parameters!= null)
                foreach (KeyValuePair<string, object> param in parameters)
                    rr.AddParameter(param.Key, param.Value);

            if(headers != null)
                foreach (KeyValuePair<string, string> header in headers)
                    rr.AddHeader(header.Key, header.Value);

            return rr;
        }

        public IRestResponse GetResponse(RestRequest rr)
        {
            CurrentClient.Authenticator = new HttpBasicAuthenticator(inst.LoginInfo.Username, inst.LoginInfo.Password);
            IRestResponse resp = CurrentClient.Execute(rr);
            
            if(!resp.IsSuccessful)
            {
				string errorMsg = string.Format("Unknown error: {0}", resp.ErrorMessage ?? "<NULL>");
				try
				{
					Objects.Error.RootObject eo = JsonConvert.DeserializeObject<Objects.Error.RootObject>(resp.Content);
					errorMsg = string.Format("{0}: {1}", eo.type, eo.message);
				}
				catch { }

                throw new Exception(errorMsg);
            }

            return resp;
        }

        public T GetResponse<T>(RestRequest rr)
        {
            return JsonConvert.DeserializeObject<T>(GetResponse(rr).Content);
        }

        //private long CurrentTimeStamp()
        //{
        //    return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        //}

        //private string Hash(string privateKey, long timestamp, string url, string body = null)
        //{
        //    var keyBytes = Encoding.UTF8.GetBytes(privateKey);
        //    var data = url + timestamp + (body ?? "");
        //    return ToHex(Hmac(keyBytes, Encoding.UTF8.GetBytes(data)));
        //}

        //private string ToHex(byte[] data)
        //{
        //    return BitConverter.ToString(data).Replace("-", String.Empty).ToLower();
        //}

        //private byte[] Hmac(byte[] keyBytes, byte[] data)
        //{
        //    using (var hmac = new HMACSHA256(keyBytes))
        //    {
        //        return hmac.ComputeHash(data);
        //    }
        //}

    }
}
