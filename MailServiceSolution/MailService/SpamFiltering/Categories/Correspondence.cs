namespace MailService
{
    public class Correspondence : IEmailCategory
    {
        Fraction IEmailCategory.Get(Model model) => model.SpamNavigation;
    }
}