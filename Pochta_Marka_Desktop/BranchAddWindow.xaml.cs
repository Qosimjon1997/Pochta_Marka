using Pochta_Marka_Desktop.Services.Branch;
using System;
using System.Windows;
using System.Windows.Input;

namespace Pochta_Marka_Desktop
{
    /// <summary>
    /// Interaction logic for BranchAddWindow.xaml
    /// </summary>
    public partial class BranchAddWindow : Window
    {
        public BranchAddWindow()
        {
            InitializeComponent();
        }

        IBranchService _service = new BranchService();

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ClickEnter();
        }

        private async void ClickEnter()
        {
            try
            {
                BranchModel model = new BranchModel()
                {
                    BranchNumber = txtIndex.Text,
                    BranchAddress = txtAddres.Text
                };

                bool res = await _service.Post(model);
                if(res == true)
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
            txtIndex.Focus();
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.Return)
            {
                ClickEnter();
            }
        }
    }
}
