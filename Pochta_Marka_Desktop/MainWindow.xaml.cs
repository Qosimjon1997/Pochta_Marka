using Pochta_Marka_Desktop.Properties;
using Pochta_Marka_Desktop.Services;
using Pochta_Marka_Desktop.Services.Branch;
using Pochta_Marka_Desktop.Services.Employee;
using Pochta_Marka_Desktop.Services.Product;
using Pochta_Marka_Desktop.Services.ProductType;
using Pochta_Marka_Desktop.Services.Sale;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Pochta_Marka_Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<Kassa> kassa = new List<Kassa>();
        List<SaleModel> saleModel = new List<SaleModel>();


        IEmployeeService service = new EmployeeService();
        IProductService _product = new ProductService();
        IProductTypeService _productType = new ProductTypeService();
        ISaleService _sale = new SaleService();

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var v = await service.Get(Settings.Default.EmployeeId);
            labEmployeeName.Text = v.FullName;
            labIndex.Text = v.BranchModel.BranchNumber;

            var prod = await _product.GetAll();
            foreach(ProductModel pp in prod)
            {
                Button newBtn = new Button();

                newBtn.Content = pp.ProductName;
                newBtn.Width = double.NaN;
                newBtn.Height = 70;
                newBtn.Margin = new Thickness(5);
                newBtn.Name = "btn" + pp.Id;
                newBtn.Click += myBtn_Click;
                sp.Children.Add(newBtn);
            }
            #region
            /*for (int i = 0; i < 5; i++)
            {
                Button newBtn = new Button();

                newBtn.Content = i.ToString();
                newBtn.Width = 70;
                newBtn.Height = 70;
                newBtn.Margin = new Thickness(5);
                newBtn.Name = "btn" + i.ToString();
                newBtn.Click += myBtn_Click;
                sp.Children.Add(newBtn);
            }*/
            #endregion
        }

        private int mySecId = 0;
        private async void myBtn_Click(object sender, RoutedEventArgs e)
        {
            sp2.Children.Clear();
            Button btn = (sender as Button);
            int l = btn.Name.Length;
            string ss = btn.Name.Substring(3);
            mySecId = Convert.ToInt32(ss);
            txtProductList.Text = btn.Content.ToString();

            var v = await _productType.GetAll();
            foreach(ProductTypeModel pp in v)
            {
                if(pp.ProductId == Convert.ToInt32(ss))
                {
                    Button myBtn = new Button();

                    myBtn.Content = pp.Name;
                    myBtn.Width = double.NaN;
                    myBtn.Height = 70;
                    myBtn.Margin = new Thickness(5);
                    myBtn.Name = "btn" + pp.Id;
                    myBtn.Click += mySecBtn_Click;
                    sp2.Children.Add(myBtn);
                }
            }

            #region
            /*for(int i=0;i<10;i++)
            {
                Button myBtn = new Button();

                myBtn.Content = btn.Content + i.ToString();
                myBtn.Width = 70;
                myBtn.Height = 70;
                myBtn.Margin = new Thickness(5);
                myBtn.Name = "btn" + i.ToString();
                myBtn.Click += mySecBtn_Click;
                sp2.Children.Add(myBtn);
            }*/
            #endregion

        }

        private async void mySecBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (sender as Button);
            int l = btn.Name.Length;
            string ss = btn.Name.Substring(3);
            var v = await _productType.Get(Convert.ToInt32(ss));
            Kassa k = new Kassa()
            {
                ProductId = mySecId,
                ProductTypeId = v.Id,
                myProduct = txtProductList.Text,
                myProductType = v.Name,
                mySoni = 1,
                mySumma = Convert.ToInt32(v.Price)
            };
            kassa.Add(k);

            
            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            decimal SUMMA=0;
            foreach(Kassa k in kassa)
            {
                SUMMA += k.mySumma;
            }
            DG_Kassa.ItemsSource = null;
            DG_Kassa.ItemsSource = kassa;
            labSumma.Text = SUMMA.ToString();


        }

        private void DG_Kassa_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (DG_Kassa.SelectedIndex >= 0)
            {
                Kassa t = DG_Kassa.SelectedItem as Kassa;
                if (t.mySoni > 0)
                {
                    kassa.Remove(t);
                    RefreshDataGrid();
                }
            }
        }

        private async void btnSale_Click(object sender, RoutedEventArgs e)
        {
            var v = await service.Get(Settings.Default.EmployeeId);
            var prodType = await _productType.GetAll();
            saleModel.Clear();
            foreach (Kassa k in kassa)
            {
                SaleModel m = new SaleModel()
                {
                    Soni = k.mySoni,
                    Summasi = k.mySumma,
                    SaleTime = DateTime.Now,
                    EmployeeId = Settings.Default.EmployeeId,
                    BranchId = v.BranchId,
                    ProductId = k.ProductId,
                    ProductTypeId = k.ProductTypeId
                };
                saleModel.Add(m);
            }
            IEnumerable<SaleModel> mm = saleModel;
            var t = await _sale.Post(mm);
            MessageBox.Show("Сохранено");
            kassa.Clear();
            RefreshDataGrid();
        }
        
    }
}
