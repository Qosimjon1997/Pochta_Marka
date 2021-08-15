using Pochta_Marka_Desktop.Services.Branch;
using System.Windows;

namespace Pochta_Marka_Desktop
{
    /// <summary>
    /// Interaction logic for BranchChangeWindow.xaml
    /// </summary>
    public partial class BranchChangeWindow : Window
    {
        private int _id;
        IBranchService _service = new BranchService();
        public BranchChangeWindow(int id)
        {
            InitializeComponent();
            _id = id;
        }
        
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var v = await _service.Get(_id);
            txtIndex.Text = v.BranchNumber;
            txtAddres.Text = v.BranchAddress;
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var res = await _service.Update(_id, new BranchModel
            {
                BranchAddress = txtAddres.Text,
                BranchNumber = txtIndex.Text
            });
            if(res == true)
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
