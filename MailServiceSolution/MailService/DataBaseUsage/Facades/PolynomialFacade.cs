using System;

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
            return _facade.GetFraction(word, category,
                model => ((Polynomial)model).DenominatorNavigation);
        }

        public void Dispose() => _facade.Dispose();
    }
}