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
    /// Логика взаимодействия для Del_Studens.xaml
    /// </summary>
    public partial class Del_Studens : Window
    {
        public Del_Studens()
        {
            InitializeComponent();
            LoadGroupsIntoComboBox();
        }
        DataBase db = new DataBase();
        public students NewStudents { get; private set; }

        private void LoadGroupsIntoComboBox()
        {

        }
    }
}