using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Net;
using System.Configuration;
using LolApp.Data;
using LolApp.Api;
using LolApp.Properties;
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
    }
}
