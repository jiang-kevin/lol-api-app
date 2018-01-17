using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using LolApp.Data;
using LolApp.Api;
using System.Windows.Media.Imaging;
using System.ComponentModel;

namespace LolApp.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private RiotApi api;
        private StaticApi staticApi;

        public ObservableCollection<Region> RegionList { get; set; }

        public string Username { get; set; }
        public Region Region { get; set; }

        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                if (status != value)
                {
                    status = value;
                    RaisePropertyChanged("Status");
                }
            }
        }

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

        #region Info tab data
        private BitmapImage profileIcon;
        public BitmapImage ProfileIcon
        {
            get { return profileIcon; }
            set
            {
                if (profileIcon != value)
                {
                    profileIcon = value;
                    RaisePropertyChanged("ProfileIcon");
                }
            }
        }

        public List<LeaguePosition> Leagues { get; set; }

        private BitmapImage tierIcon1;
        public BitmapImage TierIcon1
        {
            get { return tierIcon1; }
            set
            {
                if (tierIcon1 != value)
                {
                    tierIcon1 = value;
                    RaisePropertyChanged("TierIcon1");
                }
            }
        }
        private string queueType1;
        public string QueueType1
        {
            get { return queueType1; }
            set
            {
                if (queueType1 != value)
                {
                    queueType1 = value;
                    RaisePropertyChanged("QueueType1");
                }
            }
        }
        private string rank1;
        public string Rank1
        {
            get { return rank1; }
            set
            {
                if (rank1 != value)
                {
                    rank1 = value;
                    RaisePropertyChanged("Rank1");
                }
            }
        }

        private BitmapImage tierIcon2;
        public BitmapImage TierIcon2
        {
            get { return tierIcon2; }
            set
            {
                if (tierIcon2 != value)
                {
                    tierIcon2 = value;
                    RaisePropertyChanged("TierIcon2");
                }
            }
        }
        private string queueType2;
        public string QueueType2
        {
            get { return queueType2; }
            set
            {
                if (queueType2 != value)
                {
                    queueType2 = value;
                    RaisePropertyChanged("QueueType2");
                }
            }
        }
        private string rank2;
        public string Rank2
        {
            get { return rank2; }
            set
            {
                if (rank2 != value)
                {
                    rank2 = value;
                    RaisePropertyChanged("Rank1");
                }
            }
        }

        private BitmapImage tierIcon3;
        public BitmapImage TierIcon3
        {
            get { return tierIcon3; }
            set
            {
                if (tierIcon3 != value)
                {
                    tierIcon3 = value;
                    RaisePropertyChanged("TierIcon1");
                }
            }
        }
        private string queueType3;
        public string QueueType3
        {
            get { return queueType3; }
            set
            {
                if (queueType3 != value)
                {
                    queueType3 = value;
                    RaisePropertyChanged("QueueType3");
                }
            }
        }
        private string rank3;
        public string Rank3
        {
            get { return rank3; }
            set
            {
                if (rank3 != value)
                {
                    rank3 = value;
                    RaisePropertyChanged("Rank3");
                }
            }
        }
        #endregion

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

        #region Info tab logic
        public void GetInfo()
        {
            // get a player from name input
            Summoner = api.GetSummonerByName(Region, Username);

            // get profile icon from static api
            string profileIconUrl = staticApi.GetProfileIconUrl(Summoner.ProfileIconId, Region);

            var uri = new Uri(profileIconUrl);
            ProfileIcon = new BitmapImage(uri);

            Leagues = api.GetLeaguePositionById(Region, Summoner.Id);
            string tierIconFormat = "{0}_{1}.png";
            string tierIconLocation = "pack://application:,,,/LolApp;component/resources/tier-icons/";

            QueueType1 = Leagues[0].QueueType;
            Rank1 = Leagues[0].Rank + Leagues[0].Tier;
            var tierUri = new Uri(tierIconLocation + String.Format(tierIconFormat, Leagues[0].Tier.ToLower(), Leagues[0].Rank.ToLower()));
            TierIcon1 = new BitmapImage(tierUri);

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

        #endregion
    }
}
