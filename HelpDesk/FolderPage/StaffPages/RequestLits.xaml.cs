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

        private void LoadData()
        {
            var query = DBEntities.GetContext().RequestStaff.Where(x => x.IdStatus == 1 ||
            x.IdStatus == 2).OrderBy(x => x.IdRequest);

            pageCount = (int)Math.Ceiling((double)query.Count() / pageSize);

            if (pageNumber >= pageCount - 1)
            {
                pageNumber = pageCount - 1;
                btnNext.IsEnabled = false;
            }
            else
            {
                btnNext.IsEnabled = true;
            }

            if (pageNumber == 0)
            {
                btnBack.IsEnabled = false;
            }
            else
            {
                btnBack.IsEnabled = true;
            }

            var data = query
                .Skip(pageNumber * pageSize)
                .Take(pageSize)
                .ToList();

            dgRequest.ItemsSource = data;
        }

        private void AnotherLoadData()
        {
            var query = DBEntities.GetContext().RequestStaff.OrderBy(x => x.IdRequest);
            pageCount = (int)Math.Ceiling((double)query.Count() / pageSize);
            if (pageNumber >= pageCount - 1)
            {
                pageNumber = pageCount - 1;
                btnNext.IsEnabled = false;
            }
            else
            {
                btnNext.IsEnabled = true;
            }
            if (pageNumber == 0)
            {
                btnBack.IsEnabled = false;
            }
            else
            {
                btnBack.IsEnabled = true;
            }
            var data = query.Skip(pageNumber * pageSize).Take(pageSize).ToList();
            dgRequest.ItemsSource = data;
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

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = app.Workbooks.Add();
            Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.ActiveSheet;
            worksheet.Name = "Отчет";
            for (int i = 0; i < dgRequest.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1] = dgRequest.Columns[i].Header;
            }
            // Заполнение данными таблицы
            for (int i = 0; i < dgRequest.Items.Count; i++)
            {
                // Получение строки данных таблицы
                DataGridRow dataGridRow = dgRequest.ItemContainerGenerator.ContainerFromIndex(i) as DataGridRow;

                // Получение данных из столбцов
                for (int j = 0; j < dgRequest.Columns.Count; j++)
                {
                    TextBlock textBlock = dgRequest.Columns[j].GetCellContent(dataGridRow) as TextBlock;
                    worksheet.Cells[i + 2, j + 1] = textBlock.Text;
                }
            }

            // Сохранение и закрытие Excel
            string fileName = "Отчет_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".xlsx";
            workbook.SaveAs(fileName);
            app.Quit();

            // Освобождение объектов Excel
            releaseObject(worksheet);
            releaseObject(workbook);
            releaseObject(app);

            ClassMessageBox.InfoMB("Экспорт данных таблицы DataGrid выполнен успешно.");
        }

        private void btnNews_Click(object sender, RoutedEventArgs e)
        {

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

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Не удалось освободить объект Excel : " + ex.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                GC.Collect();
            }
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