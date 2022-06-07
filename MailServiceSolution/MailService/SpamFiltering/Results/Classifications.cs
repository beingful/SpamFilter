using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace MailService
{
    public class Classifications
    {
        public readonly ClassificationCollection<EmailClassification> Emails;

        public Classifications() 
        {
            Counter = new Counter();

            Emails = new ClassificationCollection<EmailClassification>();
            Emails.CollectionChanged += AddedNewEmail;
            Emails.ItemPropertyChanged += ItemPropertyChanged;
        }

        public Counter Counter { get; private set; }

        private void AddedNewEmail(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                Recalculate();
            }
        }

        private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Recalculate();
        }

        private void Recalculate()
        {
            int spam = CountEmails(nameof(Counter.Spam));
            int correspondence = CountEmails(nameof(Counter.Correspondence));

            Counter.ChangeConfiguration(spam, correspondence);
        }

        private int CountEmails(string category) => EmailsByCategory(category).Count();

        public void AddClassification(EmailClassification classification)
        {
            Emails.Add(classification);
        }

        public List<EmailClassification> EmailsByCategory(string categoryName)
        {
            return Emails
                .Where(email => email.Category == categoryName)
                .ToList();
        }
    }
}