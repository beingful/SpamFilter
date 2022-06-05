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
            _category = category ?? _email.TextRepresentation.Category;
        }

        public void Start()
        {
            int total = _email.TextRepresentation.Vector.Count();
            string oldCategory = _email.TextRepresentation.Category;

            if (oldCategory == _category)
            {
                ILearn bernoulli = GetBernoulli();
                ILearn polynomial = GetPolynomial();

                bernoulli.Calculate(1);
                polynomial.Calculate(total);
            }
            else
            {
                IRelearn bernoulli = GetBernoulli();
                IRelearn polynomial = GetPolynomial();

                bernoulli.Recalculate(1, oldCategory);
                polynomial.Recalculate(total, oldCategory);
            }
        }

        private ModelLearning<BernoulliFacade, BernoulliTotalFacade> GetBernoulli()
        {
            Dictionary<string, ValueType> attributes = _email.Bernoulli.Attributes;

            return new ModelLearning<BernoulliFacade, BernoulliTotalFacade>(attributes, _category);
        }

        private ModelLearning<PolynomialFacade, PolynomialTotalFacade> GetPolynomial()
        {
            Dictionary<string, ValueType> attributes = _email.Polynomial.Attributes;

            return new ModelLearning<PolynomialFacade, PolynomialTotalFacade>(attributes, _category);
        }
    }
}