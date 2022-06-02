namespace MailService
{
    public class Spam : IEmailCategory
    {
        Fraction IEmailCategory.Get(Model model) => model.SpamNavigation;
    }
}