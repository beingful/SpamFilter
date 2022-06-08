using System.Windows;
using System.Windows.Controls;

namespace MailService.Pages
{
    public partial class NewEmail : Page
    {
        private readonly Classifications _classifications;

        public NewEmail(Classifications classifications)
        {
            _classifications = classifications;

            InitializeComponent();
        }

        private void UseNaiveBayes(object sender, RoutedEventArgs e)
        {
            var text = EmailBox.Text;

            if (text != string.Empty)
            {
                EmailClassification email = StartBayes(text);

                _classifications.AddClassification(email);

                StartLearning(email);

                EmailBox.Text = string.Empty;
            }
        }

        private EmailClassification StartBayes(string text)
        {
            var method = new NaiveBayes(text);

            return method.Classify();
        }

        private void StartLearning(EmailClassification email)
        {
            var learning = new Learning(email);

            learning.Start();
        }
    }
}