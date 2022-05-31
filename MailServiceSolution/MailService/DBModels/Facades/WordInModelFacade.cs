using MailService.DBModels.Repositories;
using System;
using System.Linq;

namespace MailService.DBModels.Facades
{
    public class WordInModelFacade : IDisposable
    {
        private readonly Repository _repository = new Repository();

        private WordInModel GetbyWord(string word)
        {
            return _repository
                .GetAll(new WordInModelOption())
                .First(model => model.IdNavigation.Word == word);
        }

        public Model GetMultinomial(string word)
        {
            WordInModel wordInModel = GetbyWord(word);

            return wordInModel.MultinomialNavigation;
        }

        public Model GetPolynomial(string word)
        {
            WordInModel wordInModel = GetbyWord(word);

            return wordInModel.PolynomialNavigation;
        }

        public void Dispose() => _repository.Dispose();
    }
}