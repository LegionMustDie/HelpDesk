﻿using HelpDesk.FolderClass;
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
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ClassMessageBox.ExitMB();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void btnRecovery_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("C:\\Users\\thesk\\Downloads\\Диплом (1)\\Диплом\\Сайты\\html\\spravka.html");
        }

        private void btnSupport_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPostPage());
        }
    }
}
