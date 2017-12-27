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

namespace LolApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string apiKey = ConfigurationManager.AppSettings["apiKey"];

        public MainWindow()
        {
            InitializeComponent();      // initialize window and initial components
            InitializeScreen();         // populate items
        }

        private void InitializeScreen()
        {
            lstRegion.Items.Add(new Region("NA","na1"));   
            lstRegion.Items.Add(new Region("EUW", "euw1"));  
            lstRegion.Items.Add(new Region("EUN", "eun1"));
            lstRegion.Items.Add(new Region("KR", "kr"));
            lstRegion.SelectedIndex = 0;
        }

        private void PopulateContent()
        {
            string name = txtUsername.Text;

            var api = new RiotApi(apiKey);

            var region = (Region)lstRegion.SelectedItem;
            Summoner player = api.GetSummonerByName(region.RegionCode, name);
            lblStatus.Text = player.Name;

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
