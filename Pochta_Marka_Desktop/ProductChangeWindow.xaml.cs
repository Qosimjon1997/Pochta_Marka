using Pochta_Marka_Desktop.Services.Product;
using System.Windows;

namespace Pochta_Marka_Desktop
{
    /// <summary>
    /// Interaction logic for ProductChangeWindow.xaml
    /// </summary>
    public partial class ProductChangeWindow : Window
    {
        private int _id;
        public ProductChangeWindow(int id)
        {
            InitializeComponent();
            _id = id;
        }

        IProductService _service = new ProductService();
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var v = await _service.Get(_id);
            txtName.Text = v.ProductName;
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var res = await _service.Update(_id, new ProductModel
            {
                ProductName = txtName.Text
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
            var v = await _service.Delete(_id);
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
