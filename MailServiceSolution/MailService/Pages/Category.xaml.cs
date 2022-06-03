using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MailService.Pages
{
    public partial class Category : Page
    {
        private readonly Frame _frame;
        private readonly IEnumerable<EmailClassification> _emails;

        public Category(IEnumerable<EmailClassification> emails)
        {
            _emails = emails;

            InitializeComponent();
        }

        private void WindowIsLoaded(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < _emails.Count(); i++)
            {
                string text = _emails.ElementAt(i).Text;

                RowDefinition rowDefinition = RowDefinition();
                Button button = Button(text, i.ToString());
                Border borderWithButton = Border(button);

                AddToContainer(borderWithButton, i + 1);
            }
        }

        private void AddToContainer(UIElement child, int row)
        {
            Grid.SetRow(child, row);

            Container.Children.Add(child);
        }

        private RowDefinition RowDefinition()
        {
            var rowDefinitionCreator = new NewRowDefinition(100);

            return rowDefinitionCreator.Create();
        }

        private Button Button(string emailPreview, string index)
        {
            var buttonCreator = new NewButton(emailPreview, index, ChangeFrameByClick, new EmailPreview());

            return buttonCreator.Create();
        }

        private Border Border(UIElement child)
        {
            var borderCreator = new NewBorder(child);

            return borderCreator.Create();
        }

        private int EmailIndex(Button button) => Convert.ToInt32(button.Name);

        private void ChangeFrameByClick(object sender, RoutedEventArgs e)
        {
            int emailIndex = EmailIndex((Button)sender);

            var selectedEmail = _emails.ElementAt(emailIndex);

            NavigationService.Navigate(selectedEmail);
        }
    }
}