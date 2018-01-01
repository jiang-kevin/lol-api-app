using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace LolApp.Api
{
    public class Api
    {
        public string ApiKey { get; set; }

        // private fields
        private const string BaseUrl = "https://{0}.api.riotgames.com";

        #region Class Functions
        public Api(string apiKey)
        {
            ApiKey = apiKey;
        }

        protected string RequestJson(string rootUrl, string region)
        {
            string url = String.Format(BaseUrl, region) + rootUrl + "?api_key=" + ApiKey;
            return new WebClient().DownloadString(url);
        }
        #endregion
    }
}
