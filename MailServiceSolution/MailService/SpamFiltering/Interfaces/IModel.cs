using System.Collections.Generic;

namespace MailService.SpamFiltering.Interfaces
{
    public interface IModel
    {
        public void GetVector();
        public IEnumerable<string> Vector { get; }
        public void RecountProperties();
    }
}
