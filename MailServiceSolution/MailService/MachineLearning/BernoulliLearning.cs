using System;

namespace MailService
{
    public class BernoulliLearning
    {
        private readonly EmailClassification _email;
        private readonly string _category;

        public BernoulliLearning(EmailClassification email, string category = null) 
        {
            _email = email;
            _category = category ?? _email.Category;
        }

        public void Learn(string word)
        {
            using var facade = new WordInModelFacade();

            Model model = facade.GetBernoulli(word);

            if (model is null)
            {

            }
        }

        private void CreateNewWord(string word)
        {
            var vocabulary = new Vocabulary
            {
                Id = Guid.NewGuid(),
                Word = word
            };
        }

        private void CreateModel()
        {
            var model = new Model
            {
                Id = Guid.NewGuid(),
                Spam = CreateFraction()
            }
        }

        private void CreateFraction()
        {
            var fraction = new Fraction
            {
                Id = Guid.NewGuid(),
                Numerator = 1,
                Denominator = GetEmailsQuantity()
            };


        }

        private int GetEmailsQuantity()
        {
            using var facade = new CategoryFacade();

            facade.AddOne(_category);

            return facade.GetEmailQuantity(_category);
        }
    }
}