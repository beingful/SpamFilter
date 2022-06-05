using System.Collections.Generic;

namespace MailService
{
    public class PolynomialTotalOption : IModelOption<PolynomialTotal>
    {
        public IEnumerable<PolynomialTotal> GetAll(NaiveBayesClassifierContext _context)
        {
            return _context.PolynomialTotals;
        }
    }
}
