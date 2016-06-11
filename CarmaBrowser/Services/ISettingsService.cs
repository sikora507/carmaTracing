using CarmaBrowser.UiComponents.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarmaBrowser.Services
{
    interface ISettingsService
    {
        void SaveSettings(SettingsModel model);
        SettingsModel LoadSettings();
    }
}
