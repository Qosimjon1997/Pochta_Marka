using Pochta_Marka_Desktop.Services.Product;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Pochta_Marka_Desktop.UserControllers
{
    /// <summary>
    /// Interaction logic for ProductUC.xaml
    /// </summary>
    public partial class ProductUC : UserControl
    {
        public ProductUC()
        {
            InitializeComponent();
        }

        IProductService _service = new ProductService();
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
                MessageBox.Show(ex.ToString());
            }
        }

        private void DG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DG.SelectedIndex >= 0)
            {
                ProductModel t = DG.SelectedItem as ProductModel;
                if (t.Id > 0)
                {
                    ProductChangeWindow tc = new ProductChangeWindow(t.Id);
                    tc.ShowDialog();
                    Refresh();
                }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            ProductAddWindow window = new ProductAddWindow();
            window.ShowDialog();
            Refresh();

        }
    }
}
