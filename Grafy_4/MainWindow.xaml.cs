using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Grafy_4
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
            if (Probability_Of_Edge_Occurence.Text != "")
            {
                Probability_Of_Edge_Occurence.Background = Brushes.White;

                //StackPanelWithConnections.Children.Clear();

                Random r = new Random();
                int v = Int32.Parse(Number_Of_Vertex.Text);

                AdjacencyMatrix adjacencyMatrix = new AdjacencyMatrix(v);

                for (int i = 0; i < v; i++)
                {
                    for (int j = 0; j < v; j++)
                    {
                        int probability = r.Next(0, 100);

                        if (probability > Int32.Parse(Probability_Of_Edge_Occurence.Text))
                        {
                            adjacencyMatrix.AdjacencyArray[i, j] = 0;
                        }
                        else
                        {
                            adjacencyMatrix.AdjacencyArray[i, j] = 1;
                        }
                        adjacencyMatrix.AdjacencyArray[i, i] = 0;
                    }
                }

                adjacencyMatrix.Display(StackPanelForDisplayingAdjacencyMatrix, MyCanvas, StackPanelForDisplayingIncidenceMatrix, StackPanelForDisplayingAdjacencylist);
            }
            else
            {
                Probability_Of_Edge_Occurence.Background = Brushes.OrangeRed;
            }
        }

        private void NumbersOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
