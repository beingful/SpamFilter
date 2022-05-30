using System.Collections.Generic;
using System.Linq;

namespace MailService.SpamFiltering
{
    public class BernoulliModel
    {
        private readonly IEnumerable<string> _vectorOfWords;
        private readonly IEnumerable<string> _vocabulary;

        public BernoulliModel(IEnumerable<string> vectorOfWords, IEnumerable<string> vocabulary) 
        {
            _vectorOfWords = vectorOfWords.Distinct();
            _vocabulary = vocabulary;
        }

        private IEnumerable<byte> GetVectorOfAttributes()
        {
            var vectorOfAttributes = new List<byte>(_vocabulary.Count());

            foreach (var word in _vocabulary)
            {
                byte exists = 0;

                if (_vectorOfWords.Contains(word))
                {
                    exists = 1;
                }

                vectorOfAttributes.Add(exists);
            }

            return vectorOfAttributes;
        }

        public IEnumerable<float> GetProperties()
        {
            IEnumerable<byte> vectorOfAttributes = GetVectorOfAttributes();


        }
    }
}
