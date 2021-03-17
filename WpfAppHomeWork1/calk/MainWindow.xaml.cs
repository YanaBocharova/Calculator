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

namespace calk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private calkulator Calk=new calkulator();
        public MainWindow()
        {
            InitializeComponent();
            viewOperation.Content = string.Empty;
        }

        private void Btn_clearLastSymb_Click(object sender, RoutedEventArgs e)
        {

        }
        // ввод чисел
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var btnSymb = button.Content.ToString();

            textCalk.Text = Calk.BtnNumber_Click(btnSymb);
        }
        // ввод операций
        private void BtnClick_Operation(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var btnSymb = button.Content.ToString();

            var taple = Calk.BtnClick_Operation(btnSymb, textCalk.Text,viewOperation.Content.ToString());

            textCalk.Text = taple.Item1;
            viewOperation.Content = taple.Item2;
        }
        // ставим точку для определения  нецелого числа 
        private void BtnClick_Point(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var btnSymb = button.Content.ToString();
            textCalk.Text = Calk.BtnClick_Point(btnSymb);
         
        }

        private void TextCalk_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
