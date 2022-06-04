using System;

namespace MailService
{
    public class DataBaseInstance<ModelType> where ModelType : class
    {
        private readonly string _word;
        private readonly string _category;
        private readonly int _numerator;
        private readonly int _denominator;

        public DataBaseInstance(string word, string category, int numerator, int deniminator)
        {
            _word = word;
            _category = category;
            _numerator = numerator;
            _denominator = deniminator;
        }

        public void Create()
        {
            Guid vocabulary = CreateVocbulary();

            Guid categoryFraction = CreateFraction(_denominator, _numerator);
            Guid otherFraction = CreateFraction(_denominator);
            Guid defaultFraction = CreateDefaultFraction();

            Guid model;

            if (_category == nameof(Spam))
            {
                model = CreateModel(categoryFraction, otherFraction);
            }
            else
            {
                model = CreateModel(otherFraction, categoryFraction);
            }

            Guid otherModel = CreateModel(defaultFraction, defaultFraction);

            if (typeof(ModelType).Name == nameof(BernoulliLearning))
            {
                CreateWordInModel(vocabulary, model, otherModel);
            }
            else
            {
                CreateWordInModel(vocabulary, otherModel, model);
            }
        }

        private Guid CreateFraction(int denominator, int numerator = 0)
        {
            using var facade = new FractionFacade();

            return facade.Create(numerator, denominator);
        }

        private Guid CreateDefaultFraction() => CreateFraction(0);

        private Guid CreateModel(Guid fraction, Guid otherFraction)
        {
            Guid model;

            using var facade = new ModelFacade();

            model = facade.Create(otherFraction, fraction);

            return model;
        }

        private Guid CreateVocbulary()
        {
            using var facade = new VocabularyFacade();

            return facade.Create(_word);
        }

        private void CreateWordInModel(Guid word, Guid model, Guid otherModel)
        {
            using var facade = new WordInModelFacade();

            facade.Create(word, model, otherModel);
        }
    }
}