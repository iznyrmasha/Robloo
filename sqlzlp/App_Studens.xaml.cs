using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace sqlzlp
{
    /// <summary>
    /// Логика взаимодействия для App_Studens.xaml
    /// </summary>
    public partial class App_Studens : Window
    {
        DataBase db = new DataBase();
        public students NewStudents { get; private set; }
        public App_Studens()
        {
            InitializeComponent();
            LoadGroupsIntoComboBox();
        }

        private void LoadGroupsIntoComboBox()
        {
            List<student_group> groups = db.Get_Group();

            if (groups == null || groups.Count == 0)
            {
                MessageBox.Show("Список групп пуст!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            comboBoxGroup.ItemsSource = groups;
            comboBoxGroup.DisplayMemberPath = "Group_num";
            comboBoxGroup.SelectedValuePath = "Id_group";
        }


       

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            string firstname = f_nameBlock.Text;
            string lastname = l_nameBlock.Text;
            if (comboBoxGroup.SelectedItem is student_group selectedGroup)
            {
                int group_num = selectedGroup.Id_group;

                if (string.IsNullOrWhiteSpace(firstname) || string.IsNullOrWhiteSpace(lastname))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                db.App_Studens(firstname, lastname, group_num);

                NewStudents = new students
                {
                    Firstname = firstname,
                    Lastname = lastname,
                    Group_num = selectedGroup.Group_num
                };
                MessageBox.Show("Студент успешно добавлен в группу");
              
                ClearFields();
                this.DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите группу.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ClearFields()
        {
            f_nameBlock.Text = string.Empty;
            l_nameBlock.Text = string.Empty;

        }
    }
}
