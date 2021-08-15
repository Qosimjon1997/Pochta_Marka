using Pochta_Marka_Desktop.Services.Branch;
using Pochta_Marka_Desktop.Services.Employee;
using System;
using System.Windows;
using System.Windows.Input;

namespace Pochta_Marka_Desktop
{
    /// <summary>
    /// Interaction logic for EmployeeChangeWindow.xaml
    /// </summary>
    public partial class EmployeeChangeWindow : Window
    {
        private int _id;
        public EmployeeChangeWindow(int id)
        {
            InitializeComponent();
            _id = id;
        }

        IEmployeeService _employee = new EmployeeService();
        IBranchService _branch = new BranchService();
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtFIO.Focus();
            var v = await _branch.GetAll();
            foreach (BranchModel b in v)
            {
                combFilial.Items.Add(b.Id + "-" + b.BranchNumber);
            }
            var ef = await _employee.Get(_id);
            var t = await _branch.Get(ef.BranchId);
            txtFIO.Text = ef.FullName;
            txtLogin.Text = ef.Login;
            txtPassw.Text = ef.Passw;
            combFilial.SelectedItem = t.Id + "-" + t.BranchNumber;
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string[] t = combFilial.SelectedItem.ToString().Split("-");
            var res = await _employee.Update(_id, new EmployeeModel
            {
                FullName = txtFIO.Text,
                Login = txtLogin.Text,
                Passw = txtPassw.Text,
                Dostup = 2,
                BranchId = Convert.ToInt32(t[0])
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

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var v = await _employee.Delete(_id);
            if (v == true)
            {
                MessageBox.Show("Данные были успешно удалены!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Произошла ошибка!");
            }
        }
    }
}
