using System.Collections.Generic;

namespace MailService.SpamFiltering
{
    public class BagsOfWords
    {
        private readonly IEnumerable<string> _vocabular;
        private readonly IEnumerable<string> _allWords;

        public BagsOfWords()
        {

        }
        public string[] Vocabular { get; }
        public string[] AllWords { get; }
        public string[] NewWords { get; }

        public void 
    }
}
