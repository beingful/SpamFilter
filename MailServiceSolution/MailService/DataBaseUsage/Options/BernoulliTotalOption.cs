using Microsoft.EntityFrameworkCore;

namespace MailService
{
    public class BernoulliTotalOption : IModelOption<BernoulliTotal>
    {
        public DbSet<BernoulliTotal> GetAll(NaiveBayesClassifierContext _context)
        {
            return _context.BernoulliTotals;
        }
    }
}
