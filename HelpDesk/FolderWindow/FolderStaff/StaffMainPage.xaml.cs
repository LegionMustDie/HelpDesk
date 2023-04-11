using HelpDesk.FolderClass;
using HelpDesk.FolderPage;
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

namespace HelpDesk.FolderWindow.FolderStaff
{
    /// <summary>
    /// Логика взаимодействия для StaffMainPage.xaml
    /// </summary>
    public partial class StaffMainPage : Window
    {
        public StaffMainPage(Page page)
        {
            InitializeComponent();
            MainFrame.Navigate(page);
        }

        public void CloseWin()
        {
            new AutorizationWindow().Show();
            Close();
        }
    }
}
