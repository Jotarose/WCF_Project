
using System;
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
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using ServiceReference1;
using Tuple = ServiceReference1.Tuple;



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

        private void Button_Click_Primo(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(Valor.Text, out int iValue))
            {
                // Se instancia el proxy
                MathClient client = new MathClient();

                // Se invoca el servicio
                bool result = client.Prime(iValue);
                Resultado.Text = result ? "Sí" : "No";
            }
            else
            {
                MessageBox.Show("Por favor, introduce un número válido.");
            }
        }

        private void Button_Click_Sumar(object sender, RoutedEventArgs e)
        {

            // Se instancia el proxy
            MathClient client = new MathClient();

            string _nombre = nombreTupla.Text;
            String[] _data;
            Tuple resultado;

            _data = datosTupla.Text.Split(' ');
            double[] dato = new double[_data.Length];

            for (int i = 0; i < _data.Length; i++)
            {
                dato[i] = Convert.ToDouble(_data[i]);
            }

            Tuple tupla = new Tuple();
            tupla.Data = dato;
            tupla.Name = _nombre;

            // Se invoca el servicio
            resultado = client.sumaInterna(tupla);

            //Se presentan los resultados
            resultadoTuplaNumero.Text = resultado.Data[0].ToString();
            resultadoTupla.Text = resultado.Name;
        }
    }
}