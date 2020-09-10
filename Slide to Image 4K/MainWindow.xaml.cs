using System.Linq;
using System.Windows;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Slide_to_Image_4K
{
    public partial class MainWindow : Window
    {
        private readonly PresentationWorker worker = new PresentationWorker();
        public MainWindow()
        {
            InitializeComponent();

            string outputFolder = Utils.GetPathToDesktop();
            outputPathBox.Text = outputFolder;

            SetOutputFolder(outputFolder);
        }

        private void ButtonHD_Checked(object sender, RoutedEventArgs e)
        {
            worker.ImageWidth = 1280;
            worker.ImageHeight = 720;
        }

        private void ButtonFullHD_Checked(object sender, RoutedEventArgs e)
        {
            worker.ImageWidth = 1920;
            worker.ImageHeight = 1080;
        }

        private void Button4K_Checked(object sender, RoutedEventArgs e)
        {
            worker.ImageWidth = 3840;
            worker.ImageHeight = 2160;
        }

        private void ChoosePresentation_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "PowerPoint files (*.pptx)|*.pptx| PowerPoint files (*.ppt)|*.ppt",
                InitialDirectory = Utils.GetPathToDesktop()
            };
            if (dialog.ShowDialog() == true)
            {
                string chosenFileName = dialog.FileName;
                worker.ChosenFile = chosenFileName;
                ShowChosenFileName(chosenFileName);
                EnableExtraction();
            }
        }

        private void ShowChosenFileName(string path)
        {
            string name = path.Split('\\').Last();
            choosenFileName.Text = name;
        }

        private void EnableExtraction()
        {
            this.buttonExtract.IsEnabled = true;
        }

        private void SetOutputFolder(string folder)
        {
            worker.OutputFolder = folder;
        }

        private void DragPresentation_OnDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                string chosenFileName = files[0];

                string extension = chosenFileName.Split('.').Last();

                if (extension == "ppt" || extension == "pptx")
                {
                    worker.ChosenFile = chosenFileName;
                    ShowChosenFileName(chosenFileName);
                    EnableExtraction();
                }
            }
        }

        private void ChooseOutputFolderButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true
            };

            CommonFileDialogResult result = dialog.ShowDialog();
            if(result == CommonFileDialogResult.Ok)
            {
                string outputFolder = dialog.FileName;
                outputPathBox.Text = outputFolder;
                SetOutputFolder(outputFolder);
            }
        }

        private void ButtonExtract_Click(object sender, RoutedEventArgs e)
        {
            worker.ExtractSlides();
        }

        private void ButtonInformation_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow info = new InfoWindow();
            info.ShowDialog();
        }

        private void OutputPathBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            worker.OutputFolder = outputPathBox.Text;
        }
    }
}
