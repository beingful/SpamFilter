using MailService.DBModels.Interfaces;
using System.Collections.Generic;

namespace MailService.DBModels.Repositories
{
    public class WordInModelOption : IModelOption<WordInModel>
    {
        public IEnumerable<WordInModel> GetAll(NaiveBayesContext _context) => _context.WordInModels;
    }
}