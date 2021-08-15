using Pochta_Marka_Desktop.Services.Branch;
using Pochta_Marka_Desktop.Services.Employee;
using System;
using System.Windows;
using System.Windows.Input;

namespace Pochta_Marka_Desktop
{
    /// <summary>
    /// Interaction logic for EmployeeAddWindow.xaml
    /// </summary>
    public partial class EmployeeAddWindow : Window
    {
        public EmployeeAddWindow()
        {
            InitializeComponent();
        }

        IEmployeeService _employee = new EmployeeService();
        IBranchService _branch = new BranchService();

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtFIO.Focus();
            var v = await _branch.GetAll();
            foreach(BranchModel b in v)
            {
                combFilial.Items.Add(b.Id + "-" + b.BranchNumber);
            }
            combFilial.SelectedIndex = 0;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string[] t = combFilial.SelectedItem.ToString().Split("-");
            EmployeeModel model = new EmployeeModel()
            {
                FullName = txtFIO.Text,
                Login = txtLogin.Text,
                Passw = txtPassw.Text,
                Dostup = 2,
                BranchId = Convert.ToInt32(t[0])
            };
            bool v = await _employee.Post(model);
            if (v == true)
            {
                MessageBox.Show("Успешно добавлено!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Произошла ошибка");
            }
        }
    }
}
