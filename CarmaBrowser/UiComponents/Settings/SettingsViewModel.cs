using CarmaBrowser.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarmaBrowser.UiComponents.Settings
{
    public class SettingsViewModel : ViewModelBase
    {
        private IFilesService _filesService;
        private RelayCommand _browseFolderCommand;
        private string _carmaPath;
        private bool _isSettingsFlyoutOpen;

        public SettingsViewModel(IFilesService filesService)
        {
            _filesService = filesService;
        }

        public string CarmaPath
        {
            get { return _carmaPath; }
            set { Set(() => CarmaPath, ref _carmaPath, value); }
        }

        public bool IsSettingsFlyoutOpen
        {
            get { return _isSettingsFlyoutOpen; }
            set { Set(() => IsSettingsFlyoutOpen, ref _isSettingsFlyoutOpen, value); }
        }

        public RelayCommand BrowseFolderCommand
        {
            get
            {
                return _browseFolderCommand
                    ?? (_browseFolderCommand = new RelayCommand(() =>
                    {
                        var dir = _filesService.BrowseDirectory();
                        if (!string.IsNullOrEmpty(dir))
                        {
                            CarmaPath = dir;
                        }
                    }));
            }
        }

        public SettingsModel GetModel()
        {
            return new SettingsModel
            {
                CarmaPath = CarmaPath
            };
        }

        public void SetModel(SettingsModel model)
        {
            CarmaPath = model.CarmaPath;
        }
    }
}
