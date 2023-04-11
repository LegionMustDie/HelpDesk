using HelpDesk.FolderClass;
using HelpDesk.FolderData;
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

namespace HelpDesk.FolderPage.Section
{
    /// <summary>
    /// Логика взаимодействия для AccSection.xaml
    /// </summary>
    public partial class AccSection : Page
    {
        public AccSection()
        {
            InitializeComponent();
            tbSearch.ItemsSource = DBEntities.GetContext().SearchHelp.ToList();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ClassMessageBox.ExitMB();
        }

        private void btnRecovery_Click(object sender, RoutedEventArgs e)
        {
            SiteOppener();
        }

        public void SiteOppener()
        {
            var path =
                System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FolderSite", "html", "spravka.html");
            var process = new Process();
            process.StartInfo.FileName = path;
            process.Start();
        }

        private void btnSupport_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPostPage());
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
                        SiteOppener();
                        break;
                    default:
                        ClassMessageBox.InfoMB("Страница в разработке");
                        break;
                }
            }
        }

        private void tbSearch_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
