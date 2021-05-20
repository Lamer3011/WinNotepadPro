/*
    Created by Sergiy Kireev
*/

using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using Microsoft.Win32;
using System.Windows.Media.Animation;
using System.Windows.Input;

namespace WinNotepadPro
{
    public partial class MainWindow : Window
    {
        private const string end_type = 
            "Text files (*.txt)|*.txt|" +
            "Arduino files (*.ino)|*.ino|"+
            "Ada files (*.ada)|*.ada|" +
            "C files (*.c)|*.c|" +
            "C# files (*.cs)|*.cs|" +
            "C++ files (*.cpp)|*.cpp|" +
            "CSS files (*.css)|*.css|" +
            "Dart files (*.dart)|*.dart|" +
            "Go files (*.go)|*.go|" +
            "HTML files (*.html, *.htm)|*.html, *.htm|" +
            "Java files (*.java)|*.java|" +
            "Javascript files (*.js)|*.js|" +
            "Kotlin files (*.kt, *.kts)|*.kt, *.kts|" +
            "NoteLog files (*.nlp)|*.nlp|" +
            "Lua files (*.lua)|*.lua|" +
            "PHP files (*.php)|*.php|" +
            "Python files (*.py, *.pyw)|*.py, *.pyw|" +
            "Perl files (*.pl, *.pm)|*.pl, *.pm|" +
            "R files (*.r)|*.r|" +
            "Ruby files (*.rb, *.rbw)|*.rb, *rbw|" +
            "Rust files (*.rs, .rlib)|*.rs, .rlib|" +
            "Scala files (*.scala)|*.scala|" +
            "Swift files (*.swift)|*.swift|" +
            "TypeScript files (*.ts)|*.ts|" +
            "All files (*.*)|*.*";

        public MainWindow()
        {
            InitializeComponent();
        }
        /*
         FILE OPTIONS
         */
        private void new_file_Click(object sender, RoutedEventArgs e)
        {
            //clear all
            this.Title = "Untitled - WinNotepad+";
            main_editor.Text = "";
        }

        private void open_file_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); // create open file
            openFileDialog.Filter = end_type; // filter of doc
            if (openFileDialog.ShowDialog() == true)
            {
                main_editor.Text = File.ReadAllText(openFileDialog.FileName); // open text
                this.Title = Path.GetFileName(openFileDialog.FileName + " - WinNotepad+"); // name file
            }
        }

        private void save_file_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog(); // save file
            saveFileDialog.Filter = end_type; // filter for save
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, main_editor.Text);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // close window
        }

        /*
        VIEW OPTIONS
        */
        private void light_theme_Click(object sender, RoutedEventArgs e)
        {
            hacker_theme.Header = "Hacker";
            light_theme.Header = "Light ✔";
            dark_theme.Header = "Dark";
            menu.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)); // menu color
            main_editor.Background = new SolidColorBrush(Color.FromArgb(255, 217, 204, 204));
            main_editor.FontFamily = new FontFamily("Arial"); // change font
            // Animation foreground
            SolidColorBrush main_editor_fg = new SolidColorBrush();
            main_editor.Foreground = main_editor_fg;

            ColorAnimation da = new ColorAnimation();
            da.To = Colors.Black;
            da.Duration = new Duration(TimeSpan.FromSeconds(0.25));
            main_editor_fg.BeginAnimation(SolidColorBrush.ColorProperty, da);
        }

        private void dark_theme_Click(object sender, RoutedEventArgs e)
        {
            hacker_theme.Header = "Hacker";
            light_theme.Header = "Light";
            dark_theme.Header = "Dark ✔";
            menu.Background = new SolidColorBrush(Color.FromArgb(255, 107, 107, 107)); // menu color
            main_editor.Background = new SolidColorBrush(Color.FromArgb(255, 66, 65, 65));
            main_editor.FontFamily = new FontFamily("Comic Sans MS"); // change font
            // Animation foreground
            SolidColorBrush main_editor_fg = new SolidColorBrush();
            main_editor.Foreground = main_editor_fg;

            ColorAnimation da = new ColorAnimation();
            da.To = Colors.DarkGray;
            da.Duration = new Duration(TimeSpan.FromSeconds(1.5));
            main_editor_fg.BeginAnimation(SolidColorBrush.ColorProperty, da);

        }

        private void hacker_theme_Click(object sender, RoutedEventArgs e)
        {
            hacker_theme.Header = "Hacker ✔";
            light_theme.Header = "Light";
            dark_theme.Header = "Dark"; 
            menu.Background = new SolidColorBrush(Color.FromArgb(255, 85, 125, 55)); // menu color
            main_editor.Background = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            main_editor.FontFamily = new FontFamily("Cambria"); // change font

            // Animation foreground
            SolidColorBrush main_editor_fg = new SolidColorBrush();
            main_editor.Foreground = main_editor_fg;

            ColorAnimation da = new ColorAnimation();
            da.To = Colors.ForestGreen;
            da.Duration = new Duration(TimeSpan.FromSeconds(0.5));
            main_editor_fg.BeginAnimation(SolidColorBrush.ColorProperty, da);
        }

        private void main_editor_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (Keyboard.Modifiers != ModifierKeys.Control) // if press ctrl
                return;

            if (e.Delta > 0)
                main_editor.FontSize++;

            else if (e.Delta < 0)
                main_editor.FontSize--;
        }

        // Hot keys?
        private void main_editor_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
           if (e.Key == System.Windows.Input.Key.Tab)  main_editor.Text += "   ";   // input TAB
        }

        // About window
        private void win_about_Click(object sender, RoutedEventArgs e)
        {
            About about_win = new About();
            about_win.Show();
        }
    }
}
