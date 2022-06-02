using System.Collections.Generic;

namespace MailService
{
    public class InputData
    {
        public readonly IEnumerable<string> Words;
        public readonly IEnumerable<string> Vocabulary;

        public InputData(IEnumerable<string> words, IEnumerable<string> vocabulary)
        {
            Words = words;
            Vocabulary = vocabulary;
        }
    }
}