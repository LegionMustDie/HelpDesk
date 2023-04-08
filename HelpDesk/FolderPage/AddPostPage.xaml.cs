using HelpDesk.FolderClass;
using HelpDesk.FolderData;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
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

namespace HelpDesk.FolderPage
{
    /// <summary>
    /// Логика взаимодействия для AddPostPage.xaml
    /// </summary>
    public partial class AddPostPage : Page
    {
        private byte[] _imageBytes = null;
        private byte[] imageBytesForPhoto2 = null;
        private byte[] imageBytesForPhoto3 = null;
        public AddPostPage()
        {
            InitializeComponent();
            cbSection.ItemsSource = DBEntities.GetContext().Category.ToList();
            ImageBtn.Visibility = Visibility.Visible;
            cbLoader();
        }

        private void ImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.InitialDirectory = "";
            op.Filter = "All suported graphics |*.jpg;*.jpeg;*.png";
            if (op.ShowDialog() == true)
            {
                var bitmapImage = new BitmapImage(new Uri(op.FileName));
                PhotoStaff.Source = bitmapImage;
                _imageBytes = File.ReadAllBytes(op.FileName);
            }
            ImageTwo.Visibility = Visibility.Visible;
            ImageBtnTwo.Visibility = Visibility.Visible;
        }

        

        private void ImageBtnTwo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.InitialDirectory = "";
            op.Filter = "All suported graphics |*.jpg;*.jpeg;*.png";
            if (op.ShowDialog() == true)
            {
                var bitmapImage = new BitmapImage(new Uri(op.FileName));
                PhotoStaffTwo.Source = bitmapImage;
                imageBytesForPhoto2 = File.ReadAllBytes(op.FileName);
            }
            ImageThree.Visibility = Visibility.Visible;
            ImageBtnThree.Visibility = Visibility.Visible;
        }

        private void ImageBtnThree_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.InitialDirectory = "";
            op.Filter = "All suported graphics |*.jpg;*.jpeg;*.png";
            if (op.ShowDialog() == true)
            {
                var bitmapImage = new BitmapImage(new Uri(op.FileName));
                PhotoStaffThree.Source = bitmapImage;
                imageBytesForPhoto3 = File.ReadAllBytes(op.FileName);
            }
        }

        private void cbLoader()
        {
            switch(VariableClass.IdCategory)
            {
                case 1:
                    cbSection.SelectedIndex = 0;
                    break;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInputs(tbText))
            {
                try
                {
                    RequestStaff request = new RequestStaff()
                    {
                        IdCategory = VariableClass.IdCategory,
                        IdStaff = VariableClass.staff.IdStaff,
                        TextRequest = tbText.Text,
                        IdStatus = 1,
                        ImageOne = _imageBytes,
                        ImageTwo = imageBytesForPhoto2,
                        ImageThree = imageBytesForPhoto3,
                    };
                    DBEntities.GetContext().RequestStaff.Add(request);
                    DBEntities.GetContext().SaveChanges();
                    ClassMessageBox.InfoMB("Запрос был отправлен поддержке. " +
                        "Ответ придет в скором времени на почту.");
                    NavigationService.GoBack();
                }
                catch (Exception ex)
                {
                    ClassMessageBox.ErrorMB(ex.Message);
                    tbText.Focus();
                }
            }
        }

        private bool CheckInputs(params TextBox[] inputs)
        {
            foreach (TextBox textBox in inputs)
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    textBox.Focus();
                    return false;
                }
            }
            return true;
        }


        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ClassMessageBox.ExitMB();
        }

    }
}
