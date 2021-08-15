using Pochta_Marka_Desktop.Services.Branch;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Pochta_Marka_Desktop.UserControllers
{
    /// <summary>
    /// Interaction logic for BranchUC.xaml
    /// </summary>
    public partial class BranchUC : UserControl
    {
        IBranchService _service = new BranchService();
        public BranchUC()
        {
            InitializeComponent();
        }

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
                BranchModel t = DG.SelectedItem as BranchModel;
                if (t.Id > 0)
                {
                    BranchChangeWindow tc = new BranchChangeWindow(t.Id);
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

            BranchAddWindow window = new BranchAddWindow();
            window.ShowDialog();
            Refresh();

        }
    }
}
