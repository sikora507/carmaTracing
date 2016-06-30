using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CarmaBrowser.UiComponents.Pix
{
    public class PixListItemViewModel : ViewModelBase
    {
        private string _fileName;

        public string FileName
        {
            get { return _fileName; }
            set { Set(() => FileName, ref _fileName, value); }
        }

        private string _filePath;

        public string FilePath
        {
            get { return _filePath; }
            set { Set(() => FilePath, ref _filePath, value); }
        }

        BitmapSource _image;
        public BitmapSource Image
        {
            get { return _image; }
            set { Set(() => Image, ref _image, value); }
        }

        public ObservableCollection<Image> Images { get; set; }
    }
}
