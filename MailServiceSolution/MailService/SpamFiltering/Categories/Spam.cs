namespace MailService
{
    public class Spam : IEmailCategory
    {
        public Fraction Get(Model model) => model.SpamNavigation;
    }
}
