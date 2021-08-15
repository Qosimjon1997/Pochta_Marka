using Pochta_Marka_Desktop.Services.Product;
using System;
using System.Windows;
using System.Windows.Input;

namespace Pochta_Marka_Desktop
{
    /// <summary>
    /// Interaction logic for ProductAddWindow.xaml
    /// </summary>
    public partial class ProductAddWindow : Window
    {
        public ProductAddWindow()
        {
            InitializeComponent();
        }
        IProductService _service = new ProductService();
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ClickEnter();
        }

        private async void ClickEnter()
        {
            try
            {
                ProductModel model = new ProductModel()
                {
                    ProductName = txtName.Text
                };

                bool res = await _service.Post(model);
                if (res == true)
                {
                    MessageBox.Show("Сохранено");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Произошла ошибка!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtName.Focus();
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                ClickEnter();
            }
        }
    }
}
