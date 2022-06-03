using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MailService.Pages
{
    public class NewButton
    {
        private readonly string _name;
        private readonly RoutedEventHandler _buttonClick;
        private readonly ITextConverter _converter;
        private string _content;

        public NewButton(string name, string content, RoutedEventHandler buttonClick, ITextConverter converter = null)
        {
            _name = name;
            _content = content;
            _buttonClick = buttonClick;
            _converter = converter;
        }

        public Button Create()
        {
            _content = _converter?.Convert(_content);

            var button = new Button
            {
                FontSize = 24,
                Content = _content,
                Name = _name,
                Margin = new Thickness(5),
                BorderThickness = new Thickness(0),
                BorderBrush = Brushes.White,
                Background = new SolidColorBrush() { Opacity = 0.5 },
            };

            button.Click += _buttonClick;

            return button;
        }
    }
}