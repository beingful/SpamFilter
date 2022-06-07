using System.ComponentModel;

namespace MailService
{
    public class EmailClassification : INotifyPropertyChanged
    {
        public readonly string Text;
        public readonly ModelResult Bernoulli;
        public readonly ModelResult Polynomial;

        public EmailClassification(string text, string category,
            ModelResult bernoulli, ModelResult polynomial)
        {
            Text = text;
            Bernoulli = bernoulli;
            Polynomial = polynomial;
            Category = category;
        }

        public string Category { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ChangeCategory(string category)
        {
            Category = category;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Category)));
        }
    }
}