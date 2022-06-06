using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MailService
{
    public class DataProcessing
    { 
        private readonly static string[] _stopWords;
        private readonly static char[] _separators;
        private readonly static Dictionary<string, string> _endings;
        private readonly string _text;

        static DataProcessing()
        {
            _stopWords = new string[]
            {
                "a", "the", "am", "is", "are", "i", "he", "she", "it", "you",
                "they", "them", "this", "that", "those", "will", "be",
                "do", "does", "have", "has", "would", "may", "to",
                "1", "2", "3", "4", "5", "6", "7", "8", "9", "0"
            };

            _separators = new char[] { ' ', ',', '-', '.', '!',
                '?', '/', '\"', '\t', '\n', '\r' };

            _endings = new Dictionary<string, string>
            {
                { "s", string.Empty },
                { "ies", "y" },
                { "n't", string.Empty },
                { "ing", string.Empty }
            };
        }

        public DataProcessing(string text) => _text = AllToLower(text);

        private string AllToLower(string text) => text.ToLower();

        private string[] Tokenization() 
        { 
            return _text
                .Split(_separators)
                .Where(word => word != String.Empty)
                .ToArray();
        }

        private void StopWordsRemoval(ref string[] textVector)
        {
            textVector = textVector
                .Where(element => !_stopWords.Contains(element))
                .ToArray();
        }

        private void Stemming(string[] textVector)
        {
            for (int i = 0; i < textVector.Length; i++)
            {
                ChangeEnding(ref textVector[i]);
                AllAfterApostropheRemoval(ref textVector[i]);
            }
        }

        private void ChangeEnding(ref string word) 
        {
            var elseChars = ".+";
            var signOfEnd = "$";

            foreach (var ending in _endings.OrderByDescending(end => end.Key.Length))
            {
                var template = new Regex(elseChars + ending.Key + signOfEnd);
                var endingForRemove = new Regex(ending.Key + signOfEnd);

                if (template.IsMatch(word))
                {
                    word = endingForRemove.Replace(word, ending.Value);
                } 
            }
        }

        private void AllAfterApostropheRemoval(ref string word)
        {
            string apostrophe = "\'";

            if (word.Contains(apostrophe) && word.IndexOf(apostrophe) is int index 
                && index == word.LastIndexOf(apostrophe))
            {
                word = word.Remove(index);
            }
            else
            {
                word = word.Replace(apostrophe, string.Empty);
            }
        }

        public IEnumerable<string> Start()
        {
            string[] textVector = Tokenization();

            Stemming(textVector);
            StopWordsRemoval(ref textVector);

            Array.Sort(textVector);

            return textVector;
        }
    }
}