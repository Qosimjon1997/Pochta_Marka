using Pochta_Marka_Desktop.Services.Branch;
using Pochta_Marka_Desktop.Services.Employee;
using Pochta_Marka_Desktop.Services.Product;
using Pochta_Marka_Desktop.Services.ProductType;
using Pochta_Marka_Desktop.Services.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Pochta_Marka_Desktop.UserControllers
{
    /// <summary>
    /// Interaction logic for SaleUC.xaml
    /// </summary>
    public partial class SaleUC : UserControl
    {
        public SaleUC()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            date1.SelectedDate = DateTime.Today;
            date2.SelectedDate = DateTime.Today;
        }

        IBranchService _branch = new BranchService();
        IEmployeeService _employee = new EmployeeService();
        ISaleService _sale = new SaleService();
        IProductService _product = new ProductService();
        IProductTypeService _productType = new ProductTypeService();
        List<SaleModelcha> modelcha = new List<SaleModelcha>();
        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (date1.SelectedDate != null && date2.SelectedDate != null)
            {
                try
                {
                    DateTime second = new DateTime(Convert.ToInt32(date2.SelectedDate.Value.ToString("yyyy")), Convert.ToInt32(date2.SelectedDate.Value.ToString("MM")), Convert.ToInt32(date2.SelectedDate.Value.ToString("dd")), 23, 59, 59);
                    
                    var _mySale = await _sale.GetAll();
                    var _myProduct = await _product.GetAll();
                    var _myProductType = await _productType.GetAll();
                    var _myEmployee = await _employee.GetAll();
                    var _myBranch = await _branch.GetAll();

                    List<BranchModel> mB = Enumerable.ToList(_myBranch);
                    List<EmployeeModel> mE = Enumerable.ToList(_myEmployee);
                    List<ProductModel> mP = Enumerable.ToList(_myProduct);
                    List<ProductTypeModel> mPT = Enumerable.ToList(_myProductType);

                    decimal ddd = 0;
                    modelcha.Clear();
                    foreach (SaleModel a in _mySale)
                    {
                        if (a.SaleTime >= date1.SelectedDate && a.SaleTime <= second)
                        {

                            BranchModel bb = mB.Where(x => x.Id == a.BranchId).FirstOrDefault();
                            EmployeeModel ee = mE.Where(x => x.Id == a.EmployeeId).FirstOrDefault();
                            ProductModel pp = mP.Where(x => x.Id == a.ProductId).FirstOrDefault();
                            ProductTypeModel pptt = mPT.Where(x => x.Id == a.ProductTypeId).FirstOrDefault();
                            SaleModelcha m = new SaleModelcha()
                            {
                                myBranch = bb.BranchNumber,
                                myEmployee = ee.FullName,
                                myProduct = pp.ProductName,
                                myProductType = pptt.Name,

                                mySoni = a.Soni,
                                mySummasi = a.Summasi,
                                myVaqti = a.SaleTime
                            };
                            ddd += m.mySummasi;
                            modelcha.Add(m);
                        }

                    }
                    labSumma.Text = ddd.ToString();
                    DG.ItemsSource = null;
                    DG.ItemsSource = modelcha;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Ошибка на даты!");
            }
        }
    }
}
