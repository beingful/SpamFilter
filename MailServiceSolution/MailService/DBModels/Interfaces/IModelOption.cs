using System.Collections.Generic;

namespace MailService
{
    public interface IModelOption<ModelType> where ModelType : class
    {
        public IEnumerable<ModelType> GetAll(NaiveBayesContext _context);
    }
}
