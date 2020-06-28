/// Assignment 5
/// Martin Lobell
/// 2020-05-14

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
using System.Windows.Shapes;

namespace ControlTower
{
    public partial class FlightWindow : Window
    {
        private string flightCode;
        bool ok;

        public FlightWindow(string flightCode, bool ok)
        {
            InitializeComponent();

            this.flightCode = flightCode;
            this.ok = ok;

            InitializeGUI();
        }

        /// <summary>
        /// Aktiverar vissa knappar beroende på vilket boolean-värde som skickats med.
        /// Listar gradantalet som ett flyg kan svänga.
        /// Visar upp tillhörande bild på flyg.
        /// Skapar events för lyftning, landning och riktningsbyte.
        /// </summary>
        public void InitializeGUI()
        {
            if(ok)
            {
                StartBtn.IsEnabled = true;
                LandBtn.IsEnabled = false;
                RouteList.IsEnabled = false;
            }
            else
            {
                StartBtn.IsEnabled = false;
                LandBtn.IsEnabled = true;
                RouteList.IsEnabled = true;
            }
            
            this.Title = flightCode;

            string[] arr;
            arr = new string[3] {"45°", "90°", "180°"};
            foreach (string i in arr)
            {
                RouteList.Items.Add((string)i);
            }

            if(flightCode == "Abc 123")
            {
                planeImg.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "plane1.jpg", UriKind.Absolute));
            }
            else if(flightCode == "Def 456")
            {
                planeImg.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "plane2.png", UriKind.Absolute));
            }
            else
                planeImg.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "plane3.png", UriKind.Absolute));
        }

        public event EventHandler<TakeOffArgs> TakeOff;
        public event EventHandler<ChangeRouteArgs> ChangeRoute;
        public event EventHandler<LandArgs> Landing;

        /// <summary>
        /// Triggar start-eventet och kör tillhörande metod med tillhörande EventArgs.
        /// </summary>
        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            TakeOffArgs takeOffInfo = new TakeOffArgs(this.Title, "started");
            Console.WriteLine(this.Title);
            OnTakeOff(takeOffInfo);
            StartBtn.IsEnabled = false;
            LandBtn.IsEnabled = true;
            RouteList.IsEnabled = true;
        }

        /// <summary>
        /// Triggar landnings-eventet och kör tillhörande metod med tillhörande EventArgs.
        /// </summary>
        private void LandBtn_Click(object sender, RoutedEventArgs e)
        {
            LandArgs landingInfo = new LandArgs(this.Title, "landed");
            OnLanding(landingInfo);
            Close();
        }

        /// <summary>
        /// Triggar riktningsbytes-eventet och kör tillhörande metod med tillhörande EventArgs.
        /// </summary>
        private void ActionList_SelectionChanged(object sender, RoutedEventArgs e)
        {
            ChangeRouteArgs routeChangeInfo = new ChangeRouteArgs(this.Title, "now heading " + RouteList.SelectedItem.ToString());
            OnRouteChange(routeChangeInfo);
        }

        /// <summary>
        /// Ropar på delegaten med rätt flygkod och status
        /// </summary>
        public void OnTakeOff(TakeOffArgs e)
        {
            if (TakeOff != null)
                TakeOff(this, e);
        }

        /// <summary>
        /// Ropar på delegaten med rätt flygkod och status
        /// </summary>
        private void OnLanding(LandArgs e)
        {
            if (Landing != null)
                Landing(this, e);
        }

        /// <summary>
        /// Ropar på delegaten med rätt flygkod och status
        /// </summary>
        private void OnRouteChange(ChangeRouteArgs e)
        {
            if (ChangeRoute != null)
                ChangeRoute(this, e);
        }
    }
}
