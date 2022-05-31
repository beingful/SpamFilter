using MailService.DBModels;
using MailService.DBModels.Facades;
using MailService.DBModels.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MailService.SpamFiltering
{
    public class BernoulliModel
    {
        private readonly IEnumerable<string> _words;
        private readonly IEnumerable<string> _vocabulary;

        public BernoulliModel(IEnumerable<string> vectorOfWords, IEnumerable<string> vocabulary)
        {
            _words = vectorOfWords.Distinct();
            _vocabulary = vocabulary;
        }

        private Dictionary<string, byte> GetVectorOfAttributes()
        {
            var vector = new Dictionary<string, byte>(_vocabulary.Count());

            foreach (var word in _vocabulary)
            {
                byte exists = 0;

                if (_words.Contains(word))
                {
                    exists = 1;
                }

                vector.Add(word, exists);
            }

            return vector;
        }

        public IEnumerable<float> GetProbability()
        {
            Dictionary<string, byte> vector = GetVectorOfAttributes();

            var probabilities = new Probabilities<byte, BernoulliOption>(vector, )

            using var facade = new BernoulliFacade();

            foreach (var attribute in attributes)
            {
                Bernoulli bernoulli = facade.GetbyWord(attribute.Key);

                bernoulli
            }
        }

        private double GetProbability(int numerator, int denominator, byte attribute)
            => (double)(1 + numerator) / (2 + denominator);

        private double GetSpamProbability(int spam, int correspondence, byte attribute)
            => GetProbability(spam, spam + )
    }
}
