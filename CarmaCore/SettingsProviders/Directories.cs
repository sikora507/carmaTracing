using CarmaCore.Contracts;
using System;

namespace CarmaCore.SettingsProviders
{
    public class Directories : IDirectories
    {
        public string CarmaDir
        {
            get; set;
        }
    }
}
