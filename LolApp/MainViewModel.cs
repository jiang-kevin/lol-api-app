using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using LolApp.Data;
using LolApp.Api;
using System.Windows.Media.Imaging;
using System.ComponentModel;

namespace LolApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private RiotApi api;
        private StaticApi staticApi;

        public ObservableCollection<Region> RegionList { get; set; }

        public string Username { get; set; }
        public Region Region { get; set; }

        private Summoner summoner;
        public Summoner Summoner
        {
            get { return summoner; }
            set
            {
                if (summoner != value)
                {
                    summoner = value;
                    RaisePropertyChanged("Summoner");
                }
            }
        }
        public BitmapImage ProfileIcon { get; set; }

        public MainViewModel(RiotApi apiInstance, StaticApi staticApiInstance)
        {
            api = apiInstance;
            staticApi = staticApiInstance;

            RegionList = new ObservableCollection<Region>();
            RegionList.Add(new Region("NA", "na1"));
            RegionList.Add(new Region("EUW", "euw1"));
            RegionList.Add(new Region("EUN", "eun1"));
            RegionList.Add(new Region("KR", "kr"));
            Region = RegionList[0];
        }

        public void GetInfo()
        {
            // get a player from name input
            Summoner = api.GetSummonerByName(Region, Username);

            // get profile icon from static api
            string profileIconUrl = staticApi.GetProfileIconUrl(Summoner.ProfileIconId, Region);

            var uri = new Uri(profileIconUrl);
            ProfileIcon = new BitmapImage(uri);

            List<LeaguePosition> leagues = api.GetLeaguePositionById(Region, Summoner.Id);
            string tierIconFormat = "{0}_{1}.png";

            //// check validity of name
            //if (Regex.IsMatch(name, "^[0-9\\p{L} _\\.]+$"))
            //{
            //    throw new Exception("Invalid username");
            //}

            //try
            //{
            //    PopulateInfo();
            //}
            //// if exception is HTTP error code
            //catch (WebException ex) when (ex.Response is HttpWebResponse response)
            //{
            //    lblStatus.Text = response.StatusDescription;
            //}
            //catch (Exception ex)
            //{
            //    lblStatus.Text = ex.ToString();
            //}
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
