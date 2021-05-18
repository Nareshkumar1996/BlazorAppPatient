using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Healthware.Assist.Core.Extensions;

namespace Healthware.Assist.Core.Web.Common.HttpClient
{
    public class ClientCredentialsTokenRequest
    {
        public string Address { get; private set; }
        public readonly IDictionary<string, string> Params;
        private string SecretKey{ get; set; }
        public ClientCredentialsTokenRequest(string baseUrl, string address, string userName, string apiKey, string secretKey)
        {
            this.Params = new Dictionary<string, string>();
            this.Address = baseUrl + address;
            this.Params.Add("username", userName);
            this.Params.Add("apikey", apiKey);
            this.SecretKey = secretKey;
        }
        private string GetHmac(String requestData, string secretKey)
        {
            
            using (var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(secretKey)))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(requestData));
                return Convert.ToBase64String(hash);
            }
            
        }

        public IDictionary<string, string>  UpdateRequestParam()
        {
            DateTime dateTime = DateTime.UtcNow;
            string timeStamp = dateTime.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK", CultureInfo.InvariantCulture);
            this.Params["hmac"] = WebUtility.UrlEncode(GetHmac(string.Concat(this.Params.GetOrDefault("username"), this.Params.GetOrDefault("apikey"), timeStamp), this.SecretKey));
            this.Params["timestamp"] = timeStamp;
            return this.Params;
        }
    }
}