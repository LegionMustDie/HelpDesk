using HelpDesk.FolderClass;
using HelpDesk.FolderData;
using HelpDesk.FolderPage.Section;
using HelpDesk.FolderWindow;
using HelpDesk.FolderWindow.FolderStaff;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
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

        public MainPageStaff()
        {
            InitializeComponent();
            tbSearch.ItemsSource = DBEntities.GetContext().SearchHelp.ToList();
            btnAccess.Click += (s, e) => InProgreccMessage();
            btnSoftware.Click += (s, e) => InProgreccMessage();
            btnProduct.Click += (s, e) => InProgreccMessage();
            btnDoc.Click += (s, e) => InProgreccMessage();
            btnOther.Click += (s, e) => InProgreccMessage();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ClassMessageBox.ExitMB();
        }

        private void btnAcc_Click(object sender, RoutedEventArgs e)
        {
            VariableClass.IdCategory = 1;
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
                    case 2:
                        NavigationService.Navigate(new DeviceSection());
                        break;
                    case 8:
                        AccSection acc = new AccSection();
                        acc.SiteOppener();
                        break;
                    default:
                        ClassMessageBox.InfoMB("Страница в разработке");
                        break;
                }
            }
        }

        private async void tbSearch_TextInput(object sender, TextCompositionEventArgs e)
        {
            var searchValue = tbSearch.Text.ToLower();

            var categories = await DBEntities.GetContext().SearchHelp.Where(c => c.Name.ToLower().Contains(searchValue)).ToListAsync();

            if (categories != null && categories.Count > 0)
            {
                tbSearch.ItemsSource = categories;
            }
            else
            {
                tbSearch.ItemsSource = await DBEntities.GetContext().SearchHelp.ToListAsync();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            bool Result = ClassMessageBox.QuestionMB("Уже уходите?");
            if (Result == true)
            {
                StaffMainPage mainPage = (StaffMainPage)Window.GetWindow(this);
                mainPage.CloseWin();
            }
        }

        public void InProgreccMessage()
        {
            ClassMessageBox.InfoMB("Данный модуль в разработке");
        }

        private void btnDevice_Click(object sender, RoutedEventArgs e)
        {
            VariableClass.IdCategory = 2;
            NavigationService.Navigate(new DeviceSection());
        }
    }
}
