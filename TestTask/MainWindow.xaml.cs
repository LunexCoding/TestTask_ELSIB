using System.Windows;
using TestTask.ViewModels;

namespace TestTask
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MaterialsViewModel(); // Устанавливаем контекст данных
        }
    }
}