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
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathService;




namespace EquationsClientWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int numero_ecuaciones;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Generar(object sender, RoutedEventArgs e)
        {
            // Verifica si el usuario ha ingresado un número válido de ecuaciones
            if (int.TryParse(Num_eq.Text, out int numEcuaciones) && numEcuaciones > 0)
            {
                numero_ecuaciones = numEcuaciones;
                // Limpia el grid si ya hay controles en él
                EsquemaGrid.Children.Clear();
                EsquemaGrid.RowDefinitions.Clear();
                EsquemaGrid.ColumnDefinitions.Clear();

                // Añade columnas para las ecuaciones, el signo = y las soluciones
                for (int i = 0; i < numEcuaciones; i++)
                {
                    EsquemaGrid.RowDefinitions.Add(new RowDefinition());
                    EsquemaGrid.ColumnDefinitions.Add(new ColumnDefinition());
                }
                EsquemaGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto }); // Columna para el signo =
                EsquemaGrid.ColumnDefinitions.Add(new ColumnDefinition()); // Columna para las soluciones

                // Crea el esquema de tamaño (N+2)xN (una columna adicional para el signo = y otra para las soluciones)
                for (int i = 0; i < numEcuaciones; i++)
                {
                    for (int j = 0; j < numEcuaciones + 2; j++)
                    {
                        if (j == numEcuaciones) // Agrega el signo =
                        {
                            var label = new Label
                            {
                                Content = "=",
                                FontSize = 16,
                                Margin = new Thickness(1),
                                VerticalContentAlignment = VerticalAlignment.Center,
                                HorizontalContentAlignment = HorizontalAlignment.Center
                            };
                            Grid.SetRow(label, i);
                            Grid.SetColumn(label, j);
                            EsquemaGrid.Children.Add(label);
                        }
                        else // Agrega un TextBox para las ecuaciones y las soluciones
                        {
                            var textBox = new TextBox
                            {
                                FontSize = 16,
                                Margin = new Thickness(1),
                                VerticalContentAlignment = VerticalAlignment.Center,
                                HorizontalContentAlignment = HorizontalAlignment.Center
                            };
                            Grid.SetRow(textBox, i);
                            Grid.SetColumn(textBox, j);
                            EsquemaGrid.Children.Add(textBox);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, introduce un número válido de ecuaciones.");
            }
        }

        private void Button_Click_Resolver(object sender, RoutedEventArgs e)
        {
            // Crear una matriz para almacenar los valores de las ecuaciones
            List<double> valores_ecuaciones = new List<double>();
            List<double> valores_datos = new List<double>();

            int fila = 0;
            int columna = 0;
            bool ladoDerecho = false;

            // Recorrer todas las TextBoxes dentro del Grid EsquemaGrid
            foreach (var control in EsquemaGrid.Children)
            {
                if (control is TextBox textBox)
                {
                    // Verificar si el texto es un número válido
                    if (double.TryParse(textBox.Text, out double valor))
                    {
                        if (ladoDerecho==true)
                        {
                            // Agregar el valor a la lista de valores de soluciones
                            valores_datos.Add(valor);
                            ladoDerecho = false;

                            columna = 0;
                            fila++;
                        }
                        else
                        {
                            // Asignar el valor a la posición correspondiente en la matriz
                            valores_ecuaciones.Add(valor);

                            // Incrementar el índice de la columna
                            columna++;

                            if (columna == numero_ecuaciones)
                            {

                                // Restablecer ladoDerecho a false al final de cada fila
                                ladoDerecho = true;
                            }

                        }
                    }
                    else
                    {
                        // Mostrar un mensaje de error si el texto no es un número válido
                        MessageBox.Show("Por favor, asegúrate de que todos los campos contienen valores numéricos válidos.");
                        return;
                    }
                }
            }

            // Convertir las listas de valores a arrays de doubles
            double[] array_ecuaciones = valores_ecuaciones.ToArray();
            double[] array_soluciones = valores_datos.ToArray();



            // Se instancia el proxy
            MathClient client = new MathClient(MathClient.EndpointConfiguration.BasicHttpBinding_IMath);

            double[] soluciones = client.resolverEcuaciones(array_ecuaciones, array_soluciones);
            MostrarSolucionesEnGrid(soluciones.ToArray());
            /* Prueba local */
            //Vector<double> soluciones = valores_ecuaciones.Solve(Vector<double>.Build.DenseOfArray(arraySoluciones));        
            //MostrarSolucionesEnGrid(soluciones.ToArray());
            
        }

        private void MostrarSolucionesEnGrid(double[] soluciones)
        {
            // Limpiar el contenido del Grid antes de agregar las nuevas soluciones
            SolucionesGrid.Children.Clear();
            SolucionesGrid.RowDefinitions.Clear();

            // Agregar las filas necesarias al Grid
            for (int i = 0; i < soluciones.Length; i++)
            {
                SolucionesGrid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            }

            // Recorrer el array de soluciones y agregar cada valor a una nueva TextBox dentro del Grid
            for (int i = 0; i < soluciones.Length; i++)
            {
                // Crear una nueva TextBox para mostrar la solución
              

                var textBoxSolucion = new TextBox
                {
                    FontSize = 16,
                    Margin = new Thickness(1),
                    VerticalContentAlignment = VerticalAlignment.Center,
                    HorizontalContentAlignment = HorizontalAlignment.Center
                };

                textBoxSolucion.Text = soluciones[i].ToString();
                textBoxSolucion.IsReadOnly = true;

                // Agregar la TextBox al Grid en la fila correspondiente
                Grid.SetRow(textBoxSolucion, i); // La fila es el índice actual en el array de soluciones
                SolucionesGrid.Children.Add(textBoxSolucion);
            }
        }


    }
}