using System.Collections.Generic;

namespace MailService
{
    public class EmailClassification
    {
        public readonly string Text;
        public readonly string Category;
        public readonly IEnumerable<ModelResult<IEmailCategory>> Bernoulli;
        public readonly IEnumerable<ModelResult<IEmailCategory>> Polynomial;

        public EmailClassification(string text, string category, 
            IEnumerable<ModelResult<IEmailCategory>> bernoulli,
            IEnumerable<ModelResult<IEmailCategory>> polynomial)
        {
            Text = text;
            Category = category;
            Bernoulli = bernoulli;
            Polynomial = polynomial;
        }
    }
}