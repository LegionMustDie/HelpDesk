using HelpDesk.FolderClass;
using HelpDesk.FolderData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HelpDesk.FolderWindow.FolderStaff;

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
            {
                ClassMessageBox.ErrorMB("Логин или пароль введены неверно");
            }    
                
            else if (string.IsNullOrEmpty(pbPassword.Password))
            {
                ClassMessageBox.ErrorMB("Логин или пароль введены неверно");
            }

            else
            {
                try
                {
                    var user = DBEntities.GetContext().User
                        .FirstOrDefault(u=> u.LogUser == tbLogin.Text &&
                        u.PasUser == pbPassword.Password);

                    if (user == null)
                    {
                        ClassMessageBox.ErrorMB("Логин или пароль введены неверно");
                    }

                    else if (user.PasUser != pbPassword.Password)
                    {
                        ClassMessageBox.ErrorMB("Логин или пароль введены неверно");
                    }

                    else
                    {
                        switch(user.IdRole)
                        {
                            case 1:
                                ClassMessageBox.InfoMB("Авторизован");
                                break;
                            case 2:
                                ClassMessageBox.InfoMB("Авторизован");
                                break;
                            case 3:
                               new StaffMainPage().Show();
                                Close();
                                break;

                        }
                    }
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
