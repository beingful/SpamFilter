using System.Collections.Generic;

namespace MailService
{
    public class VocabularyOption : IModelOption<Vocabulary>
    {
        public IEnumerable<Vocabulary> GetAll(NaiveBayesContext _context) => _context.Vocabularies;
    }
}