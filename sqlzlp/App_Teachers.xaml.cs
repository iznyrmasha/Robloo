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
    public partial class App_Teachers : Window
    {
        DataBase db = new DataBase();
        public teachers NewTeachers { get; private set; }
        public App_Teachers()
        {
            InitializeComponent();
            LoadSubjectsIntoComboBox();
        }

        private void AddTeacherButton_Click(object sender, RoutedEventArgs e)
        {
            string firstname = fi_nameBlock.Text;
            string lastname = la_nameBlock.Text;
            if (comboBoxSub.SelectedValue == null)
            {
                MessageBox.Show("Выберите предмет!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int subjectId = (int)comboBoxSub.SelectedValue;

            if (string.IsNullOrWhiteSpace(firstname) || string.IsNullOrWhiteSpace(lastname))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                db.App_Teachers(firstname, lastname, subjectId);

                NewTeachers = new teachers
                {
                    Firstname = firstname,
                    Lastname = lastname
                };
                MessageBox.Show("Преподаватель успешно добавлен");

                ClearFields();
                this.DialogResult = true;
                Close();
        }

        private void LoadSubjectsIntoComboBox()
        {
            List<subjects> subjj = db.GetSubjects();

            if (subjj == null || subjj.Count == 0)
            {
                MessageBox.Show("Список предметов пуст!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            comboBoxSub.ItemsSource = subjj;
            comboBoxSub.DisplayMemberPath = "Name_sub";
            comboBoxSub.SelectedValuePath = "Id_subject";
        }

        private void ClearFields()
        {
            fi_nameBlock.Text = string.Empty;
            la_nameBlock.Text = string.Empty;

        }
    }
}
