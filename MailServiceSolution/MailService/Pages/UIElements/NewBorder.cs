using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MailService.Pages
{
    public class NewBorder
    {
        private readonly UIElement _child;

        public NewBorder(UIElement child) => _child = child;

        public Border Create()
        {
            var border = new Border
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(2),
                Margin = new Thickness(0, 10, 10, 0),
                CornerRadius = new CornerRadius(10),
                Background = new SolidColorBrush
                {
                    Color = Color.FromArgb(127, 255, 255, 255)
                }
            };

            border.Child = _child;

            return border;
        }
    }
}