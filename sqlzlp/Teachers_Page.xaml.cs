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
    /// Логика взаимодействия для Teachers_Page.xaml
    /// </summary>
    public partial class Teachers_Page : Page
    {
        DataBase db = new DataBase();
        public ObservableCollection<teachers> Teachers { get; set; }
        public Teachers_Page()
        {
            InitializeComponent();
            Teachers = new ObservableCollection<teachers>();
            LoadTeachers();
        }

        private void LoadTeachers()
        {
            var stlist = db.GetTeachers();
            foreach (var teachers in stlist)
            {
                Teachers.Add(teachers);
            }
            teach_listBox.ItemsSource = stlist;
        }

        private void AddTeacherButton_Click(object sender, RoutedEventArgs e)
        {
            App_Teachers app_Teachers = new App_Teachers();
            if (app_Teachers.ShowDialog() == true)
            {
                if (app_Teachers.NewTeachers != null)
                {
                    Teachers.Add(app_Teachers.NewTeachers);
                }
                LoadTeachers();
            }
        }

        private void dele_btn_Click(object sender, RoutedEventArgs e)
        {
            teachers selectedTeacher = teach_listBox.SelectedItem as teachers;
            if (selectedTeacher == null)
            {
                MessageBox.Show("Пожалуйста, выберите преподавателя для удаления.",
               "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (MessageBox.Show($"Вы действительно хотите удалить препожавателя {selectedTeacher.Firstname} {selectedTeacher.Lastname}?",
                "Подтверждение удаления", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                db.RemoveFromTeachers(selectedTeacher.Id_teacher);
                Teachers.Remove(selectedTeacher);
                MessageBox.Show("Преподаватель успешно удален.");
            }

            LoadTeachers();
        }
    }
}
