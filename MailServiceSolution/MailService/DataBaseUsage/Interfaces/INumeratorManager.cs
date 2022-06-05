using System;

namespace MailService
{
    public interface INumeratorManager : IDisposable
    {
        public void PlusToNumerator(string word, string category, int count);
        public void MinusFromNumerator(string word, string category, int count);
    }
}
