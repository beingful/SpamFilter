using System.Collections.Generic;

namespace MailService
{
    public class VocabularyOption : IModelOption<Vocabulary>
    {
        public IEnumerable<Vocabulary> GetAll(NaiveBayesClassifierContext _context)
        {
            return _context.Vocabularies;
        }
    }
}