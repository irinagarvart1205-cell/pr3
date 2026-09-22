using Garvart.Classes;
using System.Windows;


namespace Garvart
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Classes.PersoInfo Player = new Classes.PersoInfo("Student", 100,10, 1, 0, 0, 5 );
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
