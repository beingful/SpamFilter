using Microsoft.EntityFrameworkCore;

namespace MailService
{
    public class PolynomialTotalOption : IModelOption<PolynomialTotal>
    {
        public DbSet<PolynomialTotal> GetAll(NaiveBayesClassifierContext _context)
        {
            return _context.PolynomialTotals;
        }
    }
}
