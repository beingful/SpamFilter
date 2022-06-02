using System.Collections.Generic;
using System.Windows.Controls;

namespace MailService.Pages
{
    public partial class Category : Page
    {
        private readonly IEnumerable<EmailClassification> _emails;

        public Category(IEnumerable<EmailClassification> emails)
        {
            _emails = emails;

            InitializeComponent();
        }
    }
}