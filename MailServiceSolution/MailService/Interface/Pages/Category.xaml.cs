using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MailService.Pages
{
    public partial class Category : Page
    {
        private readonly IEnumerable<EmailClassification> _emails;

        public Category(IEnumerable<EmailClassification> emails)
        {
            _emails = emails;

            InitializeComponent();
        }

        private void WindowIsLoaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < _emails.Count(); i++)
            {
                string text = _emails.ElementAt(i).Text;

                RowDefinition rowDefinition = RowDefinition();
                Button button = Button(text, i.ToString());
                Border borderWithButton = Border(button);

                AddToContainer(borderWithButton, rowDefinition, i);
            }
        }

        private void AddToContainer(UIElement child, RowDefinition row, int rowIndex)
        {
            Grid.SetRow(child, rowIndex);

            Container.RowDefinitions.Add(row);
            Container.Children.Add(child);
        }

        private RowDefinition RowDefinition()
        {
            var rowDefinitionCreator = new NewRowDefinition(100);

            return rowDefinitionCreator.Create();
        }

        private Button Button(string emailPreview, string index)
        {
            var buttonCreator = new NewButton(index, emailPreview, ChangeFrameByClick, new EmailPreview());

            return buttonCreator.Create();
        }

        private Border Border(UIElement child)
        {
            var borderCreator = new NewBorder(child);

            return borderCreator.Create();
        }

        private void ChangeFrameByClick(object sender, RoutedEventArgs e)
        {
            int emailIndex = ((Button)sender).GetButtonIndex();

            var selectedEmail = _emails.ElementAt(emailIndex);

            NavigationService.Navigate(new Email(selectedEmail));
        }
    }
}