using CarmaBrowser.Services;
using CarmaBrowser.UiComponents.Settings;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarmaBrowser
{
    class MainWindowViewModel : ViewModelBase
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
