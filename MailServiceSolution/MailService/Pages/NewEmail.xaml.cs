using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MailService.Pages
{
    public partial class NewEmail : Page
    {
        private readonly List<EmailClassification> _emails;

        public NewEmail(List<EmailClassification> emails) 
        {
            _emails = emails;

            InitializeComponent();
        }

        private void UseNaiveBayes(object sender, RoutedEventArgs e)
        {
            var text = EmailBox.Text;

            var method = new NaiveBayes(text);

            EmailClassification email = method.Classify();

            _emails.Add(email);
        }
    }
}