using Microsoft.EntityFrameworkCore;

namespace MailService
{
    public interface IModelOption<ModelType> where ModelType : class
    {
        public DbSet<ModelType> GetAll(NaiveBayesClassifierContext _context);
    }
}