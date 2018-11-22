using System;
using System.Collections.Generic;
using System.Device.Location;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using CommonLib.Models;
using Newtonsoft.Json.Linq;
using UniMeetUpApplication.Model;
using UniMeetUpApplication.ServerAccessLayer.Interfaces;
using UniMeetUpApplication.Services;
using UniMeetUpApplication.ViewModel;


namespace UniMeetUpApplication.View
{
    /// <summary>
    /// Interaction logic for MapsView.xaml
    /// </summary>
    public partial class MapsView : UserControl
    {
        public static WebBrowser browser;
        private static ServerAccessLayer.ServerAccessLayer _sal = new ServerAccessLayer.ServerAccessLayer();

        public MapsView()
        {
            InitializeComponent();
            
            // Load map
            LoadMaps();


            browser = MyWebBrowser;
        }


        public void LoadMaps()
        {
            if (File.Exists(Path.GetFullPath(@"..\..\View\GoogleMapsWebsite\ApplicationGoogleMaps.html")))
            {

                Uri uri = new Uri(Path.GetFullPath(@"..\..\View\GoogleMapsWebsite\ApplicationGoogleMaps.html"));

              MyWebBrowser.Navigate(uri);
            }

            
            


        }


        private void WebBrowser_OnLoaded(object sender, RoutedEventArgs e)
        {
            ((WebBrowser) sender).ObjectForScripting = new HtmlInteropInternalTestClass();
        }



        [System.Runtime.InteropServices.ComVisibleAttribute(true)]
        public class HtmlInteropInternalTestClass
        {

            private GeoCoordinateWatcher watcher = null;
            private bool markerSet = false;


            private GeoCoordinate _currentLocation;
            GeoCoordinateWatcher _geoWatcher = new GeoCoordinateWatcher();

            public void GetCurrentGroupID()
            {
                watcher = new GeoCoordinateWatcher();
                // Catch the StatusChanged event.  
                watcher.StatusChanged += Watcher_StatusChanged;
                // Start the watcher.  
                watcher.Start();



            }

            private void Watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e) // Find GeoLocation of Device  
            {
                try
                {
                    if (e.Status == GeoPositionStatus.Ready)
                    {
                        // Display the latitude and longitude.  
                        if (watcher.Position.Location.IsUnknown)
                        {
                            browser.InvokeScript("GeoLocationNotSupported");
                        }
                        else
                        {
                            double latitude = watcher.Position.Location.Latitude;
                            double longitute = watcher.Position.Location.Longitude;


                            var user = ((MasterViewModel) App.Current.MainWindow.DataContext).User;

                            UserLocation userLocation = new UserLocation()
                            {
                                GroupId = user.Groups.CurrentGroup.GroupId,
                                Latitude = (decimal)latitude,
                                Longitude = (decimal)longitute,
                                Timestamp = DateTime.Now,
                                UserId = user.emailAdresse
                            };

                            if (_sal.Post_user_location(userLocation) != HttpStatusCode.NoContent)
                            {
                                MessageBox.Show("fejl i locationservice");
                            }
                            
                            

                            //browser.InvokeScript("addMarker", new object[] { latitude, longitute });
                            browser.InvokeScript("setStatus", new object[] {false});
                            
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Exeption");
                }
            }
        }


        private void MyWebBrowser_OnLoadCompleted(object sender, NavigationEventArgs e)
        {
            var task = Task.Factory.StartNew(() =>
            {
                //Thread.Sleep(1000);
                this.Dispatcher.Invoke(() => { plotAllUsers(); });
            });
        }

        private void plotAllUsers()
        {
            if (((MasterViewModel)App.Current.MainWindow.DataContext).User.Groups.CurrentGroup != null)
            {
                int id = ((MasterViewModel)App.Current.MainWindow.DataContext).User.Groups.CurrentGroup.GroupId;

                string userLocations = _sal.Get_User_locations_for_group(id);

                JArray jsonLocations = new JArray(JArray.Parse(userLocations));



                foreach (var location in jsonLocations)
                {
                    double latitude = (double)location.ToObject<JObject>().GetValue("latitude");
                    double longitude = (double)location.ToObject<JObject>().GetValue("longitude");
                    string timeStamp = location.ToObject<JObject>().GetValue("timeStamp").ToString();

                    string displayName = location.ToObject<JObject>().GetValue("user").ToObject<JObject>().GetValue("displayName").ToString();

                    string email = location.ToObject<JObject>().GetValue("userId").ToString();
                    browser.InvokeScript("addMarkerWithInfo", new object[] { latitude, longitude, email, timeStamp, displayName });
                }
            }
        }
    }
}
