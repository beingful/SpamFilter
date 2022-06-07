using System;
using System.Collections.Generic;
using System.Linq;

namespace MailService
{
    public class Learning
    {
        private readonly EmailClassification _email;
        private readonly string _category;

        public Learning(EmailClassification email, string category = null)
        {
            _email = email;
            _category = category ?? _email.Category;
        }

        public void Start()
        {
            int total = GetPolynomialTotal();

            string oldCategory = _email.Category;

            if (oldCategory == _category)
            {
                ILearn bernoulli = GetBernoulli();
                ILearn polynomial = GetPolynomial();

                bernoulli.Calculate(_category, 1);
                polynomial.Calculate(_category, total);
            }
            else
            {
                IRelearn bernoulli = GetBernoulli();
                IRelearn polynomial = GetPolynomial();

                bernoulli.Recalculate(oldCategory, _category, 1);
                polynomial.Recalculate(oldCategory, _category, total);

                _email.ChangeCategory(_category);
            }
        }

        private int GetPolynomialTotal()
        {
            return _email
                .Polynomial
                .Attributes
                .Sum(attribute => Convert.ToInt32(attribute.Value));
        }

        private ModelLearning<BernoulliFacade, BernoulliTotalFacade> GetBernoulli()
        {
            Dictionary<string, ValueType> attributes = _email.Bernoulli.Attributes;

            return new ModelLearning<BernoulliFacade, BernoulliTotalFacade>(attributes);
        }

        private ModelLearning<PolynomialFacade, PolynomialTotalFacade> GetPolynomial()
        {
            Dictionary<string, ValueType> attributes = _email.Polynomial.Attributes;

            return new ModelLearning<PolynomialFacade, PolynomialTotalFacade>(attributes);
        }
    }
}