using System.Windows;
using System.Windows.Controls;

namespace MailService.Pages
{
    public class NewRowDefinition
    {
        private readonly double _size;

        public NewRowDefinition(double size) => _size = size;

        public RowDefinition Create() => new RowDefinition { Height = new GridLength(_size) };
    }
}