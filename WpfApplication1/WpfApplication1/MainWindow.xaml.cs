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
using WpfApplication1.Service;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IFhirService m_fireService;


        public MainWindow()
        {
            m_fireService = new FhirWebService("http://spark.furore.com/fhir");
            InitializeComponent();
            //var names = m_fireService.GetPatients("Donald");
            //resultLabel.Content = "";
            //foreach(var a in names)
            //{
            //    resultLabel.Content += a + "\r\n";
            //}
        }

        private void nameTextbox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (String.Equals(nameTextbox.Text, "Name to search for")) nameTextbox.Text = "";

        }

        private void idTextbox_GotFocus(object sender, RoutedEventArgs e)
        {
            idTextbox.Text = "";
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

        private void nameSendButton_OnClicked(object sender, RoutedEventArgs e)
        {
            statusLabel.Content = "Searching..";

            var names = m_fireService.GetPatients(nameTextbox.Text);
            resultLabel.Content = "";
            foreach (var a in names)
            {
                resultLabel.Content += a + "\r\n";
            }

            statusLabel.Content = "";

        }

        private void idSendButton_OnClicked(object sender, RoutedEventArgs e)
        {

            statusLabel.Content = "Searching..";
            var names = m_fireService.GetPatients(nameTextbox.Text);
            resultLabel.Content = "";
            foreach (var a in names)
            {
                resultLabel.Content += a + "\r\n";
            }
            statusLabel.Content = "";
        }

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


