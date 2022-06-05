using System.Windows.Media;

namespace MailService
{
    public class CategoryButtonView
    {
        public readonly string Content;
        public readonly Brush Background;

        public CategoryButtonView(string content, Brush background)
        {
            Content = content;
            Background = background;
        }
    }
}