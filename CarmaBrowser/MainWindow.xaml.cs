using System.Windows;
using CarmaBrowser.ViewModel;
using MahApps.Metro.Controls;
using CarmaBrowser.Services;
using Microsoft.Practices.ServiceLocation;

namespace CarmaBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private readonly MainWindowViewModel _viewModel;
        private readonly ISettingsService _settingsService;

        public MainWindow()
        {
            InitializeComponent();
            _settingsService = ServiceLocator.Current.GetInstance<ISettingsService>();
            _viewModel = new MainWindowViewModel();
            DataContext = _viewModel;
            var model = _settingsService.LoadSettings();
            _viewModel.Settings.SetModel(model);
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            //var locator = Application.Current.Resources["Locator"] as ViewModelLocator;
            var model = _viewModel.Settings.GetModel();
            _settingsService.SaveSettings(model);
            base.OnClosing(e);
        }
    }
}