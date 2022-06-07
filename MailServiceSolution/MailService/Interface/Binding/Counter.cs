using System.ComponentModel;

namespace MailService
{
    public class Counter : INotifyPropertyChanged
    {
        private int _spam;
        private int _correspondence;

        public void ChangeConfiguration(int spamCount, int correspondenceCount)
        {
            Spam = spamCount;
            Correspondence = correspondenceCount;
        }

        public int Spam 
        {
            get => _spam; 
            set
            {
                _spam = value;
                OnPropertyChanged(nameof(Spam));
            }
        }

        public int Correspondence
        {
            get => _correspondence;
            set
            {
                _correspondence = value;
                OnPropertyChanged(nameof(Correspondence));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}