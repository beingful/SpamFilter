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
            SetCategoryToChangeButton();
        }

        private void SetText() => EmailBox.Text = _email.TextRepresentation.Text;

        private void SetCategoryToChangeButton()
        {
            var buttons = new CategoryButtons(_email.TextRepresentation.Category);

            CategoryButtonView buttonView = buttons.GetCategoryButtonView();

            string template = CategoryToChange.Content.ToString();

            CategoryToChange.Content = string.Format(template, buttonView.Content);
            CategoryToChange.Background = buttonView.Background;
        }

        private void RelearnByClick(object sender, RoutedEventArgs e)
        {
            var category = ((Button)sender).Content as string;

            var learning = new Learning(_email, category);

            learning.Start();

            _email.TextRepresentation.Category = category;
        }
    }
}