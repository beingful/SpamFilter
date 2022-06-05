using System.Collections.Generic;

namespace MailService
{
    public class BernoulliOption : IModelOption<Bernoulli>
    {
        public IEnumerable<Bernoulli> GetAll(NaiveBayesClassifierContext _context)
        {
            return _context.Bernoullis;
        }
    }
}