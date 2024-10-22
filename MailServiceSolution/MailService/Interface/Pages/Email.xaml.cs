﻿using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MailService.Pages
{
    public partial class Email : Page
    {
        private readonly EmailClassification _email;

        public Email(EmailClassification email)
        {
            _email = email;

            InitializeComponent();
        }

        private void WindowIsLoaded(object sender, RoutedEventArgs e)
        {
            SetText();
            SetInfo();
            SetCategoryToChangeButton();
        }

        private void SetInfo()
        {
            BernoulliSpam.Text = GetInfo(_email.Bernoulli, nameof(Spam));
            BernoulliCorrespondence.Text = GetInfo(_email.Bernoulli, nameof(Correspondence));
            PolynomialSpam.Text = GetInfo(_email.Polynomial, nameof(Spam));
            PolynomialCorrespondence.Text = GetInfo(_email.Polynomial, nameof(Correspondence));
        }

        private string GetInfo(ModelResult modelResult, string category)
        {
            return modelResult
                .Results
                .First(result => result.Category == category)
                .Probability
                .ToString();
        }

        private void SetText() => EmailBox.Text = _email.Text;

        private void SetCategoryToChangeButton()
        {
            var buttons = new CategoryButtons(_email.Category);

            CategoryButtonView buttonView = buttons.GetCategoryButtonView();

            string template = CategoryToChange.Content.ToString();

            CategoryToChange.Content = string.Format(template, buttonView.Content);
            CategoryToChange.Background = buttonView.Background;
        }

        private void RelearnByClick(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var category = button.GetCategory();

            Task.Run(() => StartLearning(category));

            Task.Delay(100);

            _email.ChangeCategory(category);

            button.IsEnabled = false;
        }

        private void StartLearning(string category)
        {
            var learning = new Learning(_email, category);

            learning.Start();
        }
    }
}