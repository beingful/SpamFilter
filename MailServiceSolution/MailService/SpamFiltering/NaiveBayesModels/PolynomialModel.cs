using System;
using System.Collections.Generic;
using System.Linq;

namespace MailService
{
    internal class PolynomialModel : INaiveBayesModel

    {
        private readonly IEnumerable<string> _words;
        private readonly IEnumerable<string> _vocabulary;

        public PolynomialModel(IEnumerable<string> words, IEnumerable<string> vocabulary)
        {
            _words = words;
            _vocabulary = vocabulary;
        }

        private Dictionary<string, int> GetVectorOfAttributes()
        {
            var vector = new Dictionary<string, int>(_vocabulary.Count());

            foreach (var word in _vocabulary)
            {
                int repeats = _words.Count(element => element == word);

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
            => (1 + numerator) / (denominator + _vocabulary.Count());

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

        public double Calculate<CategoryType>() 
            where CategoryType : IEmailCategory, new()
        {
            Dictionary<string, int> vector = GetVectorOfAttributes();

            double total = FactorialLog(_words.Count());

            foreach (var element in vector)
            {
                Fraction fraction = GetFraction(element.Key, new CategoryType());

                double probability = CalculateProbability(fraction.Numerator, fraction.Denominator);

                total += GetProbabilityLog(element.Value, probability);
            }

            return total;
        }
    }
}