using System.Collections.Generic;
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
                { nameof(Pages.NewEmail), new Pages.NewEmail(emails) },
                { nameof(Spam), new Pages.Category(emails) },
                { nameof(Correspondence), new Pages.Category(emails) }
            };
        }

        public Page GetPage() => _navigator[_buttonName];
    }
}