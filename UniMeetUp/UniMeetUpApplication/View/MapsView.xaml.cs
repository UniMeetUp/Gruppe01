using System;
using System.Collections.Generic;
using System.Device.Location;
using System.IO;
using System.Net;
using System.Reflection;
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
            //Skal ændres til Path.GetFullPath(Properties.Resources.ApplicationGoogleMaps.html)

            /* if (File.Exists(Properties.Resources.ApplicationGoogleMaps))
             {
                 //Skal ændres til Path.GetFullPath(Properties.Resources.ApplicationGoogleMaps.html)
                 Uri uri = new Uri(Properties.Resources.ApplicationGoogleMaps);

                 MyWebBrowser.Navigate(uri);
             }
             */


            //if (File.Exists(Path.GetFullPath(@"..\..\View\GoogleMapsWebsite\ApplicationGoogleMaps.html")))
            //{
            //    //Skal ændres til Path.GetFullPath(Properties.Resources.ApplicationGoogleMaps.html)
            //    Uri uri = new Uri(Path.GetFullPath(@"..\..\View\GoogleMapsWebsite\ApplicationGoogleMaps.html"));

            //    MyWebBrowser.Navigate(uri);
            //}
           
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"..\..\View\GoogleMapsWebsite\ApplicationGoogleMaps.html"))
            {
                //MessageBox.Show("OK");
                //Skal ændres til Path.GetFullPath(Properties.Resources.ApplicationGoogleMaps.html)
                Uri uri = new Uri(AppDomain.CurrentDomain.BaseDirectory + @"..\..\View\GoogleMapsWebsite\ApplicationGoogleMaps.html");

                MyWebBrowser.Navigate(uri);
            }
            else
            {
                
                Uri toMaps = new Uri("http://62.107.0.222:5000/assets/ApplicationGoogleMaps.html");

                MyWebBrowser.Navigate(toMaps);
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

            public void AddWayPoint(Decimal lat, Decimal lng, string time, string description)
            {
                var user = ((MasterViewModel)App.Current.MainWindow.DataContext).User;

                browser.InvokeScript("addWayPoint", new object[] 
                    { lat, lng,user.emailAdresse, time, description, "wayPoint" });

            }


            public void UpdateCurrentWayPoint(string meetTime, string description, decimal latitude, decimal longitute)
            {

                string descriptionToServer = meetTime + ';' + description;

                var user = ((MasterViewModel)App.Current.MainWindow.DataContext).User;

                WayPoint wayPointForGroup = new WayPoint()
                {
                    GroupId = user.Groups.CurrentGroup.GroupId,
                    Latitude = (decimal)latitude,
                    Longitude = (decimal)longitute,
                    Timestamp = DateTime.Now,
                    UserId = user.emailAdresse,
                    Description = descriptionToServer
                    
                };


                if (_sal.Post_Group_WayPoint(wayPointForGroup) != HttpStatusCode.NoContent)
                {
                    MessageBox.Show("fejl i WayPointService");
                }


            }



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

                            browser.InvokeScript("setCurrentMarker", new object[] { latitude, longitute, userLocation.UserId, userLocation.Timestamp.ToString(), user.DisplayName, "red" });
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
                this.Dispatcher.Invoke(() =>
                {
                    plotAllUsers();
                    PlotWayPoint();
                });
            });
        }


        private void PlotWayPoint()
        {


            if (((MasterViewModel)App.Current.MainWindow.DataContext).User.Groups.CurrentGroup != null)
            {
                int id = ((MasterViewModel)App.Current.MainWindow.DataContext).User.Groups.CurrentGroup.GroupId;

                string wayPointFromServerAsString = _sal.Get_Group_WayPoints_for_group(id);

                if (wayPointFromServerAsString != "error")
                {
                    JObject wayPointjson = JObject.Parse(wayPointFromServerAsString);

                    Decimal lat = (Decimal)wayPointjson.GetValue("latitude");
                    Decimal lng = (Decimal)wayPointjson.GetValue("longitude");

                    string[] descriptions = ((string)wayPointjson.GetValue("description")).Split(';');

                    string wayPointTimeSet = descriptions[0];
                    string concreteDescription = descriptions[1];

                    string satByEmail = (string)wayPointjson.GetValue("userId");

                    browser.InvokeScript("addWayPoint", new object[]
                        { lat, lng,satByEmail, wayPointTimeSet, concreteDescription , "wayPoint" });
                }
                


            
            }
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

                    string howOld;
                    DateTime timeStampObj = (DateTime)location.ToObject<JObject>().GetValue("timeStamp");

                    
                    if (timeStampObj.Day < DateTime.Now.Day && timeStampObj.Month == DateTime.Now.Month)
                    {
                        howOld = "grey";
                    }
                    else if(timeStampObj.Day == DateTime.Now.Day &&  (DateTime.Now.Hour- timeStampObj.Hour) >4)
                    {
                        howOld = "yellow";
                    }
                    else
                    {
                        howOld = "red";
                    }


                    if (((MasterViewModel)App.Current.MainWindow.DataContext).User.emailAdresse == email)
                    {
                        browser.InvokeScript("setCurrentMarker", new object[] { latitude, longitude, email, timeStamp, displayName, howOld });
                    }
                    else
                    {
                        browser.InvokeScript("addMarkerWithInfo", new object[] { latitude, longitude, email, timeStamp, displayName, howOld });
                    }
                    

                  
                }
            }
        }
    }
}
