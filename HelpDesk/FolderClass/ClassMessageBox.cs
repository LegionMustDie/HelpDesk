using HelpDesk.FolderWindow.FolderMB;
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
            new InfoWindow(Message).ShowDialog();
        }

        public static void ErrorMB(string Message)
        {
            new ErrorWindow(Message).ShowDialog();
        }

        public static bool QuestionMB(string Message)
        {
          new QuestionWindow(Message).ShowDialog();
            return VariableClass.IsAccepted;
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
