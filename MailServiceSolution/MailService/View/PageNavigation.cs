using MailService.Pages;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace MailService
{
    public class PageNavigation
    {
        private readonly string _buttonName;
        private readonly List<EmailClassification> _emails;
        private readonly Dictionary<string, Page> _navigator;

        public PageNavigation(string buttonName, List<EmailClassification> emails)
        {
            _buttonName = buttonName;
            _emails = emails;

            _navigator = new Dictionary<string, Page>
            {
                { nameof(NewEmail), new NewEmail(emails) },
                { nameof(Spam), new Pages.Category(EmailsOfCategory(nameof(Spam))) },
                { nameof(Correspondence), new Pages.Category(EmailsOfCategory(nameof(Correspondence))) }
            };
        }

        public List<EmailClassification> EmailsOfCategory(string categoryName)
        {
            return _emails
                .Where(email => email.Category == categoryName)
                .ToList();
        }

        public Page GetPage() => _navigator[_buttonName];
    }
}