using System;

namespace MailService
{
    public class PolynomialTotalFacade : IDisposable, IDenominatorManager
    {
        private static readonly PolynomialTotalOption _option;
        private readonly ModelTotalFacade<PolynomialTotal> _facade;

        static PolynomialTotalFacade() => _option = new PolynomialTotalOption();

        public PolynomialTotalFacade() => _facade = new ModelTotalFacade<PolynomialTotal>(_option);

        public void Plus(string category, int count) => _facade.Plus(category, count);

        public void Minus(string category, int count) => _facade.Minus(category, count);

        public void Dispose() => _facade.Dispose();
    }
}
