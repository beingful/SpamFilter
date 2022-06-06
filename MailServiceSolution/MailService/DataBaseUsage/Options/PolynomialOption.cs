using Microsoft.EntityFrameworkCore;

namespace MailService
{
    public class PolynomialOption : IModelOption<Polynomial>
    {
        public DbSet<Polynomial> GetAll(NaiveBayesClassifierContext _context)
        {
            return _context.Polynomials;
        }
    }
}
