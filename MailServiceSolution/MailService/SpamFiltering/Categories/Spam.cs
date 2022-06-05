namespace MailService
{
    public class Spam : IEmailCategory
    {
        public (int Numerator, int Denominator) Get(IFractionObserver model, string word)
        {
            return model.GetFraction(word, nameof(Spam));
        }
    }
}