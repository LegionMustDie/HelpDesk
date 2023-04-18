using HelpDesk.FolderClass;
using HelpDesk.FolderData;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlTypes;
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
using Microsoft.Win32;
using System.Runtime.Remoting.Contexts;
using System.Diagnostics;

namespace HelpDesk.FolderPage.StaffPages
{
    /// <summary>
    /// Логика взаимодействия для RequestLits.xaml
    /// </summary>
    public partial class RequestLits : Page
    {
        int pageNumber = 0;
        int pageSize = 10;
        int pageCount;
        public RequestLits()
        {
            InitializeComponent();
            LiveList();
            StelsButton();
        }

        private void dgRequest_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            RequestStaff req = dgRequest.SelectedItem as RequestStaff;
            if (req != null)
            {
                NavigationService.Navigate(new OpenRequest(req));
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            pageNumber++;
            LiveList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (pageNumber > 0)
            {
                pageNumber--;
                LiveList();
            }
        }

        private async void LoadData()
        {
            await Task.Run(() =>
            {
                var query = DBEntities.GetContext().RequestStaff.Where(x => x.IdStatus == 1 ||
                x.IdStatus == 2).OrderBy(x => x.IdRequest);

                pageCount = (int)Math.Ceiling((double)query.Count() / pageSize);

                Dispatcher.Invoke(() =>
                {
                    if (pageNumber >= pageCount - 1)
                    {
                        pageNumber = pageCount - 1;
                        btnNext.IsEnabled = false;
                    }
                    else
                    {
                        btnNext.IsEnabled = true;
                    }
                });
                
                Dispatcher.Invoke(() =>
                {
                    if (pageNumber == 0)
                    {
                        btnBack.IsEnabled = false;
                    }
                    else
                    {
                        btnBack.IsEnabled = true;
                    }
                });

                var data = query
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize)
                    .ToList();

                Dispatcher.Invoke(() =>
                {
                    dgRequest.ItemsSource = data;
                });
            });
        }

        private async void AnotherLoadData()
        {
            await Task.Run(() =>
            {
                var query = DBEntities.GetContext().RequestStaff.OrderBy(x => x.IdRequest);

                pageCount = (int)Math.Ceiling((double)query.Count() / pageSize);

                Dispatcher.Invoke(() =>
                {
                    if (pageNumber >= pageCount - 1)
                    {
                        pageNumber = pageCount - 1;
                        btnNext.IsEnabled = false;
                    }
                    else
                    {
                        btnNext.IsEnabled = true;
                    }
                });

                Dispatcher.Invoke(() =>
                {
                    if (pageNumber == 0)
                    {
                        btnBack.IsEnabled = false;
                    }
                    else
                    {
                        btnBack.IsEnabled = true;
                    }
                });

                var data = query
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize)
                    .ToList();

                Dispatcher.Invoke(() =>
                {
                    dgRequest.ItemsSource = data;
                });
            });
        }

        private void LiveList()
        {
            switch(VariableClass.staff.User.IdRole)
            {
                case 1:
                    AnotherLoadData();
                    break;
                case 2:
                    LoadData();
                    break;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ClassMessageBox.ExitMB();
        }

        private async void btnExport_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = app.Workbooks.Add();
            Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.ActiveSheet;
            var data = await DBEntities.GetContext().RequestStaff.ToListAsync();
            app.Visible = true;
            
            // Заполняем заголовки столбцов
            worksheet.Cells[1, 1] = "Номер заявки";
            worksheet.Cells[1, 2] = "Категория";
            worksheet.Cells[1, 3] = "Отправитель";
            worksheet.Cells[1, 4] = "Статус";

            // Заполняем данные
            for (int i = 0; i < data.Count; i++)
            {
                worksheet.Cells[i + 2, 1] = data[i].IdRequest;
                worksheet.Cells[i + 2, 2] = data[i].Category.NameCategory;
                worksheet.Cells[i + 2, 3] = data[i].Staff.Email;
                worksheet.Cells[i + 2, 4] = data[i].Status.NameStatus;
            }

            // Сохраняем книгу Excel
            workbook.SaveAs("Отчет.xlsx");

            // Закрываем книгу и приложение Excel
            workbook.Close();
            app.Quit();
            ClassMessageBox.InfoMB("Отчет готов.");
        }

        private void btnNews_Click(object sender, RoutedEventArgs e)
        {
            var path =
                System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FolderSite", "html", "actuallyerrors.html");
            var process = new Process();
            process.StartInfo.FileName = path;
            process.Start();
        }

        private void btnMessage_Click(object sender, RoutedEventArgs e)
        {
            VariableClass.protectthis = 0;
            NavigationService.Navigate(new MessagePage());
        }

        private void btnReboot_Click(object sender, RoutedEventArgs e)
        {
            LiveList();
        }

        private void StelsButton()
        {
            var userRole = VariableClass.staff;
            switch ((userRole.IdStaff))
            {
                case 2:
                    btnExport.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    btnExport.Visibility = Visibility.Visible;
                    break;

            }
        }
    }
}