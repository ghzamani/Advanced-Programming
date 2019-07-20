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
using System.Windows.Shapes;

namespace P1
{
    /// <summary>
    /// Interaction logic for First.xaml
    /// </summary>
    public partial class First : Window
    {
        public First()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
            MessageBox.Show("welcome " + user.Text + "!");
            if (string.IsNullOrEmpty(user.Text)) 
                mainWindow.username.Text = "user not specified";
            else  mainWindow.username.Text = "user : " + user.Text;
        }
        
    }
}
