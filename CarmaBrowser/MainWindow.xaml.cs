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
        private readonly ISettingsService _settingsService;

        public MainWindow()
        {
            InitializeComponent();
            _settingsService = ServiceLocator.Current.GetInstance<ISettingsService>();
            var viewModel = ServiceLocator.Current.GetInstance<MainWindowViewModel>();
            var model = _settingsService.LoadSettings();
            viewModel.Settings.SetModel(model);
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            var viewModel = ServiceLocator.Current.GetInstance<MainWindowViewModel>();
            var model = viewModel.Settings.GetModel();
            _settingsService.SaveSettings(model);
            base.OnClosing(e);
        }
    }
}