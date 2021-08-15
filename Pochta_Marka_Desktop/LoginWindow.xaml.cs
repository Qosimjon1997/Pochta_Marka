using Pochta_Marka_Desktop.Properties;
using Pochta_Marka_Desktop.Services.Employee;
using System.Windows;
using System.Windows.Input;

namespace Pochta_Marka_Desktop
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        IEmployeeService employeeService = new EmployeeService();

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtLogin.Focus();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            buttonEnter();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return)
            {
                buttonEnter();
            }
            if(e.Key == Key.Escape)
            {
                this.Close();
            }
        }
        private async void buttonEnter()
        {
            var v = await employeeService.GetByLoginPass(txtLogin.Text, txtPassw.Password);
            if(v==null)
            {
                MessageBox.Show("Login yoki Parol noto'g'ri kiritilgan!");
            }
            else if(v.Dostup == 1)
            {
                AdminWindow window = new AdminWindow();
                this.Hide();
                Settings.Default.EmployeeId = v.Id;
                Settings.Default.Save();
                window.ShowDialog();
                this.Show();
                txtLogin.Clear();
                txtPassw.Clear();
            }
            else if(v.Dostup == 2)
            {
                MainWindow window = new MainWindow();
                this.Hide();
                Settings.Default.EmployeeId = v.Id;
                Settings.Default.Save();
                window.ShowDialog();
                this.Show();
                txtLogin.Clear();
                txtPassw.Clear();
            }
            txtLogin.Focus();
        }

    }
}
