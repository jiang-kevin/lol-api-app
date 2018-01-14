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
using LolApp.ViewModel;

namespace LolApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel vm;
        RiotApi riotApi = new RiotApi(ConfigurationManager.AppSettings["apiKey"]);
        StaticApi staticApi = new StaticApi(ConfigurationManager.AppSettings["apiKey"]);

        public MainWindow()
        {
            InitializeComponent();      // initialize window and initial components

            vm = new MainViewModel(riotApi, staticApi);
            DataContext = vm;
        }

        private void BtnGetInfo_Click(object sender, RoutedEventArgs e)
        {
            vm.GetInfo();
        }
    }
}
