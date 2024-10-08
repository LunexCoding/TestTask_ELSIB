using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using TestTask.Models;
using System.Windows;

namespace TestTask.ViewModels
{
    public class MaterialsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Material> Materials { get; set; }  // Коллекция материалов

        private Material _selectedMaterial;
        public Material SelectedMaterial
        {
            get => _selectedMaterial;
            set
            {
                _selectedMaterial = value;
                OnPropertyChanged(nameof(SelectedMaterial));
            }
        }

        public ICommand AddMaterialCommand { get; }
        public ICommand DeleteMaterialCommand { get; }
        public ICommand ExitCommand { get; }

        public MaterialsViewModel()
        {
            Materials = new ObservableCollection<Material>(); // Инициализация коллекции материалов
            AddMaterialCommand = new RelayCommand(OpenAddMaterialWindow);
            DeleteMaterialCommand = new RelayCommand(DeleteSelectedMaterial, CanDeleteMaterial);
            ExitCommand = new RelayCommand(ExitApplication);
        }

        private void OpenAddMaterialWindow(object parameter)
        {
            // Логика для открытия окна добавления материала
            AddMaterialWindow addWindow = new AddMaterialWindow();
            if (addWindow.ShowDialog() == true)
            {
                Materials.Add(addWindow.NewMaterial); // Добавление нового материала после закрытия окна
            }
        }

        private void DeleteSelectedMaterial(object parameter)
        {
            if (SelectedMaterial != null)
            {
                Materials.Remove(SelectedMaterial); // Удаление выбранного материала
            }
        }

        private bool CanDeleteMaterial(object parameter)
        {
            return SelectedMaterial != null;
        }

        private void ExitApplication(object parameter)
        {
            Application.Current.Shutdown(); // Закрытие приложения
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}