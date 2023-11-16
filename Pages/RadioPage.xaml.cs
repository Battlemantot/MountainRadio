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
using RadioBrowser;

namespace MountainRadio.Pages
{
    /// <summary>
    /// Interaction logic for RadioPage.xaml
    /// </summary>
    public partial class RadioPage : Page
    {
        public RadioPage()
        {
            InitializeComponent();
        }

        private async void btnSearchStation_Click(object sender, RoutedEventArgs e)
        {
            var radioBrowser = new RadioBrowserClient();
            var results = await radioBrowser.Search.ByNameAsync(StationNameSearch.Text);
            var foundStations = results.ToArray();
            var firstStation = foundStations[0];
            StationName.Text = "Station name: " + firstStation.Name;
            StationCountry.Text = "Country: " + firstStation.CountryCode;
            //try
            //{
            //    StationImage.Source = new BitmapImage(new Uri(firstStation.Favicon.ToString(), UriKind.Absolute));
            //}
            //catch 
            //{
            //    StationImage.Source = null;
            //}
            RadioStream.Source = firstStation.Url;

        }

        private void ResumeStopStation_Click(object sender, RoutedEventArgs e)
        {
            if (ResumeStopStation.Content.ToString() == "Stop")
            {
                RadioStream.Close();
                ResumeStopStation.Content = "Start";
            }
            else
            {
                RadioStream.Play();
                ResumeStopStation.Content = "Stop";
                RadioStream.Volume = VolumeSlider.Value;
            }
        }
    }
}
