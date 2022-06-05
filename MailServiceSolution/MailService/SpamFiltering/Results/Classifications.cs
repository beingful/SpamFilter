using System.Collections.Generic;
using System.Linq;

namespace MailService
{
    public class Classifications
    {
        public readonly List<EmailClassification> Emails;

        public Classifications() => Emails = new List<EmailClassification>();

        public int Spam => CountEmails(nameof(Spam));
        public int Correspondence => CountEmails(nameof(Correspondence));

        private int CountEmails(string category)
        {
            return Emails
                .Count(email => email.TextRepresentation.Category == category);
        }

        public void AddClassification(EmailClassification classification)
        {
            Emails.Add(classification);
        }

        public List<EmailClassification> EmailsByCategory(string categoryName)
        {
            return Emails
                .Where(email => email.TextRepresentation.Category == categoryName)
                .ToList();
        }
    }
}
