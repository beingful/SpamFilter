using System;
using System.Collections.Generic;

namespace MailService
{
    public class ModelLearning<ModelFacadeType, TotalFacadeType> : ILearn, IRelearn
        where ModelFacadeType : class, INumeratorManager, new()
        where TotalFacadeType : class, IDenominatorManager, new()
    {
        private readonly Dictionary<string, ValueType> _attributes;
        private readonly string _category;

        public ModelLearning(Dictionary<string, ValueType> attributes, string category)
        {
            _attributes = attributes;
            _category = category;
        }

        void ILearn.Calculate(int count)
        {
            PlusToDenominator(count);

            foreach (var attribute in _attributes)
            {
                var value = (int)attribute.Value;

                if (value != 0)
                {
                    PlusToNumerator(attribute.Key, value);
                }
            }
        }

        void IRelearn.Recalculate(int count, string oldCategory)
        {
            MinusFromDenominator(count);

            foreach (var attribute in _attributes)
            {
                var value = (int)attribute.Value;

                if (value != 0)
                {
                    MinusFromNumerator(attribute.Key, value, oldCategory);
                    PlusToNumerator(attribute.Key, value);
                }
            }
        }

        private void PlusToDenominator(int count)
        {
            using var facade = new TotalFacadeType();

            facade.Plus(_category, count);
        }

        private void MinusFromDenominator(int count)
        {
            using var facade = new TotalFacadeType();

            facade.Minus(_category, count);
        }

        private void PlusToNumerator(string word, int count)
        {
            using var facade = new ModelFacadeType();

            facade.PlusToNumerator(word, _category, count);
        }

        private void MinusFromNumerator(string word, int count, string oldCategory)
        {
            using var facade = new ModelFacadeType();

            facade.MinusFromNumerator(word, oldCategory, count);
        }
    }
}