using Pochta_Marka_Desktop.Properties;
using Pochta_Marka_Desktop.Services.Employee;
using System;
using System.Windows;
using System.Windows.Input;

namespace Pochta_Marka_Desktop
{
    /// <summary>
    /// Interaction logic for ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        public ChangePasswordWindow()
        {
            InitializeComponent();
        }

        private void txtOK_Click(object sender, RoutedEventArgs e)
        {
            ClickEnter();
        }
        IEmployeeService _service = new EmployeeService();
        private async void ClickEnter()
        {
            try
            {
                var v = await _service.Get(Settings.Default.EmployeeId);
                if (v != null)
                {
                    if (txtNew1Passw.Password == txtNew2Passw.Password)
                    {
                        var res = await _service.Update(Settings.Default.EmployeeId, new EmployeeModel
                        {
                            FullName = v.FullName,
                            Login = v.Login,
                            Passw = txtNew1Passw.Password,
                            Dostup = v.Dostup,
                            BranchId = v.BranchId
                        });
                        if (res == true)
                        {
                            MessageBox.Show("Успешно обновлено!");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Произошла ошибка!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пароль неправильно");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error43");
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
            if(e.Key == Key.Return)
            {
                ClickEnter();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtOldPassw.Focus();
        }
    }
}
