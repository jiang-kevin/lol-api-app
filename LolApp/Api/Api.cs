using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using LolApp.Data;

namespace LolApp.Api
{
    public class Api
    {
        public string ApiKey { get; set; }

        // private fields
        private const string BaseUrl = "https://{0}.api.riotgames.com";
        private string CacheDirectory;

        #region Class Functions
        public Api(string apiKey)
        {
            ApiKey = apiKey;
            CacheDirectory = Path.Combine(Directory.GetCurrentDirectory(), "cache");

            // create the cache directory if it does not exist
            if (!Directory.Exists(CacheDirectory))
            {
                Directory.CreateDirectory(CacheDirectory);
            }
        }

        protected string RequestJson(string rootUrl, Region region)
        {
            string url = String.Format(BaseUrl, region.RegionCode) + rootUrl + "?api_key=" + ApiKey;
            return new WebClient().DownloadString(url);
        }

        protected string RequestCachedJson(string rootUrl, Region region)
        {
            string url = String.Format(BaseUrl, region.RegionCode) + rootUrl + "?api_key=" + ApiKey;
            string filename = GetMD5Hash(url);
            string path = Path.Combine(CacheDirectory, filename);

            if (File.Exists(path) && (File.GetCreationTime(path) > DateTime.Now.AddHours(-24)) )
            {
                return File.ReadAllText(path);
            }
            else if (File.Exists(path))
            {
                File.Delete(path);
            }

            string json = RequestJson(rootUrl, region);
            File.WriteAllText(path, json);
            return json;
        }

        protected string GetMD5Hash(string input)
        {
            MD5 md5 = MD5.Create();                                 // create empty MD5 object
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);     // convert input to byte representation
            byte[] hash = md5.ComputeHash(inputBytes);              // compute hash from bytes

            StringBuilder sb = new StringBuilder();                 // create string to hold hex characters

            foreach (var b in hash)
            {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString();
        }
        #endregion
    }
}
