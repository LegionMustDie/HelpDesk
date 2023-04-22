using HelpDesk.FolderClass;
using HelpDesk.FolderData;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace HelpDesk.FolderPage.Section
{
    /// <summary>
    /// Логика взаимодействия для AccessSection.xaml
    /// </summary>
    public partial class AccessSection : Page
    {
        MainPageStaff mainPageStaff = new MainPageStaff();
        public AccessSection()
        {
            InitializeComponent();
            tbSearch.ItemsSource = DBEntities.GetContext().SearchHelp.ToList();
            btnArchive.Click += (s, e) => mainPageStaff.InProgreccMessage();
            btnSite.Click += (s, e) => mainPageStaff.InProgreccMessage();
            btnDoc.Click += (s, e) => mainPageStaff.InProgreccMessage();
            btnSystem.Click += (s, e) => mainPageStaff.InProgreccMessage();
            btnOther.Click += (s, e) => mainPageStaff.InProgreccMessage();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ClassMessageBox.ExitMB();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
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
                    case 3:
                        NavigationService.Navigate(new AccessSection());
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

        private async void tbSearch_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void btnSupport_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPostPage());
        }
    }
}
