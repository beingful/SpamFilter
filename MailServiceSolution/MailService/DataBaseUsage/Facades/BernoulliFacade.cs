using System;

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
            return _facade.GetFraction(word, category,
                model => ((Bernoulli)model).DenominatorNavigation);
        }

        public void Dispose() => _facade.Dispose();
    }
}