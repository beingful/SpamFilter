using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace MailService
{
    public class BernoulliFacade : IDisposable, IFractionObserver, INumeratorManager
    {
        private static readonly BernoulliOption _option;
        private readonly NaiveBayesModelFacade<Bernoulli> _facade;

        static BernoulliFacade() => _option = new BernoulliOption();

        public BernoulliFacade() => _facade = new NaiveBayesModelFacade<Bernoulli>(_option);

        public Guid GetId(string word, string category) => _facade.GetId(word, category);

        public void PlusToNumerator(string word, string category, int count)
        {
            _facade.PlusToNumerator(word, category, count);
        }

        public void MinusFromNumerator(string word, string category, int count)
        {
            _facade.PlusToNumerator(word, category, count);
        }

        public (int Numerator, int Denominator) GetFraction(string word, string category)
        {
            IQueryable<Bernoulli> models = _facade.Get();

            Bernoulli model = models
                .Include(model => model.Total)
                .First(model => model.Vocabulary.Word == word && model.Category.Name == category);

            return (model.Numerator, model.Total.Count);
        }

        public void Dispose() => _facade.Dispose();
    }
}