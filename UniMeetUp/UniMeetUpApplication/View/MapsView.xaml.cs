using System;
using System.Device.Location;
using System.IO;
using System.Windows;
using System.Windows.Controls;




namespace UniMeetUpApplication.View
{
    /// <summary>
    /// Interaction logic for MapsView.xaml
    /// </summary>
    public partial class MapsView : UserControl
    {
        public static WebBrowser browser;


        public MapsView()
        {
            InitializeComponent();

            // Load map
            LoadMaps();

            browser = MyWebBrowser;
        }


        public void LoadMaps()
        {
            //if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "ApplicationGoogleMaps.html"))
            //{

            //    Uri uri = new Uri(AppDomain.CurrentDomain.BaseDirectory + "ApplicationGoogleMaps.html");

            //  MyWebBrowser.Navigate(uri);
            //}
            
            if (File.Exists(Path.GetFullPath(@"..\..\View\GoogleMapsWebsite\ApplicationGoogleMaps.html")))
            {

                Uri uri = new Uri(Path.GetFullPath(@"..\..\View\GoogleMapsWebsite\ApplicationGoogleMaps.html"));

              MyWebBrowser.Navigate(uri);
            }
            else
            {
                MessageBox.Show("File not found:");
            }

           




        }


        private void WebBrowser_OnLoaded(object sender, RoutedEventArgs e)
        {

            ((WebBrowser)sender).ObjectForScripting = new HtmlInteropInternalTestClass();
        }



        [System.Runtime.InteropServices.ComVisibleAttribute(true)]
        public class HtmlInteropInternalTestClass
        {

            private GeoCoordinateWatcher watcher = null;


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
                            MessageBox.Show("unknowlocation");

                        }
                        else
                        {
                            double latitude = watcher.Position.Location.Latitude;
                            double longitute = watcher.Position.Location.Longitude;

                            browser.InvokeScript("addMarker", new object[]{latitude, longitute});
                           

                        }
                    }
                    else
                    {
                        
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
