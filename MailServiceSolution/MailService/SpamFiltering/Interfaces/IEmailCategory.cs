namespace MailService
{
    public interface IEmailCategory
    {
        public (int Numerator, int Denominator) Get(IFractionObserver facade, string word);
    }
}