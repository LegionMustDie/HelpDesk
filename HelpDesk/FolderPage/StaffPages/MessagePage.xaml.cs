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
using System.Net.Mail;
using HelpDesk.FolderClass;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Xml.Linq;

namespace HelpDesk.FolderPage.StaffPages
{
    /// <summary>
    /// Логика взаимодействия для MessagePage.xaml
    /// </summary>
    public partial class MessagePage : Page
    {
        public MessagePage()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            var ipsender = VariableClass.staff.Email;

            if (ipsender != null)
            {
                MailMessage message = new MailMessage(ipsender, tbAddress.Text);
                message.Subject = "ОТВЕТ ОТ ТЕХНИЧЕСКОЙ ПОДДЕРЖКИ";
                message.Body = tbText.Text;

                SmtpClient client = new SmtpClient("smtp.yandex.ru", 587);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(ipsender, "ivdwddzgxcgktnht");
              

                client.Send(message);
                ClassMessageBox.InfoMB("Сообщение отправлено.");
                NavigationService.GoBack();
            }



        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ClassMessageBox.ExitMB();
        }
    }
}
