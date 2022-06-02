using MailService.Pages;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MailService
{
    public partial class Layout : Window
    {
        private readonly List<EmailClassification> _emails; 

        public Layout() 
        {
            _emails = new List<EmailClassification>();

            InitializeComponent();
        }

        private void WindowIsLoaded(object sender, RoutedEventArgs e) 
            => PageViewer.Navigate(new NewEmail(_emails));

        private void ChangeFrameByClick(object sender, RoutedEventArgs e)
        {
            string buttonName = ((Button)sender).Name;

            var navigation = new PageNavigation(buttonName, _emails);

            Page expectedPage = navigation.GetPage();

            PageViewer.Navigate(expectedPage);
        }
    }
}