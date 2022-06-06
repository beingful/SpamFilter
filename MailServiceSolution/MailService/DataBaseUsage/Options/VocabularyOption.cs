using Microsoft.EntityFrameworkCore;

namespace MailService
{
    public class VocabularyOption : IModelOption<Vocabulary>
    {
        public DbSet<Vocabulary> GetAll(NaiveBayesClassifierContext _context)
        {
            return _context.Vocabularies;
        }
    }
}