using System;
using System.Collections.Generic;
using System.Linq;

namespace MailService
{
    public class BernoulliModel : INaiveBayesModel
    {
        private readonly InputData _data;

        public BernoulliModel(InputData data) => _data = data;

        public Dictionary<string, ValueType> Attributes => GetVectorOfAttributes();

        private Dictionary<string, ValueType> GetVectorOfAttributes()
        {
            var vector = new Dictionary<string, ValueType>(_data.Vocabulary.Count());

            foreach (var word in _data.Vocabulary)
            {
                bool doesContain = _data.Words.Contains(word);

                vector.Add(word, Convert.ToByte(doesContain));
            }

            return vector;
        }

        private (int Numerator, int Denominator) GetFraction(string word, IEmailCategory category)
        {
            using var facade = new BernoulliFacade();

            return category.Get(facade, word);
        }

        private double CalculateProbability(int numerator, int denominator)
        {
            return (1 + numerator) / (denominator + 2);
        }

        private double GetProbabilityLog(byte attribute, double probability)
        {
            var wordProbability = attribute * probability + (1 - attribute) * (1 - probability);

            return Math.Log10(wordProbability);
        }

        public Result<IEmailCategory> Calculate<CategoryType>()
            where CategoryType : IEmailCategory, new()
        {
            double total = 0;

            foreach (var element in Attributes)
            {
                (int Numerator, int Denominator) fraction = GetFraction(element.Key, new CategoryType());

                double probability = CalculateProbability(fraction.Numerator, fraction.Denominator);

                total += GetProbabilityLog((byte)element.Value, probability);
            }

            return new Result<IEmailCategory>(total);
        }
    }
}