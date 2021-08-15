using Pochta_Marka_Desktop.Services.Employee;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Pochta_Marka_Desktop.UserControllers
{
    /// <summary>
    /// Interaction logic for EmployeeUC.xaml
    /// </summary>
    public partial class EmployeeUC : UserControl
    {
        public EmployeeUC()
        {
            InitializeComponent();
        }

        IEmployeeService _service = new EmployeeService();
        private async void Refresh()
        {
            try
            {
                var v = await _service.GetAll();
                DG.ItemsSource = null;
                DG.ItemsSource = v;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error9");
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void DG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DG.SelectedIndex >= 0)
            {
                EmployeeModel t = DG.SelectedItem as EmployeeModel;
                if (t.Id > 0)
                {
                    if(t.Dostup != 1)
                    {
                        EmployeeChangeWindow tc = new EmployeeChangeWindow(t.Id);
                        tc.ShowDialog();
                        Refresh();
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            EmployeeAddWindow window = new EmployeeAddWindow();
            window.ShowDialog();
            Refresh();
        }
    }
}
