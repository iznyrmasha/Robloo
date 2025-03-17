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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sqlzlp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainframe.Navigate(new MainPage());
        }

        private void stud_btn_Click(object sender, RoutedEventArgs e)
        {
            mainframe.Navigate(new Student_Page());
        }

        private void teach_btn_Click(object sender, RoutedEventArgs e)
        {
            mainframe.Navigate(new Teachers_Page());
        }

        private void sub_btn_Click(object sender, RoutedEventArgs e)
        {
            mainframe.Navigate(new Subjects_Page());
        }

        private void mainframe_Navigated(object sender, NavigationEventArgs e)
        {

        }
        

    }
}
