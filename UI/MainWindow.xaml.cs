using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Applications;
using UI.ViewModels;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly FileConverterViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();

            _viewModel = new FileConverterViewModel();

            FilesToConvert.ItemsSource = _viewModel.FilesToConvert;
            Resolutions.ItemsSource = _viewModel.SuppliedResolutions;
            SaveLocation.Text = _viewModel.SaveLocation;
            Resolutions.SelectAll();
        }

        private void AddFile_OnClick(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".ai",
                Filter = "SVG (.svg)|*.svg|All Files|*.*",
                Multiselect = true
            };

            bool? result = fileDialog.ShowDialog();

            if (result == true)
                _viewModel.FilesToConvert.AddRange(fileDialog.FileNames);

            FilesToConvert.Items.Refresh();
            
        }

        private void SelectSaveLocation_OnClick(object sender, RoutedEventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
                SaveLocation.Text = folderBrowserDialog.SelectedPath;
        }

        private void ConvertFiles_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.ConvertFiles(Resolutions.SelectedItems.Cast<Resolution>().ToList());
        }
    }
}
