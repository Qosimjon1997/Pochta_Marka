using Pochta_Marka_Desktop.Services.Product;
using Pochta_Marka_Desktop.Services.ProductType;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Pochta_Marka_Desktop.UserControllers
{
    /// <summary>
    /// Interaction logic for ProductTypeUC.xaml
    /// </summary>
    public partial class ProductTypeUC : UserControl
    {
        public ProductTypeUC()
        {
            InitializeComponent();
        }
        IProductTypeService _service = new ProductTypeService();
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
                ProductTypeModel t = DG.SelectedItem as ProductTypeModel;
                if (t.Id > 0)
                {
                    ProductTypeChangeWindow tc = new ProductTypeChangeWindow(t.Id);
                    tc.ShowDialog();
                    Refresh();
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ProductTypeAddWindow window = new ProductTypeAddWindow();
            window.ShowDialog();
            Refresh();
        }
    }
}
