using System;
using System.Windows;

namespace WinNotepadPro
{
    /// <summary>
    /// Логика взаимодействия для About.xaml
    /// </summary>
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
            name_comp.Content = Environment.MachineName;
        }
    }
}
