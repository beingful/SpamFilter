using System;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace MailService
{
    public static class ButtonExtension
    {
        public static int GetButtonIndex(this Button button)
        {
            var name = button.Name;
            int index = -1;

            if (name.Contains(nameof(Button)))
            {
                string indexFromName = name.Replace(nameof(Button), string.Empty);

                index = Convert.ToInt32(indexFromName);
            }

            return index;
        }

        public static string GetCategory(this Button button)
        {
            var regex = new Regex($".+{nameof(Spam)}|{nameof(Correspondence)}");

            string content = (string)button.Content;

            return regex.Match(content).Value;
        }
    }
}