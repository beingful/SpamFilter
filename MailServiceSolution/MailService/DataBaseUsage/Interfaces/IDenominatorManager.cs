using System;

namespace MailService
{
    public interface IDenominatorManager : IDisposable
    {
        public void Plus(string category, int count);
        public void Minus(string category, int count);
    }
}
