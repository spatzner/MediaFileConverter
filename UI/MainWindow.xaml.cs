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
using ViewModels;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SVGConverter _svgConverter;

        public MainWindow()
        {
            InitializeComponent();

            _svgConverter = new SVGConverter();

            FilesToConvert.ItemsSource = _svgConverter.FilesToConvert;
            Resolutions.ItemsSource = _svgConverter.SuppliedResolutions;
            SaveLocation.Text = _svgConverter.SaveLocation;
            Resolutions.SelectAll();
        }

        private void AddFile_OnClick(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".svg",
                Filter = "SVG|*.svg|All Files|*.*",
                Multiselect = true,
                
            };

            bool? result = fileDialog.ShowDialog();

            if (result == true)
                _svgConverter.FilesToConvert.AddRange(fileDialog.FileNames);

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
            _svgConverter.SelectedResolutions.Clear();
            foreach (var resolutionsSelectedItem in Resolutions.SelectedItems)
            {
                _svgConverter.SelectedResolutions.Add(resolutionsSelectedItem as Resolution);
            }

            _svgConverter.ConvertFiles();
        }
    }
}
