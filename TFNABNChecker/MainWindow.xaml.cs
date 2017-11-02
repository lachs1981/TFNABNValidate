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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TFNABNChecker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckTFNButton_Click(object sender, RoutedEventArgs e)
        {
            if(TFNTextBox.Text.IsValidTFN())
            {
                TFNResultLabel.Foreground = Brushes.Green;
                TFNResultLabel.Content = "Valid TFN!";
            }

            else
            {
                TFNResultLabel.Foreground = Brushes.Red;
                TFNResultLabel.Content = "Invalid TFN!";
            }
        }

        private void TFNTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;
            CheckTFNButton_Click(null, new RoutedEventArgs());
        }

        private void CheckABNButton_Click(object sender, RoutedEventArgs e)
        {
            if (ABNTextBox.Text.IsValidABN())
            {
                ABNResultLabel.Foreground = Brushes.Green;
                ABNResultLabel.Content = "Valid ABN!";
            }

            else
            {
                ABNResultLabel.Foreground = Brushes.Red;
                ABNResultLabel.Content = "Invalid ABN!";
            }
        }
    }
}
