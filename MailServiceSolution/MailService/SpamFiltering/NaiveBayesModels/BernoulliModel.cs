using System;
using System.Collections.Generic;
using System.Linq;

namespace MailService
{
    public class BernoulliModel : INaiveBayesModel
    {
        private readonly InputData _data;

        public BernoulliModel(InputData data) => _data = data;

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

        private Model GetModel(string word)
        {
            using var facade = new WordInModelFacade();

            Model model = facade.GetBernoulli(word);

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

        public ModelResult<IEmailCategory> Calculate<CategoryType>() 
            where CategoryType : IEmailCategory, new()
        {
            Dictionary<string, ValueType> vector = GetVectorOfAttributes();

            double total = 0;

            foreach (var element in vector)
            {
                Fraction fraction = GetFraction(element.Key, new CategoryType());

                double probability = CalculateProbability(fraction.Numerator, fraction.Denominator);

                total += GetProbabilityLog((byte)element.Value, probability);
            }

            return new ModelResult<IEmailCategory>(vector, total);
        }
    }
}