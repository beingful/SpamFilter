namespace MailService
{
    public class Correspondence : IEmailCategory
    {
        public Fraction Get(Model model) => model.SpamNavigation;
    }
}