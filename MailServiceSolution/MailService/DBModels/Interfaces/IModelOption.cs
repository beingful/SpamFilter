using System.Collections.Generic;

namespace MailService.DBModels.Interfaces
{
    public interface IModelOption<ModelType> where ModelType : class
    {
        public IEnumerable<ModelType> GetAll(NaiveBayesContext _context);
    }
}
