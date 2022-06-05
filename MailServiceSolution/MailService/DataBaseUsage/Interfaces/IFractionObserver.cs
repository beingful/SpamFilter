namespace MailService
{
    public interface IFractionObserver
    {
        public (int Numerator, int Denominator) GetFraction(string word, string category);
    }
}