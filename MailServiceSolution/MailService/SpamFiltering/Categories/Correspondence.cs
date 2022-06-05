namespace MailService
{
    public class Correspondence : IEmailCategory
    {
        public (int Numerator, int Denominator) Get(IFractionObserver model, string word)
        {
            return model.GetFraction(word, nameof(Correspondence));
        }
    }
}