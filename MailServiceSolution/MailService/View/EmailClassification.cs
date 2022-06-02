using System.Collections.Generic;

namespace MailService
{
    public class EmailClassification
    {
        public readonly string Text;
        public readonly IEnumerable<ModelResult<IEmailCategory>> Bernoulli;
        public readonly IEnumerable<ModelResult<IEmailCategory>> Polynomial;

        public EmailClassification(string text, IEnumerable<ModelResult<IEmailCategory>> bernoulli,
            IEnumerable<ModelResult<IEmailCategory>> polynomial)
        {
            Text = text;
            Bernoulli = bernoulli;
            Polynomial = polynomial;
        }
    }
}