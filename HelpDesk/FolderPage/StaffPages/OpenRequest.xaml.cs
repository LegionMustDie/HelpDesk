using HelpDesk.FolderData;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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
using HelpDesk.FolderClass;
using System.Runtime.Remoting.Contexts;
using System.Globalization;

namespace HelpDesk.FolderPage.StaffPages
{
    /// <summary>
    /// Логика взаимодействия для OpenRequest.xaml
    /// </summary>
    public partial class OpenRequest : Page
    {
        
        public OpenRequest(RequestStaff req)
        {
            InitializeComponent();
            DataContext = req;
            ImageBtn.Click += (s, e) => OpenImage(req.ImageOne);
            ImageBtnTwo.Click += (s, e) => OpenImage(req.ImageTwo);
            ImageBtnThree.Click += (s, e) => OpenImage(req.ImageThree);
  
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void OpenImage(byte[] imageData)
        {
            var image = new BitmapImage();
            using (var ms = new MemoryStream(imageData))
            {
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
            }

            var window = new Window();
            window.WindowStyle = WindowStyle.None;
            window.Background = new ImageBrush(image);
            window.MouseDown += (sender, args) => window.Close();
            window.Show();
        }
    }
}
