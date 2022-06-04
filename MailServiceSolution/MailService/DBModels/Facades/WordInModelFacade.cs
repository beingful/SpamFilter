using System;
using System.Linq;

namespace MailService
{
    public class WordInModelFacade : IDisposable
    {
        private readonly Repository _repository = new Repository();

        private WordInModel GetbyWord(string word)
        {
            return _repository
                .GetAll(new WordInModelOption())
                .FirstOrDefault(model => model.IdNavigation.Word == word);
        }

        public Model GetBernoulli(string word)
        {
            WordInModel wordInModel = GetbyWord(word);

            return wordInModel?.MultinomialNavigation;
        }

        public Model GetPolynomial(string word)
        {
            WordInModel wordInModel = GetbyWord(word);

            return wordInModel?.PolynomialNavigation;
        }

        public void Create(Guid word, Guid bernoulli, Guid polynomial)
        {
            var wordInModel = new WordInModel
            {
                Id = word,
                Multinomial = bernoulli,
                Polynomial = polynomial,
            };

            _repository.Insert(wordInModel);
        }

        public void Dispose() => _repository.Dispose();
    }
}