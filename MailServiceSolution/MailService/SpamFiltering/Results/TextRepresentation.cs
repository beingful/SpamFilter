using System.Collections.Generic;

namespace MailService
{
    public class TextRepresentation
    {
        public readonly string Text;
        public readonly IEnumerable<string> Vector;

        public TextRepresentation(string text, string category, IEnumerable<string> vector)
        {
            Text = text;
            Category = category;
            Vector = vector;
        }

        public string Category { get; set; }
    }
}
