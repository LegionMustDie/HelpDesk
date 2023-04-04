using HelpDesk.FolderClass;
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

namespace HelpDesk.FolderWindow.FolderMB
{
    /// <summary>
    /// Логика взаимодействия для QuestionWindow.xaml
    /// </summary>
    public partial class QuestionWindow : Window
    {
        public QuestionWindow(string question)
        {
            InitializeComponent();
            QuestionTbl.Text= question;
        }

        private void YesBtn_Click(object sender, RoutedEventArgs e)
        {
            VariableClass.IsAccepted = true;
            Close();
        }

        private void noBtn_Click(object sender, RoutedEventArgs e)
        {
            VariableClass.IsAccepted = false;
            Close();
        }
    }
}
