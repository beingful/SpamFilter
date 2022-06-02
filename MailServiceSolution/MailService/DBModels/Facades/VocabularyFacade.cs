using System;
using System.Collections.Generic;
using System.Linq;

namespace MailService
{
    public class VocabularyFacade : IDisposable
    {
        private readonly Repository _repository = new Repository();

        public IEnumerable<string> GetAllTheWords()
        {
            return _repository
                .GetAll(new VocabularyOption())
                .Select(element => element.Word)
                .ToList();
        }

        public void Dispose() => _repository.Dispose();
    }
}