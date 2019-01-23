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

namespace Wpf_SimpleCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string _units;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeWindowElements()
        {
            _units = "feet";

            UpdateUnits();
        }

        private void btn_ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btn_Calculate_Click(object sender, RoutedEventArgs e)
        {
            double volume;
            string shape;
            double shapeMultiplier = 0;

            volume = double.Parse(TextBox_Height.Text) * double.Parse(TextBox_Width.Text) * double.Parse(TextBox_Length.Text);
            shape = ComboBox_Shape.SelectedItem as string;
            switch (shape)
            {
                case "Rectangular Prism":
                    shapeMultiplier = 1;
                    break;
                case "Pyramidal Prism":
                    shapeMultiplier = 1 / 3;
                    break;
                default:
                    break;
            }

            volume = volume * shapeMultiplier;

            Textbox_Result.Text = volume.ToString();
            
            SolutionWindow solutionWindow = new SolutionWindow(volume);
            solutionWindow.ShowDialog();
        }

        private void btn_HelpButton_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpwindow = new HelpWindow();

            helpwindow.ShowDialog();
        }

        private void RadioButton_Units_Checked(object sender, RoutedEventArgs e)
        {
            if (this.IsLoaded)
            {
                UpdateUnits();
            }
        }

        private void UpdateUnits()
        {
            if ((bool)RadioButton_Feet.IsChecked)
            {
                _units = "feet";
            }
            else if ((bool)RadioButton_Meters.IsChecked)
            {
                _units = "meters";
            }
            Label_Length.Content = "Length (" + _units + ")";
            Label_Width.Content = "Width (" + _units + ")";
            Label_Height.Content = "Height (" + _units + ")";
            Label_Volume.Content = "Volume (cubic" + _units + ")";
        }

        private void TextBox_Length_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(TextBox_Length.Text, out double length))
            {
                TextBox_Length.Focus();
                MessageBox.Show("Dude! What are you thinking!?");
                TextBox_Length.Text = "0";
                
            }
            else
            {
                TextBox_Length.BorderBrush = Brushes.Black;
            }

        }
    }
}
