using MailService.Pages;
using System.Windows;
using System.Windows.Controls;

namespace MailService
{
    public partial class Layout : Window
    {
        private readonly Classifications _classifications;

        public Layout()
        {
            _classifications = new Classifications();

            InitializeComponent();
        }

        private void WindowIsLoaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = _classifications;

            PageViewer.Navigate(new NewEmail(_classifications));
        }

        private void ChangeFrameByClick(object sender, RoutedEventArgs e)
        {
            string buttonName = ((Button)sender).Name;

            var navigation = new PageNavigation(buttonName, _classifications);

            Page expectedPage = navigation.GetPage();

            PageViewer.Navigate(expectedPage);
        }
    }
}