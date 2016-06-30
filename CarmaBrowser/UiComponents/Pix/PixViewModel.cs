using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

namespace CarmaBrowser.UiComponents.Pix
{
    public class PixViewModel : ViewModelBase
    {
        public ObservableCollection<PixListItemViewModel> PixItems { get; set; }

        private PixListItemViewModel _selectedPix;
        private bool _isSelected;

        public PixListItemViewModel SelectedPix
        {
            get { return _selectedPix; }
            set { Set(() => SelectedPix, ref _selectedPix, value); }
        }
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (Set(() => IsSelected, ref _isSelected, value))
                {
                    if (value == true && PixItems.Count == 0)
                    {
                        GetPixItems();
                    }
                }
            }
        }

        private void GetPixItems()
        {
            //throw new NotImplementedException();
        }
    }
}
