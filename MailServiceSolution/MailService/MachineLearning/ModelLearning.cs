using System;
using System.Collections.Generic;

namespace MailService
{
    public class ModelLearning<ModelFacadeType, TotalFacadeType> : ILearn, IRelearn
        where ModelFacadeType : class, INumeratorManager, new()
        where TotalFacadeType : class, IDenominatorManager, new()
    {
        private readonly Dictionary<string, ValueType> _attributes;

        public ModelLearning(Dictionary<string, ValueType> attributes) => _attributes = attributes;

        void ILearn.Calculate(string category, int count)
        {
            PlusToDenominator(category, count);

            foreach (var attribute in _attributes)
            {
                var value = Convert.ToInt32(attribute.Value);

                if (value != 0)
                {
                    PlusToNumerator(attribute.Key, category, value);
                }
            }
        }

        void IRelearn.Recalculate(string oldCategory, string newCategory, int count)
        {
            MinusFromDenominator(oldCategory, count);
            PlusToDenominator(newCategory, count);

            foreach (var attribute in _attributes)
            {
                var value = Convert.ToInt32(attribute.Value);

                if (value != 0)
                {
                    MinusFromNumerator(attribute.Key, oldCategory, value);
                    PlusToNumerator(attribute.Key, newCategory, value);
                }
            }
        }

        private void PlusToDenominator(string category, int count)
        {
            using var facade = new TotalFacadeType();

            facade.Plus(category, count);
        }

        private void MinusFromDenominator(string category, int count)
        {
            using var facade = new TotalFacadeType();

            facade.Minus(category, count);
        }

        private void PlusToNumerator(string word, string category, int count)
        {
            using var facade = new ModelFacadeType();

            facade.PlusToNumerator(word, category, count);
        }

        private void MinusFromNumerator(string word, string category, int count)
        {
            using var facade = new ModelFacadeType();

            facade.MinusFromNumerator(word, category, count);
        }
    }
}