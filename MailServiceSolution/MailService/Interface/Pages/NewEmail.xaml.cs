using System.Threading.Tasks;
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

        private async void UseNaiveBayes(object sender, RoutedEventArgs e)
        {
            var text = EmailBox.Text;

            if (text != string.Empty)
            {
                await Task.Run(() => StartBayes(text))
                    .ContinueWith((classification) =>
                    {
                        _classifications.AddClassification(classification.Result);

                        StartLearning(classification.Result);
                    });

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