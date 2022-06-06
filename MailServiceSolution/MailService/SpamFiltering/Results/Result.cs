namespace MailService
{
    public class Result
    {
        public readonly double Probability;
        public readonly string Category;

        public Result(double probability, string category) 
        {
            Probability = probability;
            Category = category;
        }
    }
}