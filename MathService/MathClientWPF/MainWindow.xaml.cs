using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace MathClientWPF
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(Valor.Text, out int iValue))
            {
                // Se instancia el proxy
                MathService.MathClient client = new MathService.MathClient();

                // Se invoca el servicio
                bool result = client.Prime(iValue);
                Resultado.Text = result ? "Sí" : "No";
            }
            else
            {
                MessageBox.Show("Por favor, introduce un número válido.");
            }
        }


    }
}