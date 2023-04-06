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
using HelpDesk.FolderPage.StaffPages;
using HelpDesk.FolderPage;

namespace HelpDesk.FolderWindow
{
    /// <summary>
    /// Логика взаимодействия для AutorizationWindow.xaml
    /// </summary>
    public partial class AutorizationWindow : Window
    {

        private int wrongCounts = 0;
        private int sum = 15000;
        private int extraTime = 20000;

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

            if (wrongCounts > 3)
            {
                sum += extraTime;
                BlockSystem();
                return;
            }

            if (wrongCounts == 3)
            {
                wrongCounts++;
                BlockSystem();
                return;
            }

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
                        wrongCounts++;
                    }

                    else if (user.PasUser != pbPassword.Password)
                    {
                        ClassMessageBox.ErrorMB("Логин или пароль введены неверно");
                        wrongCounts++;
                    }

                    else
                    {
                        switch(user.IdRole)
                        {
                            case 1:
                                VariableClass.IdUser = user.IdUser;
                                VariableClass.staff = DBEntities.GetContext().Staff.FirstOrDefault(c => c.IdUser == user.IdUser);
                                new StaffMainPage(new RequestLits()).Show();
                                Close();
                                break;
                            case 2:
                                VariableClass.IdUser = user.IdUser;
                                VariableClass.staff = DBEntities.GetContext().Staff.FirstOrDefault(c => c.IdUser == user.IdUser);
                                new StaffMainPage(new RequestLits()).Show();
                                Close();
                                break;
                            case 3:
                                VariableClass.IdUser = user.IdUser;
                                VariableClass.staff = DBEntities.GetContext().Staff.FirstOrDefault(c => c.IdUser == user.IdUser);
                                new StaffMainPage(new MainPageStaff()).Show();
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

       private void BlockSystem()
       {
               ClassMessageBox.ErrorMB($"Система заблокирована на {sum / 1000} секунд!");
               Thread.Sleep(sum);
               ClassMessageBox.InfoMB("Система разрблокирована, но в случае повторной ошибки данных будет вновь заблокирована!");
       }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            ClassMessageBox.ExitMB();
        }
    }
}
