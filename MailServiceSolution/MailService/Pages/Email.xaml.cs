using System.Windows;
using System.Windows.Controls;

namespace MailService.Pages
{
    public partial class Email : Page
    {
        private readonly EmailClassification _email;

        public Email(EmailClassification email)
        {
            _email = email;

            InitializeComponent();
        }

        private void WindowIsLoaded(object sender, RoutedEventArgs e)
        {
            SetText();
            SetcomboBoxSelectedItem();
        }

        private void SetText() => EmailBox.Text = _email.Text;

        private void SetCategoryButton()
        {
            var buttons = new CategoryButtons(_email.Category);

            CategoryButtonView buttonView = buttons.GetCategoryButtonView();

            CategoryToChange.Content = buttonView.Content;

            CategoryToChange.Background = buttonView.Background;
        }


    }
}