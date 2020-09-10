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
    /// Логика взаимодействия для InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        public InfoWindow()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SourceCode_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/svenito92");
        }

        private void Portfolio_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://be.net/pptxman");
        }

        private void Telegram_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://t.me/pptxmen");
        }

        private void Licence_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.gnu.org/licenses/gpl-3.0.txt");
        }
    }
}
