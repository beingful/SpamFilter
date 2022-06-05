namespace MailService
{
    public class Result<CategoryType> where CategoryType : IEmailCategory
    {
        public readonly double Probability;

        public Result(double probability) => Probability = probability;

        public string Category => typeof(CategoryType).Name;
    }
}
