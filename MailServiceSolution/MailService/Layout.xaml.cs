using MailService.Pages;
using System.Windows;
using System.Windows.Controls;

namespace MailService
{
    public partial class Layout : Window
    {
        public Layout() => InitializeComponent();

        private void WindowIsLoaded(object sender, RoutedEventArgs e)
        {
            DataContext = new Classifications();

            PageViewer.Navigate(new NewEmail((Classifications)DataContext));
        }

        private void ChangeFrameByClick(object sender, RoutedEventArgs e)
        {
            string buttonName = ((Button)sender).Name;

            var navigation = new PageNavigation(buttonName, (Classifications)DataContext);

            Page expectedPage = navigation.GetPage();

            PageViewer.Navigate(expectedPage);
        }
    }
}