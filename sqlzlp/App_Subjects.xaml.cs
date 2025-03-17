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
    /// Логика взаимодействия для App_Subjects.xaml
    /// </summary>
    public partial class App_Subjects : Window
    {
        DataBase db = new DataBase();
        public subjects NewSubjects { get; private set; }

        public App_Subjects()
        {
            InitializeComponent();
        }

        private void AddSubButton_Click(object sender, RoutedEventArgs e)
        {
            string sub_n = sub_nBlock.Text;

            if (string.IsNullOrWhiteSpace(sub_n))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            db.App_Subjects(sub_n);

            NewSubjects = new subjects
            {
                Name_sub = sub_n
            };

            MessageBox.Show("Предмет успешно добавлен");
            ClearFields();
            this.DialogResult = true;
            Close();
        }

        private void ClearFields()
        {
            sub_nBlock.Text = string.Empty;
        }
    }
}
