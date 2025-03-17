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
    /// Логика взаимодействия для Subjects_Page.xaml
    /// </summary>
    public partial class Subjects_Page : Page
    {
        DataBase db = new DataBase();
        public ObservableCollection<subjects> Subjects { get; set; }
        public Subjects_Page()
        {
            InitializeComponent();
            Subjects = new ObservableCollection<subjects>();
            LoadSubjects();
        }

        private void LoadSubjects()
        {
           var stlist = db.GetSubjects();
            foreach (var subjects in stlist)
            {
                Subjects.Add(subjects);
            }
            sub_listBox.ItemsSource = stlist;
        }



        private void ad_btn_Click(object sender, RoutedEventArgs e)
        {
            App_Subjects app_Subjects = new App_Subjects();
            if (app_Subjects.ShowDialog() == true)
            {
                if (app_Subjects.NewSubjects != null)
                {
                    Subjects.Add(app_Subjects.NewSubjects);
                }
            }
            LoadSubjects();
        }
        private void dl_btn_Click(object sender, RoutedEventArgs e)
        {
            subjects selectedSub = sub_listBox.SelectedItem as subjects;
            if (selectedSub == null)
            {
                MessageBox.Show("Пожалуйста, выберите предмет для удаления.",
               "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (MessageBox.Show($"Вы действительно хотите удалить предмет {selectedSub.Name_sub}?",
                "Подтверждение удаления", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                db.RemoveFromSubjects(selectedSub.Id_subject);
                Subjects.Remove(selectedSub);
                MessageBox.Show("Предмет успешно удален.");

            }
            LoadSubjects();
        }
        private void sub_listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
