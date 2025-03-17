using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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

namespace sqlzlp
{
    /// <summary>
    /// Логика взаимодействия для Student_Page.xaml
    /// </summary>
    public partial class Student_Page : Page
    {
        DataBase db = new DataBase();
        public ObservableCollection<students> Students { get; set; }
        public Student_Page()
        {
            InitializeComponent();
            Students = new ObservableCollection<students>();
            LoadStudents();
        }

        private void LoadStudents()
        {
            var stlist = db.GetStudents();
            foreach (var student in stlist)
            {
                Students.Add(student);
            }
            stud_listBox.ItemsSource = Students;
            
        }


        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            App_Studens app_Studens = new App_Studens();
            if (app_Studens.ShowDialog() == true)
            {
                if (app_Studens.NewStudents != null)
                {
                    Students.Add(app_Studens.NewStudents);
                }
            }
        }
        private void del_btn_Click(object sender, RoutedEventArgs e)
        {
            students selectedPatient = stud_listBox.SelectedItem as students;
            if (selectedPatient == null)
            {
                MessageBox.Show("Пожалуйста, выберите студента для удаления.",
               "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (MessageBox.Show($"Вы действительно хотите удалить студента {selectedPatient.Firstname} { selectedPatient.Lastname}?",
                "Подтверждение удаления", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
 {
                db.RemoveFromPatients(selectedPatient.Id_student);
                Students.Remove(selectedPatient);
                MessageBox.Show("Студент успешно удален.");

            }
        }


        
    }
}
