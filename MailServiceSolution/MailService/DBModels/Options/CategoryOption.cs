using System.Collections.Generic;

namespace MailService
{
    public class CategoryOption : IModelOption<Category>
    {
        public IEnumerable<Category> GetAll(NaiveBayesContext _context) => _context.Categories;
    }
}
