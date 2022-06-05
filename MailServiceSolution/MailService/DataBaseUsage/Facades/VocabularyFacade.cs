using System;
using System.Collections.Generic;
using System.Linq;

namespace MailService
{
    public class VocabularyFacade : IDisposable
    {
        private readonly Repository _repository = new Repository();

        private IEnumerable<Vocabulary> GetAll() => _repository.GetAll(new VocabularyOption());

        public Guid GetId(string word)
        {
            return GetAll()
                .First(element => element.Word == word)
                .Id;
        }

        public IEnumerable<string> GetAllTheWords()
        {
            return GetAll()
                .Select(element => element.Word)
                .ToList();
        }

        public bool DoesSuchAWordExist(string word)
        {
            return GetAll()
                .Any(vocabulary => vocabulary.Word == word);
        }

        public void Create(string word)
        {
            var vocabulary = new Vocabulary
            {
                Id = Guid.NewGuid(),
                Word = word
            };

            _repository.Insert(vocabulary);
        }

        public void Dispose() => _repository.Dispose();
    }
}