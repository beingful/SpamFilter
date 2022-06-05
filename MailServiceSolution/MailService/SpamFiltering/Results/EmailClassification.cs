namespace MailService
{
    public class EmailClassification
    {
        public readonly TextRepresentation TextRepresentation;
        public readonly ModelResult Bernoulli;
        public readonly ModelResult Polynomial;

        public EmailClassification(TextRepresentation textRepresentation,
            ModelResult bernoulli, ModelResult polynomial)
        {
            TextRepresentation = textRepresentation;
            Bernoulli = bernoulli;
            Polynomial = polynomial;
        }
    }
}