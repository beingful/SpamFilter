using System.Text.RegularExpressions;

namespace MailService.Pages
{
    public class EmailPreview : ITextConverter
    {
        string ITextConverter.Convert(string text)
        {
            string textForPreview;
            int totalCount = 50;

            ReplaceWhiteSymbols(ref text);

            if (text.Length <= totalCount)
            {
                textForPreview = text.Substring(0, text.Length);
            }
            else
            {
                textForPreview = text.Substring(0, totalCount) + "...";
            }

            return textForPreview;
        }

        private void ReplaceWhiteSymbols(ref string text)
        {
            var whiteSpaces = new Regex("\n|\t|\r");

            text = whiteSpaces.Replace(text, " ");
        }
    }
}