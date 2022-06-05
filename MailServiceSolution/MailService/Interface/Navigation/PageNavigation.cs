using MailService.Pages;
using System.Collections.Generic;
using System.Windows.Controls;

namespace MailService
{
    public class PageNavigation
    {
        private readonly string _buttonName;
        private readonly Classifications _classifications;
        private readonly Dictionary<string, Page> _navigator;

        public PageNavigation(string buttonName, Classifications classifications)
        {
            _buttonName = buttonName;
            _classifications = classifications;

            _navigator = new Dictionary<string, Page>
            {
                { nameof(NewEmail), new NewEmail(classifications) },
                { nameof(Spam), new Pages.Category(EmailsOfCategory(nameof(Spam))) },
                { nameof(Correspondence), new Pages.Category(EmailsOfCategory(nameof(Correspondence))) }
            };
        }

        public List<EmailClassification> EmailsOfCategory(string categoryName)
        {
            return _classifications.EmailsByCategory(categoryName);
        }

        public Page GetPage() => _navigator[_buttonName];
    }
}