using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MailService
{
    public class ClassificationCollection<ItemType> : ObservableCollection<ItemType>
        where ItemType : class, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler ItemPropertyChanged;

        protected override void InsertItem(int index, ItemType item)
        {
            base.InsertItem(index, item);
            item.PropertyChanged += ItemPropertyChangingHandler;
        }

        private void ItemPropertyChangingHandler(object sender, PropertyChangedEventArgs e)
        {
            ItemPropertyChanged?.Invoke(sender, e);
        }
    }
}