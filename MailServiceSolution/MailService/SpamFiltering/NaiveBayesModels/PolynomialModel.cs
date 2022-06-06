using System;
using System.Collections.Generic;
using System.Linq;

namespace MailService
{
    internal class PolynomialModel : INaiveBayesModel
    {
        private readonly InputData _data;

        public PolynomialModel(InputData data) => _data = data;

        public Dictionary<string, ValueType> Attributes => GetVectorOfAttributes();

        private Dictionary<string, ValueType> GetVectorOfAttributes()
        {
            var vector = new Dictionary<string, ValueType>(_data.Vocabulary.Count());

            foreach (var word in _data.Vocabulary)
            {
                int repeats = _data.Words.Count(element => element == word);

                vector.Add(word, repeats);
            }

            return vector;
        }

        private (int Numerator, int Denominator) GetFraction(string word, IEmailCategory category)
        {
            using var facade = new PolynomialFacade();

            return category.Get(facade, word);
        }

        private double CalculateProbability(int numerator, int denominator)
        {
            return (1 + numerator) / (denominator + _data.Vocabulary.Count());
        }

        private double GetProbabilityLog(int attribute, double probability)
        {
            return attribute * Math.Log10(probability) - FactorialLog(attribute);
        }

        private static double FactorialLog(double factor)
        {
            double total = 0;

            for (int i = 1; i <= factor; i++)
            {
                total += Math.Log10(i);
            }

            return total;
        }

        public Result Calculate<CategoryType>()
            where CategoryType : IEmailCategory, new()
        {
            double total = FactorialLog(_data.Words.Count());

            foreach (var element in Attributes)
            {
                (int Numerator, int Denominator) fraction = GetFraction(element.Key, new CategoryType());

                double probability = CalculateProbability(fraction.Numerator, fraction.Denominator);

                total += GetProbabilityLog((int)element.Value, probability);
            }

            return new Result(total, typeof(CategoryType).Name);
        }
    }
}