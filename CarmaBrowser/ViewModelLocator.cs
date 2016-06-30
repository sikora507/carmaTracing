using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using CarmaBrowser.UiComponents.Settings;
using CarmaBrowser.Services;
using CarmaCore.Contracts;
using CarmaCore;
using Helpers.Contracts;
using Helpers;

namespace CarmaBrowser.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            //if (ViewModelBase.IsInDesignModeStatic)
            //{
            //    SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
            //}
            //else
            //{
            //    SimpleIoc.Default.Register<IDataService, DataService>();
            //}

            SimpleIoc.Default.Register<MainWindowViewModel>();
            SimpleIoc.Default.Register<SettingsViewModel>();
            SimpleIoc.Default.Register<IFilesService, FilesService>();
            SimpleIoc.Default.Register<ISettingsService, SettingsService>();
        }


        public SettingsViewModel Settings
        {
            get { return ServiceLocator.Current.GetInstance<SettingsViewModel>(); }
        }

        public MainWindowViewModel Main
        {
            get { return ServiceLocator.Current.GetInstance<MainWindowViewModel>(); }
        }
        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}