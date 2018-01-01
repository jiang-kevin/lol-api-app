using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LolApp.Data;

namespace LolApp.Api
{
    public class StaticApi : Api
    {
        private const string ProfileIconRootUrl = "/lol/static-data/v3/profile-icons";

        public StaticApi(string apiKey) :
            base(apiKey)
        { }

        public ProfileIconList GetProfileIconList(Region region)
        {
            string json = RequestJson(ProfileIconRootUrl, region.RegionCode);
            return JsonConvert.DeserializeObject<ProfileIconList>(json);
        }

        public string GetProfileIconUrl(int id, Region region)
        {
            ProfileIconList profileIcons = GetProfileIconList(region);
            string filename = profileIcons.Data[id].Image.Full;
            return "http://ddragon.leagueoflegends.com/cdn/6.24.1/img/profileicon/" + filename;
        }
    }
}
