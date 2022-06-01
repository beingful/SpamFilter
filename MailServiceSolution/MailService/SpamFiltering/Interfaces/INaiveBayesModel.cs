namespace MailService
{
    public interface INaiveBayesModel
    {
        public double Calculate<CategoryType>()
            where CategoryType : IEmailCategory, new();
    }
}