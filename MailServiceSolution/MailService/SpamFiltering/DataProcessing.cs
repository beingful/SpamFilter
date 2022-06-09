using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MailService
{
    public class DataProcessing
    {
        private readonly string _text;
        private readonly static char[] _separators;
        private readonly static string[] _stopWords;
        private readonly static IEnumerable<KeyValuePair<string, string>> _endings;

        static DataProcessing()
        {
            _stopWords = new string[]
            {
                "a", "the", "am", "is", "are", "i", "he", "she", "it", "you",
                "they", "them", "this", "that", "those", "will", "be",
                "do", "does", "have", "has", "would", "may", "to", "and",
                "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", string.Empty
            };

            _separators = new char[] { ' ', ',', '-', '.', '!',
                '?', '/', '\"', '\t', '\n', '\r' };

            _endings = new Dictionary<string, string>
            {
                { "ies", "y" },
                { "n't", string.Empty },
                { "'ll", string.Empty },
                { "'d", string.Empty },
                { "'s", string.Empty },
                { "'ve", string.Empty },
                { "ing", string.Empty },
                { "s", string.Empty },

            };
        }

        public DataProcessing(string text) => _text = text;

        private List<string> Tokenization() => _text.Split(_separators).ToList();

        private string Stemming(string word) 
        {
            string normalizedWord = word;

            foreach (var ending in _endings)
            {
                var template = new Regex($".+{ending.Key}$");

                if (template.IsMatch(word))
                {
                    normalizedWord = word.Replace(ending.Key, ending.Value);

                    break;
                } 
            }

            return normalizedWord;
        }

        public IEnumerable<string> Start()
        {
            List<string> textVector = Tokenization();

            for (int i = 0; i < textVector.Count; i++)
            {
                textVector[i] = textVector[i].ToLower();

                if (_stopWords.Contains(textVector[i]))
                {
                    textVector.RemoveAt(i);

                    i--;
                }
                else
                {
                    textVector[i] = Stemming(textVector[i]);
                }
            }

            return textVector;
        }
    }
}