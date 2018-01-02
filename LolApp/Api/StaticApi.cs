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
        private const string RealmsRootUrl = "/lol/static-data/v3/realms";

        public StaticApi(string apiKey) :
            base(apiKey)
        { }

        public DDVersion GetVersion(Region region)
        {
            string json = RequestJson(RealmsRootUrl, region);
            return JsonConvert.DeserializeObject<DDVersion>(json);
        }

        public ProfileIconList GetProfileIconList(Region region)
        {
            string json = RequestJson(ProfileIconRootUrl, region);
            return JsonConvert.DeserializeObject<ProfileIconList>(json);
        }

        public string GetProfileIconUrl(int id, Region region)
        {
            ProfileIconList profileIcons = GetProfileIconList(region);
            string filename = profileIcons.Data[id].Image.Full;
            DDVersion versionList = GetVersion(region);
            string profileIconVersion = versionList.N["profileicon"];
            return String.Format("http://ddragon.leagueoflegends.com/cdn/{0}/img/profileicon/", profileIconVersion) + filename;
        }
    }
}
