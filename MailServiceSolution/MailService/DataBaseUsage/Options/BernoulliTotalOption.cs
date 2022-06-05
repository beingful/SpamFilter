using System.Collections.Generic;

namespace MailService
{
    public class BernoulliTotalOption : IModelOption<BernoulliTotal>
    {
        public IEnumerable<BernoulliTotal> GetAll(NaiveBayesClassifierContext _context)
        {
            return _context.BernoulliTotals;
        }
    }
}
