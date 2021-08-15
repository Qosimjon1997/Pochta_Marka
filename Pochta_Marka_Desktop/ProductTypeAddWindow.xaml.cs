using Pochta_Marka_Desktop.Services.Product;
using Pochta_Marka_Desktop.Services.ProductType;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Pochta_Marka_Desktop
{
    /// <summary>
    /// Interaction logic for ProductTypeAddWindow.xaml
    /// </summary>
    public partial class ProductTypeAddWindow : Window
    {
        public ProductTypeAddWindow()
        {
            InitializeComponent();
        }

        IProductTypeService _productType = new ProductTypeService();
        IProductService _product = new ProductService();

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtName.Focus();
            var v = await _product.GetAll();
            foreach (ProductModel b in v)
            {
                combProduct.Items.Add(b.Id + "-" + b.ProductName);
            }
            combProduct.SelectedIndex = 0;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string[] t = combProduct.SelectedItem.ToString().Split("-");
            ProductTypeModel model = new ProductTypeModel()
            {
                Name = txtName.Text,
                Price = Convert.ToDecimal(txtPrice.Text),
                ProductId = Convert.ToInt32(t[0])
            };
            bool v = await _productType.Post(model);
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

        private void txtPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^\d+$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }
    }
}
