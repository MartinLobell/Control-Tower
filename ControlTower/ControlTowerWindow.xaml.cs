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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControlTower
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ControlTowerWindow : Window
    {
        public ControlTowerWindow()
        {
            InitializeComponent();
            InitializeGUI();
        }

        /// <summary>
        /// Hämtar alla valbara flygkoder och presenterar dem i comboboxen, samt markerar den första.
        /// </summary>
        public void InitializeGUI()
        {
            string[] arr;
            arr = new string[3] { "Abc 123", "Def 456", "Ghi 789" };
            foreach (string i in arr)
            {
                CodeBox.Items.Add((string)i);
            }

            CodeBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Hämtar flygkoden, lägger till rad som säger att just det flyget har skickats till runway och när.
        /// Öppnar fönstret för valt flyg och binder valt event till tillhörande metod.
        /// </summary>
        private void CreateNewFlight()
        {
            string flightCode = ReadFlightCode();

            if (!string.IsNullOrEmpty(flightCode))
            {
                string chosenFlight = CodeBox.SelectedItem.ToString();
                infoBox.Items.Add($"{chosenFlight} \t\t\t\t\t Sent to runway... \t\t\t\t\t {DateTime.Now.ToLongTimeString()}");
                FlightWindow fw = new FlightWindow(chosenFlight, true);
                fw.DataContext = this.DataContext;
                fw.Show();

                fw.TakeOff += OnTakeOff;
                fw.Landing += OnLanding;
                fw.ChangeRoute += OnRouteChange;
            }
        }

        /// <summary>
        /// Hämtar vald flygkod från comboboxen.
        /// </summary>
        private string ReadFlightCode()
        {       
            return CodeBox.SelectedItem.ToString();
        }


        /// <summary>
        /// Om det valts att flyget ska lyfta läggs en sträng som säger det till i listboxen.
        /// </summary>
        private void OnTakeOff(object sender, TakeOffArgs e)
        {
            string strOut = string.Format("{0} \t\t\t\t\t {1} \t\t\t\t\t\t {2}", e.FlightCode, e.Status, DateTime.Now.ToLongTimeString());
            infoBox.Items.Add(strOut);
        }

        /// <summary>
        /// Om det valts att flyget ska landa läggs en sträng som säger det till i listboxen.
        /// </summary>
        private void OnLanding(object sender, LandArgs e)
        {
            string strOut = string.Format("{0} \t\t\t\t\t {1} \t\t\t\t\t\t {2}", e.FlightCode, e.Status, DateTime.Now.ToLongTimeString());
            infoBox.Items.Add(strOut);
        }

        /// <summary>
        /// Om det valts att flyget ska byta riktning läggs en sträng som säger det till i listboxen.
        /// </summary>
        private void OnRouteChange(object sender, ChangeRouteArgs e)
        {
            string strOut = string.Format("{0} \t\t\t\t\t {1} \t\t\t\t {2}", e.FlightCode, e.Status, DateTime.Now.ToLongTimeString());
            infoBox.Items.Add(strOut);
        }

        /// <summary>
        /// Skapar nytt flyg och skickar det till runway.
        /// </summary>
        public void SendNextBtn_Click(object sender, EventArgs e)
        {
            CreateNewFlight();
        }

        /// <summary>
        /// Om man markerar ett flyg i listboxen kan man ändra status för det flyget.
        /// </summary>
        public void infoBox_SelectionChanged(object sender, EventArgs e)
        {
            ChangeFlight();
        }

        /// <summary>
        /// På samma vis som i CreateNewFlight() så skapas en ny status för valt flyg.
        /// Hämtar flygkoden (strängens första 7 tecken) från det flyg vars status ska uppdateras.
        /// Skickar också med en boolean för att FlightWindow ska veta om den får starta eller om den får byta riktning och landa.
        /// </summary>
        private void ChangeFlight()
        {
            string chosenString = infoBox.SelectedItem.ToString();
            string flightCode = chosenString.Substring(0, 7);

            if (!string.IsNullOrEmpty(flightCode))
            {
                FlightWindow fw = new FlightWindow(flightCode, false);
                fw.DataContext = this.DataContext;
                fw.Show();

                fw.TakeOff += OnTakeOff;
                fw.Landing += OnLanding;
                fw.ChangeRoute += OnRouteChange;
            }
        }
    }
}
