using System.IO;
using System.Windows;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace Slide_to_Image_4K
{
    public class PresentationWorker
    {
        public int ImageWidth { get; set; }
        public int ImageHeight { get; set; }
        public string ChosenFile { get; set; }
        public string OutputFolder { get; set; }

        public PresentationWorker()
        {
            ImageWidth = 1280;
            ImageHeight = 720;
        }

        public void ExtractSlides()
        {
            if (!OutputFolder.EndsWith("\\"))
            {
                OutputFolder += "\\";
            }

            if (!File.Exists(ChosenFile))
            {
                MessageBox.Show("Chosen file does not exist!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!Directory.Exists(OutputFolder))
            {
                MessageBox.Show("Chosen directory does not exist!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var pptApplication = new PowerPoint.Application();
            var pptPres = pptApplication.Presentations.Open(ChosenFile);

            try
            {
                foreach (PowerPoint.Slide s in pptPres.Slides)
                {
                    s.Export(OutputFolder + s.SlideNumber + ".png", "png", ImageWidth, ImageHeight);
                }
            }
            finally
            {
                try
                {
                    pptPres.Close();
                    pptApplication.Quit();
                }
                catch { MessageBox.Show("PowerPoint could not be closed properly"); }
            }

            MessageBox.Show("Images extracted successfully!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
