using HelpDesk.FolderClass;
using HelpDesk.FolderPage.Section;
using MaterialDesignThemes.Wpf;
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

namespace HelpDesk.FolderPage
{
    /// <summary>
    /// Логика взаимодействия для MainPageStaff.xaml
    /// </summary>
    public partial class MainPageStaff : Page
    {
        public MainPageStaff()
        {
            InitializeComponent();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ClassMessageBox.ExitMB();
        }

        private void btnAcc_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AccSection());
        }
    }
}
