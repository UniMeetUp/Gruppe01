using System;
using System.Collections.Generic;
using System.Device.Location;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using CommonLib.Models;
using Newtonsoft.Json.Linq;
using UniMeetUpApplication.Model;
using UniMeetUpApplication.ServerAccessLayer.Interfaces;
using UniMeetUpApplication.ViewModel;


namespace UniMeetUpApplication.View
{
    /// <summary>
    /// Interaction logic for MapsView.xaml
    /// </summary>
    public partial class MapsView : UserControl
    {
        public static WebBrowser browser;
        private ServerAccessLayer.ServerAccessLayer _sal = new ServerAccessLayer.ServerAccessLayer();

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
            

            Thread.Sleep(1000);
        }


        private void WebBrowser_OnLoaded(object sender, RoutedEventArgs e)
        {

            ((WebBrowser) sender).ObjectForScripting = new HtmlInteropInternalTestClass();


            //if (((MasterViewModel) App.Current.MainWindow.DataContext).User.Groups.CurrentGroup != null)
            //{
            //    int id = ((MasterViewModel) App.Current.MainWindow.DataContext).User.Groups.CurrentGroup.GroupId;
            //    int Id = 8;
            //    string userLocations = _sal.Get_User_locations_for_group(Id);
            //
            //    JArray jsonLocations = new JArray(JArray.Parse(userLocations));
            //
            //
            //
            //    foreach (var location in jsonLocations)
            //    {
            //        double latitude = (double) location.ToObject<JObject>().GetValue("latitude");
            //        double longitude = (double) location.ToObject<JObject>().GetValue("longitude");
            //
            //        browser.InvokeScript("addMarker", new object[] {latitude, longitude});
            //
            //    }
            //
            //}
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
                            
                            browser.InvokeScript("addMarker", new object[] {latitude, longitute});

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
    }
}
