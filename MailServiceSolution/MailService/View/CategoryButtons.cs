using System.Collections.Generic;
using System.Windows.Media;

namespace MailService
{
    public class CategoryButtons
    {
        private static readonly IEnumerable<CategoryButtonView> _buttonViews;
        private readonly string _category;

        static CategoryButtons()
        {
            _buttonViews = new List<CategoryButtonView>()
            {
                new CategoryButtonView(nameof(Spam), Brushes.LightPink),
                new CategoryButtonView(nameof(Correspondence), Brushes.AliceBlue)
            };
        }

        public CategoryButtons(string category) => _category = category;

        private void GetCategoryButtonView()
        {
            return 
        }
    }
}