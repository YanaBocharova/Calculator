using Calculator.Model;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Calculator.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            viewOperation.Content = string.Empty;
        }
      
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button button = sender as Button;
            var btnSymb = button.Content.ToString();

            textCalk.Text = Calk.BtnNumber_Click(btnSymb);
           
        }
        private void BtnClick_Operation(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var btnSymb = button.Content.ToString();
            var taple = Calk.BtnClick_Operation(btnSymb, textCalk.Text, viewOperation.Content.ToString());

            textCalk.Text = taple.Item1;
            viewOperation.Content = taple.Item2;

        }

        private void BtnClearNumber_Click(object sender, RoutedEventArgs e)
        {
            textCalk.Text = string.Empty;
            Calk.numMath2 = 0;
        }

        private void BtnClearExtension_Click(object sender, RoutedEventArgs e)
        {
            Calk.ClearExtention();
            viewOperation.Content = string.Empty;
            textCalk.Text = string.Empty;
        }

        private void Btn_clearLastSymb_Click(object sender, RoutedEventArgs e)
        {
            int countPos = Calk.numsBuilder.Length;
            if (countPos >= 2)
            {
                Calk.numsBuilder.Remove(countPos - 1, 1);
                Calk.state = Calk. numsBuilder.ToString();
                textCalk.Text = Calk. numsBuilder.ToString();
                Calk.numMath2 = double.Parse(Calk.numsBuilder.ToString());
            }
        }

        private void Btn_Point(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var btnSymb = button.Content.ToString();
            textCalk.Text = Calk.BtnClick_Point(btnSymb);

        }
    }
}
