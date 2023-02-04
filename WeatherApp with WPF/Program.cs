using System;
using System.Windows;
using System.Net;
using System.Json;

namespace WeatherApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetWeather_Click(object sender, RoutedEventArgs e)
        {
            string city = CityInput.Text;
            string apiKey = "your-api-key-here";
            string url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}";

            using (WebClient client = new WebClient())
            {
                try
                {
                    string json = client.DownloadString(url);
                    JsonValue jsonData = JsonValue.Parse(json);
                    string temperature = jsonData["main"]["temp"];
                    string weatherDescription = jsonData["weather"][0]["description"];
                    string location = jsonData["name"];

                    Temperature.Content = temperature;
                    Description.Content = weatherDescription;
                    Location.Content = location;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not get weather data: " + ex.Message);
                }
            }
        }
    }
}
