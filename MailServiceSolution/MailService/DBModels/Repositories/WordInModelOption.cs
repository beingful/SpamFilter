using System.Collections.Generic;

namespace MailService
{
    public class WordInModelOption : IModelOption<WordInModel>
    {
        public IEnumerable<WordInModel> GetAll(NaiveBayesContext _context) => _context.WordInModels;
    }
}