using CarmaBrowser.Services;
using CarmaBrowser.UiComponents.Settings;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using Helpers.Contracts;

namespace CarmaBrowser
{
    public class MainWindowViewModel : ViewModelBase
    {
        //private readonly PixViewModel _pixViewModel;
        private RelayCommand _openSettingsCommand;
        public MainWindowViewModel()
        {
            IFilesService filesService = SimpleIoc.Default.GetInstance<IFilesService>();
            ISettingsService settingsService = SimpleIoc.Default.GetInstance<ISettingsService>();
            Settings = SimpleIoc.Default.GetInstance<SettingsViewModel>();
            //_pixViewModel = new PixViewModel(filesService, settingsService);
        }

        public SettingsViewModel Settings { get; private set; }
        //public PixViewModel PixViewModel { get { return _pixViewModel; } }

        public RelayCommand OpenSettingsCommand
        {
            get
            {
                return _openSettingsCommand ?? (_openSettingsCommand = new RelayCommand(() =>
                {
                    Settings.IsSettingsFlyoutOpen = true;
                }));
            }
        }
    }
}
