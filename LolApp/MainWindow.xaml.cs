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
using Newtonsoft.Json;

namespace LolApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string apiKey = "RGAPI-214283fe-7c65-4211-89d5-8d51585e98a9";

        public MainWindow()
        {
            InitializeComponent();      // initialize window and initial components
            InitializeScreen();         // populate items
        }

        private void InitializeScreen()
        {
            lstRegion.Items.Add("NA");
            lstRegion.Items.Add("EUW");
            lstRegion.Items.Add("EUN");
            lstRegion.Items.Add("KR");
            lstRegion.Text = "NA";
        }

        private void PopulateContent()
        {
            string name = txtUsername.Text;

            //// check validity of name
            //if (Regex.IsMatch(name, "^[0-9\\p{L} _\\.]+$"))
            //{
            //    throw new Exception("Invalid username");
            //}

            string summonerUrl = "https://na1.api.riotgames.com/lol/summoner/v3/summoners/by-name/" + name + "?api_key=" + apiKey;  // generate url
            var response = new WebClient().DownloadString(summonerUrl);                                                             // get json string
            Dictionary<string, string> playerData = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);            // convert json to dict

            long playerId = Convert.ToInt64(playerData["id"]);      // get player id from username

            string spectatorUrl = "https://na1.api.riotgames.com/lol/spectator/v3/active-games/by-summoner/" + playerId + "?api_key=" + apiKey;
            var spectatorResponse = new WebClient().DownloadString(spectatorUrl);
            Dictionary<string, string> gameData = JsonConvert.DeserializeObject<Dictionary<string, string>>(spectatorResponse);

            lblStatus.Text = gameData["gameid"].ToString();


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
