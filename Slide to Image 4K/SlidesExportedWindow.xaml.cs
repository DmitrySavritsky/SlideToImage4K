using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Slide_to_Image_4K
{
    /// <summary>
    /// Логика взаимодействия для SlidesExportedWindow.xaml
    /// </summary>
    public partial class SlidesExportedWindow : Window
    {
        public SlidesExportedWindow()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Telegram_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://t.me/pptxmen");
        }
    }
}
