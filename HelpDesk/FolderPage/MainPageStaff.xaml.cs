using HelpDesk.FolderClass;
using HelpDesk.FolderData;
using HelpDesk.FolderPage.Section;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Xml.Linq;

namespace HelpDesk.FolderPage
{
    /// <summary>
    /// Логика взаимодействия для MainPageStaff.xaml
    /// </summary>
    public partial class MainPageStaff : Page
    {
        public int i = 0;
        
        public MainPageStaff()
        {
            InitializeComponent();
            tbSearch.ItemsSource = DBEntities.GetContext().SearchHelp.ToList();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ClassMessageBox.ExitMB();
        }

        private void btnAcc_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AccSection());
        }

        private void tbSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tbSearch.SelectedItem != null)
            {
                var item = tbSearch.SelectedItem as SearchHelp;

                switch (item.IdObject)
                {
                    case 1:
                        NavigationService.Navigate(new AccSection());
                        break;
                    case 8:
                        Process.Start("C:\\Users\\thesk\\Desktop\\Проекты\\Проекты C#\\Диплом\\Сайты\\html\\spravka.html");
                        break;
                    default:
                        ClassMessageBox.InfoMB("Страница в разработке");
                        break;
                }
            }
        }

        private void tbSearch_TextInput(object sender, TextCompositionEventArgs e)
        {
            var searchValue = tbSearch.Text.ToLower();

            var categories = DBEntities.GetContext().SearchHelp.Where(c => c.Name.ToLower().Contains(searchValue)).ToList();

            if (categories != null && categories.Count > 0)
            {
                tbSearch.ItemsSource = categories;
            }
            else
            {
                tbSearch.ItemsSource = DBEntities.GetContext().SearchHelp.ToList();
            }
        }
    }
}
