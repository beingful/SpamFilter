using System;

namespace MailService
{
    public class BernoulliTotalFacade : IDisposable, IDenominatorManager
    {
        private static readonly BernoulliTotalOption _option;
        private readonly ModelTotalFacade<BernoulliTotal> _facade;

        static BernoulliTotalFacade() => _option = new BernoulliTotalOption();

        public BernoulliTotalFacade() => _facade = new ModelTotalFacade<BernoulliTotal>(_option);

        public void Plus(string category, int count) => _facade.Plus(category, count);

        public void Minus(string category, int count) => _facade.Minus(category, count);

        public void Dispose() => _facade.Dispose();
    }
}