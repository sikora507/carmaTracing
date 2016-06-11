using CarmaBrowser.UiComponents.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CarmaBrowser.Services
{
    class SettingsService : ISettingsService
    {
        private const string _fileName = "Settings.bin";
        private string GetApplicationDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        public void SaveSettings(SettingsModel model)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(_fileName,
                                     FileMode.OpenOrCreate,
                                     FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, model);
            stream.Close();
        }

        public SettingsModel LoadSettings()
        {
            //if (File.Exists(Path.Combine(GetApplicationDirectory(), _fileName)))
            if (File.Exists(_fileName))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(_fileName,
                          FileMode.Open,
                          FileAccess.Read,
                          FileShare.Read);
                SettingsModel settings = (SettingsModel)formatter.Deserialize(stream);
                stream.Close();
                return settings;
            }
            else
            {
                return new SettingsModel();
            }
        }
    }
}
