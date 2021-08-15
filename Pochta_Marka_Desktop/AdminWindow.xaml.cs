using Pochta_Marka_Desktop.UserControllers;
using System.Windows;

namespace Pochta_Marka_Desktop
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void btnBranch_Click(object sender, RoutedEventArgs e)
        {
            BranchUC obj = new BranchUC();
            gridForUC.Children.Clear();
            gridForUC.Children.Add(obj);
        }

        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeUC obj = new EmployeeUC();
            gridForUC.Children.Clear();
            gridForUC.Children.Add(obj);
        }

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductUC obj = new ProductUC();
            gridForUC.Children.Clear();
            gridForUC.Children.Add(obj);
        }

        private void btnProductType_Click(object sender, RoutedEventArgs e)
        {
            ProductTypeUC obj = new ProductTypeUC();
            gridForUC.Children.Clear();
            gridForUC.Children.Add(obj);
        }

        private void btnSale_Click(object sender, RoutedEventArgs e)
        {
            SaleUC obj = new SaleUC();
            gridForUC.Children.Clear();
            gridForUC.Children.Add(obj);
        }

        private void btnChangePassw_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordWindow window = new ChangePasswordWindow();
            window.ShowDialog();
        }
    }
}
