using HelpDesk.FolderClass;
using HelpDesk.FolderData;
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

namespace HelpDesk.FolderWindow
{
    /// <summary>
    /// Логика взаимодействия для AutorizationWindow.xaml
    /// </summary>
    public partial class AutorizationWindow : Window
    {
        public AutorizationWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ClassMessageBox.ExitMB();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbLogin.Text))
                ClassMessageBox.ErrorMB("Логин или пароль введены неверно");
            if (string.IsNullOrEmpty(pbPassword.Password))
                ClassMessageBox.ErrorMB("Логин или пароль введены неверно");
            else
            {
                try
                {
                    var user = DBEntities.GC.User
                }
                catch (Exception ex)
                {
                    ClassMessageBox.ErrorMB(ex.Message);
                }
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            ClassMessageBox.ExitMB();
        }
    }
}
