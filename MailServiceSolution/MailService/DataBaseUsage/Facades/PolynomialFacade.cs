using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace MailService
{
    public class PolynomialFacade : IDisposable, IFractionObserver, INumeratorManager
    {
        private static readonly PolynomialOption _option;
        private readonly NaiveBayesModelFacade<Polynomial> _facade;

        static PolynomialFacade() => _option = new PolynomialOption();

        public PolynomialFacade() => _facade = new NaiveBayesModelFacade<Polynomial>(_option);

        public Guid GetId(string word, string category) => _facade.GetId(word, category);

        public void PlusToNumerator(string word, string category, int number)
        {
            _facade.PlusToNumerator(word, category, number);
        }

        public void MinusFromNumerator(string word, string category, int number)
        {
            _facade.PlusToNumerator(word, category, number);
        }

        public (int Numerator, int Denominator) GetFraction(string word, string category)
        {
            IQueryable<Polynomial> models = _facade.Get();

            Polynomial model = models
                .Include(model => model.Total)
                .First(model => model.Vocabulary.Word == word && model.Category.Name == category);

            return (model.Numerator, model.Total.Count);
        }

        public void Dispose() => _facade.Dispose();
    }
}