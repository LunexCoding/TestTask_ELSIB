using System.Windows;
using TestTask.Models;

namespace TestTask
{
    public partial class AddMaterialWindow : Window
    {
        public Material NewMaterial { get; set; }

        public AddMaterialWindow()
        {
            InitializeComponent();
            NewMaterial = new Material();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            NewMaterial.Code = CodeTextBox.Text;
            NewMaterial.Name = NameTextBox.Text;
            if (decimal.TryParse(CostTextBox.Text, out decimal cost))
            {
                NewMaterial.Cost = cost;
                this.DialogResult = true; // Устанавливаем положительный результат
            }
            else
            {
                MessageBox.Show("Некорректное значение стоимости!");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false; // Закрываем окно без сохранения
        }
    }
}