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

namespace EquationsClientWPF
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

        private void Button_Click_Generar(object sender, RoutedEventArgs e)
        {
            // Verifica si el usuario ha ingresado un número válido de ecuaciones
            if (int.TryParse(Num_eq.Text, out int numEcuaciones) && numEcuaciones > 0)
            {
                // Limpia el grid si ya hay controles en él
                EsquemaGrid.Children.Clear();
                EsquemaGrid.RowDefinitions.Clear();
                EsquemaGrid.ColumnDefinitions.Clear();

                // Añade columnas para las ecuaciones, el signo "=" y las soluciones
                for (int i = 0; i < numEcuaciones; i++)
                {
                    EsquemaGrid.RowDefinitions.Add(new RowDefinition());
                    EsquemaGrid.ColumnDefinitions.Add(new ColumnDefinition());
                }
                EsquemaGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto }); // Columna para el signo "="
                EsquemaGrid.ColumnDefinitions.Add(new ColumnDefinition()); // Columna para las soluciones

                // Crea el esquema de tamaño (N+2)xN (una columna adicional para el signo "=" y otra para las soluciones)
                for (int i = 0; i < numEcuaciones; i++)
                {
                    for (int j = 0; j < numEcuaciones + 2; j++)
                    {
                        if (j == numEcuaciones) // Agrega el signo "=" en la columna adecuada
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

    }
}