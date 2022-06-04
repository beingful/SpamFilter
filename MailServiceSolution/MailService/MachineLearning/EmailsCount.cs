using System;

namespace MailService
{
    public class EmailsCount
    {
        public int Spam => GetCount(nameof(Spam));

        public int Correspondence => GetCount(nameof(Correspondence));

        public int All => Spam + Correspondence;

        private int GetCount(string propertyName)
        {
            var appSetting = new AppSetting(propertyName);

            string value = appSetting.Get();

            return Convert.ToInt32(value);
        }

        private void AddOneMore(string category)
        {
            var appSetting = new AppSetting(category);

            int oldValue = GetCount(category);

            string newValue = (oldValue + 1).ToString();

            appSetting.Set(newValue);
        }
    }
}