using Microsoft.EntityFrameworkCore;

namespace MailService
{
    public class BernoulliOption : IModelOption<Bernoulli>
    {
        public DbSet<Bernoulli> GetAll(NaiveBayesClassifierContext _context)
        {
            return _context.Bernoullis;
        }
    }
}