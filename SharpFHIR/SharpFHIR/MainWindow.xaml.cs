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
using SharpFHIR.Service;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace SharpFHIR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private readonly IFhirService m_fireService;


        public MainWindow()
        {
            //m_fireService = new FhirWebService("http://spark.furore.com/fhir");
            m_fireService = new FhirWebService("https://try.smilecdr.com:8000/");
            InitializeComponent();
            //var names = m_fireService.GetPatients("Donald");
            //resultLabel.Content = "";
            //foreach(var a in names)
            //{
            //    resultLabel.Content += a + "\r\n";
            //}
        }

        /*
         * Text manipulation when GotFocus or LostFocus
         */

        private void nameTextbox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (String.Equals(nameTextbox.Text, "Name to search for"))
            {
                nameTextbox.Text = "";
            }
        }

        private void idTextbox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (String.Equals(idTextbox.Text, "ID to search for"))
            {
                idTextbox.Text = "";
            }
        }

        private void nameTextbox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(nameTextbox.Text))
                nameTextbox.Text = "Name to search for";
        }

        private void idTextbox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(idTextbox.Text))
                idTextbox.Text = "ID to search for";
        }

        /*
         * Enables the buttons
         */

        private void nameSendButton_OnClicked(object sender, RoutedEventArgs e)
        {
            var names = m_fireService.GetPatients(nameTextbox.Text);
            resultTextbox.Text = "";
            foreach (var a in names)
            {
                resultTextbox.Text += a + "\r\n";
            }
        }

        private void idSendButton_OnClicked(object sender, RoutedEventArgs e)
        {
            /* 
             * Commented 2016-07-15 BP
             * For searching with ID
             * Not yet functional
             */

            //int idTextboxInt;
            //idTextboxInt = Convert.ToInt32(idTextbox.Text);

            /*
             *
             */
            var names = m_fireService.GetPatients("94");

            resultTextbox.Text = "";
            foreach (var a in names)
            {
                resultTextbox.Text += a + "\r\n";
            }
            
            string resultPlaceholder = "This search function is not yet implemented.\r\nYou tried to search for patient ID '" + idTextbox.Text + "'";
            //resultLabel.Content = resultPlaceholder;
            resultTextbox.Text = resultPlaceholder;
        }

        private async void aboutButton_OnClicked(object sender, RoutedEventArgs e)
        {
            /*
             */

            //resultTextbox.Text = "Hello from the other side";

            await this.ShowMessageAsync("I'm a fhir and I burn", "Made with careless carelessness by bp\r\nwww.eosinjunkie.com");
        }


        /*
         * Enables Enter => Search
         */

        private void nameTextbox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                nameSendButton_OnClicked(sender, e);
            }
        }

        private void idTextbox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                idSendButton_OnClicked(sender, e);
            }
        }
    }

}


