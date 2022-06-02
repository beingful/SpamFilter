using System;
using System.Collections.Generic;
using System.Linq;

namespace MailService
{
    internal class PolynomialModel : INaiveBayesModel
    {
        private readonly InputData _data;

        public PolynomialModel(InputData data) => _data = data;

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

        private Model GetModel(string word)
        {
            using var facade = new WordInModelFacade();

            Model model = facade.GetPolynomial(word);

            return model;
        }

        private Fraction GetFraction(string word, IEmailCategory category)
        {
            Model model = GetModel(word);

            return category.Get(model);
        }

        private double CalculateProbability(int numerator, int denominator)
            => (1 + numerator) / (denominator + _data.Vocabulary.Count());

        private double GetProbabilityLog(int attribute, double probability)
            => - FactorialLog(attribute) + attribute * Math.Log10(probability);

        private static double FactorialLog(double factor)
        {
            double total = 0;

            for (int i = 1; i <= factor; i++)
            {
                total += Math.Log10(i);
            }

            return total;
        }

        public ModelResult<IEmailCategory> Calculate<CategoryType>() 
            where CategoryType : IEmailCategory, new()
        {
            Dictionary<string, ValueType> vector = GetVectorOfAttributes();

            double total = FactorialLog(_data.Words.Count());

            foreach (var element in vector)
            {
                Fraction fraction = GetFraction(element.Key, new CategoryType());

                double probability = CalculateProbability(fraction.Numerator, fraction.Denominator);

                total += GetProbabilityLog((int)element.Value, probability);
            }

            return new ModelResult<IEmailCategory>(vector, total);
        }
    }
}