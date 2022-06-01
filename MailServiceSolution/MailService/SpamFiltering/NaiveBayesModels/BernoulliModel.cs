using System;
using System.Collections.Generic;
using System.Linq;

namespace MailService
{
    public class BernoulliModel : INaiveBayesModel
    {
        private readonly IEnumerable<string> _words;
        private readonly IEnumerable<string> _vocabulary;

        public BernoulliModel(IEnumerable<string> words, IEnumerable<string> vocabulary)
        {
            _words = words.Distinct();
            _vocabulary = vocabulary;
        }

        private Dictionary<string, byte> GetVectorOfAttributes()
        {
            var vector = new Dictionary<string, byte>(_vocabulary.Count());

            foreach (var word in _vocabulary)
            {
                bool doesContain = _words.Contains(word);

                vector.Add(word, Convert.ToByte(doesContain));
            }

            return vector;
        }

        private Model GetModel(string word)
        {
            using var facade = new WordInModelFacade();

            Model model = facade.GetMultinomial(word);

            return model;
        }

        private Fraction GetFraction(string word, IEmailCategory category)
        {
            Model model = GetModel(word);

            return category.Get(model);
        }

        private double CalculateProbability(int numerator, int denominator)
            => (1 + numerator) / (denominator + 2);

        private double GetProbabilityLog(byte attribute, double probability)
            => Math.Log10(attribute * probability + (1 - attribute) * (1 - probability));

        public double Calculate<CategoryType>() 
            where CategoryType : IEmailCategory, new()
        {
            Dictionary<string, byte> vector = GetVectorOfAttributes();

            double total = 0;

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