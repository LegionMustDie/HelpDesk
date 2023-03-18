using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HelpDesk.FolderClass
{
    internal class ClassMessageBox
    {
        public static void InfoMB (string Message)
        {
            MessageBox.Show(Message, "Все готово!", 
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static void ErrorMB(string Message)
        {
            MessageBox.Show(Message, "Что-то пошло не так...",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static bool QuestionMB(string Message)
        {
          return MessageBoxResult.Yes == MessageBox.Show(Message, "Хм... вы уверены? ",
                MessageBoxButton.YesNo, MessageBoxImage.Question);
        }

        public static void ExitMB()
        {
            bool Result = QuestionMB("Уже уходите?");
            if(Result==true) 
            {
                App.Current.Shutdown();
            }
        }
    }
}
