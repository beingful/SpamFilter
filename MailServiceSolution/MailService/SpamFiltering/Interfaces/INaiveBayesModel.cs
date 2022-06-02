namespace MailService
{
    public interface INaiveBayesModel
    {
        public ModelResult<IEmailCategory> Calculate<CategoryType>()
            where CategoryType : IEmailCategory, new();
    }
}