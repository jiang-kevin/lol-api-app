using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using LolApp.Data;
using LolApp.Api;
using System.Windows.Media.Imaging;
using System.Net;
using System.Text.RegularExpressions;
using System.Globalization;

namespace LolApp.ViewModel
{
    /// <summary>
    /// ViewModel which represents all the logic and data to be used in LolApp
    /// </summary>
    public class MainViewModel : ObservableObject
    {
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

        #region Application objects
        private RiotApi api;
        private StaticApi staticApi;

        private Summoner _summoner;
        public Summoner Summoner
        {
            get { return _summoner; }
            set
            {
                if (_summoner != value)
                {
                    _summoner = value;
                    RaisePropertyChanged("Summoner");
                }
            }
        }
        #endregion

        #region Main screen objects
        public ObservableCollection<Region> RegionList { get; set; }

        public string Username { get; set; }
        public Region Region { get; set; }

        private string _status;
        public string Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    RaisePropertyChanged("Status");
                }
            }
        }

        #endregion

        #region Main screen logic
        public void GetData()
        {
            try
            {
                GetInfo();
            }
            // if exception is HTTP error code
            catch (WebException ex) when (ex.Response is HttpWebResponse response)
            {
                Status = response.StatusDescription;
            }
            catch (Exception ex)
            {
                Status = ex.ToString();
            }
        }

        private RelayCommand _getDataCommand;
        public RelayCommand GetDataCommand
        {
            get
            {
                if (_getDataCommand == null)
                {
                    _getDataCommand = new RelayCommand(param => GetData(), param => IsValidUsername(Username));
                }
                return _getDataCommand;
            }
        }

        public bool IsValidUsername(string username)
        {
            if (username != null)
            {
                return Regex.IsMatch(username, "^[0-9\\p{L} _]+$");
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Info tab data
        private BitmapImage _profileIcon;
        public BitmapImage ProfileIcon
        {
            get { return _profileIcon; }
            set
            {
                if (_profileIcon != value)
                {
                    _profileIcon = value;
                    RaisePropertyChanged("ProfileIcon");
                }
            }
        }

        private string _summonerLevel;
        public string SummonerLevel
        {
            get { return _summonerLevel; }
            set
            {
                if (_summonerLevel != value)
                {
                    _summonerLevel = value;
                    RaisePropertyChanged("SummonerLevel");
                }
            }
        }

        private string _summonerRevisionDate;
        public string SummonerRevisionDate
        {
            get { return _summonerRevisionDate; }
            set
            {
                if (_summonerRevisionDate != value)
                {
                    _summonerRevisionDate = value;
                    RaisePropertyChanged("SummonerRevisionDate");
                }
            }
        }

        public List<LeaguePosition> Leagues { get; set; }

        private BitmapImage _tierIcon1;
        public BitmapImage TierIcon1
        {
            get { return _tierIcon1; }
            set
            {
                if (_tierIcon1 != value)
                {
                    _tierIcon1 = value;
                    RaisePropertyChanged("TierIcon1");
                }
            }
        }
        private string _queueType1;
        public string QueueType1
        {
            get { return _queueType1; }
            set
            {
                if (_queueType1 != value)
                {
                    _queueType1 = value;
                    RaisePropertyChanged("QueueType1");
                }
            }
        }
        private string _rank1;
        public string Rank1
        {
            get { return _rank1; }
            set
            {
                if (_rank1 != value)
                {
                    _rank1 = value;
                    RaisePropertyChanged("Rank1");
                }
            }
        }

        private BitmapImage _tierIcon2;
        public BitmapImage TierIcon2
        {
            get { return _tierIcon2; }
            set
            {
                if (_tierIcon2 != value)
                {
                    _tierIcon2 = value;
                    RaisePropertyChanged("TierIcon2");
                }
            }
        }
        private string _queueType2;
        public string QueueType2
        {
            get { return _queueType2; }
            set
            {
                if (_queueType2 != value)
                {
                    _queueType2 = value;
                    RaisePropertyChanged("QueueType2");
                }
            }
        }
        private string _rank2;
        public string Rank2
        {
            get { return _rank2; }
            set
            {
                if (_rank2 != value)
                {
                    _rank2 = value;
                    RaisePropertyChanged("Rank1");
                }
            }
        }

        private BitmapImage _tierIcon3;
        public BitmapImage TierIcon3
        {
            get { return _tierIcon3; }
            set
            {
                if (_tierIcon3 != value)
                {
                    _tierIcon3 = value;
                    RaisePropertyChanged("TierIcon1");
                }
            }
        }
        private string _queueType3;
        public string QueueType3
        {
            get { return _queueType3; }
            set
            {
                if (_queueType3 != value)
                {
                    _queueType3 = value;
                    RaisePropertyChanged("QueueType3");
                }
            }
        }
        private string _rank3;
        public string Rank3
        {
            get { return _rank3; }
            set
            {
                if (_rank3 != value)
                {
                    _rank3 = value;
                    RaisePropertyChanged("Rank3");
                }
            }
        }
        #endregion

        #region Info tab logic
        public void GetInfo()
        {
            // get a player from name input
            Summoner = api.GetSummonerByName(Region, Username);

            SummonerLevel = "Level " + Summoner.SummonerLevel;
            SummonerRevisionDate = Api.Api.FromUnixTime(Summoner.RevisionDate).ToString();

            // get profile icon from static api
            string profileIconUrl = staticApi.GetProfileIconUrl(Summoner.ProfileIconId, Region);

            Uri uri = new Uri(profileIconUrl);
            ProfileIcon = new BitmapImage(uri);

            Leagues = api.GetLeaguePositionById(Region, Summoner.Id);
            string tierIconLocation = "pack://application:,,,/LolApp;component/resources/tier-icons/{0}_{1}.png";

            if (Leagues.Count >= 1)
            {
                QueueType1 = QueueFormat(Leagues[0]);
                Rank1 = RankFormat(Leagues[0]);
                Uri tierUri = new Uri(String.Format(tierIconLocation, Leagues[0].Tier.ToLower(), Leagues[0].Rank.ToLower()));
                TierIcon1 = new BitmapImage(tierUri);
            }
            if (Leagues.Count >= 2)
            {
                QueueType2 = QueueFormat(Leagues[1]);
                Rank2 = RankFormat(Leagues[1]);
                Uri tierUri = new Uri(String.Format(tierIconLocation, Leagues[1].Tier.ToLower(), Leagues[1].Rank.ToLower()));
                TierIcon2 = new BitmapImage(tierUri);
            }
            if (Leagues.Count >= 3)
            {
                QueueType3 = QueueFormat(Leagues[2]);
                Rank3 = RankFormat(Leagues[2]);
                Uri tierUri = new Uri(String.Format(tierIconLocation, Leagues[2].Tier.ToLower(), Leagues[2].Rank.ToLower()));
                TierIcon3 = new BitmapImage(tierUri);
            }
        }

        /// <summary>
        /// Formats a league position into a string that displays the rank and tier in a readable format
        /// </summary>
        /// <param name="league">League object to input</param>
        /// <returns>Rank and tier in readable form</returns>
        private string RankFormat(LeaguePosition league)
        {
            return league.Tier[0] + league.Tier.Substring(1).ToLower() + " " + league.Rank;       // rank always appears in uppercase, so lower every char except the first
        }

        private string QueueFormat(LeaguePosition league)
        {
            switch (league.QueueType)
            {
                case "RANKED_SOLO_5x5":
                    return "5v5 Solo/Duo";
                case "RANKED_FLEX_SR":
                    return "5v5 Flex";
                default:
                    return league.QueueType;
            }
        }
        #endregion
    }
}
