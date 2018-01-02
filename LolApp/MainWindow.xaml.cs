using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Text.RegularExpressions;
using System.Configuration;
using Newtonsoft.Json;
using LolApp.Data;
using LolApp.Api;

namespace LolApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string apiKey;
        RiotApi api;
        StaticApi staticApi;

        public MainWindow()
        {
            InitializeComponent();      // initialize window and initial components
            InitializeScreen();         // populate items
        }

        private void InitializeScreen()
        {
            cbxRegion.Items.Add(new Region("NA","na1"));   
            cbxRegion.Items.Add(new Region("EUW", "euw1"));  
            cbxRegion.Items.Add(new Region("EUN", "eun1"));
            cbxRegion.Items.Add(new Region("KR", "kr"));
            cbxRegion.SelectedIndex = 0;
            

            apiKey = ConfigurationManager.AppSettings["apiKey"];    // get API key from config file
            api = new RiotApi(apiKey);                              // create a new instance of the Riot API
            staticApi = new StaticApi(apiKey);                      // create a new instance of the Riot Static API

        }

        private void PopulateContent()
        {
            string name = txtUsername.Text;

            // get a player from name input
            var region = (Region)cbxRegion.SelectedItem;
            Summoner player = api.GetSummonerByName(region, name);
            txtName.Text = player.Name;
            txtLevel.Text = "Level " + player.SummonerLevel.ToString();

            // get profile icon from static api
            string profileIconUrl = staticApi.GetProfileIconUrl(player.ProfileIconId, region);

            // put player info into data grid container
            var uri = new Uri(profileIconUrl);
            var bitmap = new BitmapImage(uri);
            imgProfileIcon.Source = bitmap;

            //// check validity of name
            //if (Regex.IsMatch(name, "^[0-9\\p{L} _\\.]+$"))
            //{
            //    throw new Exception("Invalid username");
            //}
        }

        private void BtnGetInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PopulateContent();
            }
            // if exception is HTTP error code
            catch (WebException ex) when (ex.Response is HttpWebResponse response)
            {
                lblStatus.Text = response.StatusDescription;
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.ToString();
            }
        }
    }
}
