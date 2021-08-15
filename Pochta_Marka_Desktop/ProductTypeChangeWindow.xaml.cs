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
    /// Interaction logic for ProductTypeChangeWindow.xaml
    /// </summary>
    public partial class ProductTypeChangeWindow : Window
    {
        private int _id;

        public ProductTypeChangeWindow(int id)
        {
            InitializeComponent();
            _id = id;
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
            var ef = await _productType.Get(_id);
            var t = await _product.Get(ef.ProductId);
            txtName.Text = ef.Name;
            txtPrice.Text = (Convert.ToInt32(ef.Price)).ToString();
            combProduct.SelectedItem = t.Id + "-" + t.ProductName;
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string[] t = combProduct.SelectedItem.ToString().Split("-");
            var res = await _productType.Update(_id, new ProductTypeModel
            {
                Name = txtName.Text,
                Price = Convert.ToDecimal(txtPrice.Text),
                ProductId = Convert.ToInt32(t[0])
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
            var v = await _productType.Delete(_id);
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

        private void txtPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^\d+$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }
    }
}
