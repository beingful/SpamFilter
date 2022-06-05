using System.Collections.Generic;

namespace MailService
{
    public class PolynomialOption : IModelOption<Polynomial>
    {
        public IEnumerable<Polynomial> GetAll(NaiveBayesClassifierContext _context)
        {
            return _context.Polynomials;
        }
    }
}
