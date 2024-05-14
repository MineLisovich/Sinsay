using Sinsay.Models;
using Sinsay.Sevices;
using Sinsay.Sevices.CityService;
using Sinsay.Sevices.OrderServices;
using Sinsay.Sevices.PaymentMethodService;
using Sinsay.Sevices.PickiupPointService;
using Sinsay.Views.Admin;
using Sinsay.Views.Admin.WindowsManagerData.WindowsCityData;
using Sinsay.Views.Admin.WindowsManagerData.WindowsOrderStatusData;
using Sinsay.Views.Admin.WindowsManagerData.WindowsPaymentMethodData;
using Sinsay.Views.Admin.WindowsManagerData.WindowsPickupPointData;
using Sinsay.Views.ResultWindow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Sinsay.ViewsModels.AdminVM
{
    public class AdminDataManagerVM : INotifyPropertyChanged
    {
        #region initialization prop
        //Global
        public TabItem SelectedTab { get; set; }

        //City
        public static City SelectedCity { get; set; }
        public static string NameCity { get; set; }

        //OrderStatus
        public static OrderStatus SelectedOrderStatus { get; set; }
        public static string NameOrderStatus { get; set; }

        //PaymentMethod
        public static PaymentMethod SelectedPaymentMethod { get; set; }
        public static string NamePaymentMethod { get; set; }

        //PickupPoint
        public static PickupPoint SelectedPickupPoint { get; set; }
        public static string NamePickupPoint { get; set; }
        public static string AddressPickupPoint { get; set; }
        public static City SelectListCityPickupPoint { get; set; }

        #endregion

        #region initialization data
        //City
        private List<City> allCities = CityService.GetAllCities();
        public List<City> AllCities
        {
            get { return allCities; }
            set { allCities = value; NotifyPropertyChanged(nameof(AllCities)); }
        }

        //OrderStatus
        private List<OrderStatus> allOrderStatuses = OrderStatusService.GetAllOrderStatus();
        public List<OrderStatus> AllOrderStatuses
        {
            get { return allOrderStatuses; }
            set { allOrderStatuses = value; NotifyPropertyChanged(nameof(AllOrderStatuses)); }
        }

        //PaymentMethod
        private List<PaymentMethod> allPaymentMethods = PaymentMethodService.GetAllPaymentMethod();
        public List<PaymentMethod> AllPaymentMethods
        {
            get { return allPaymentMethods; }
            set { allPaymentMethods = value; NotifyPropertyChanged(nameof(AllPaymentMethods)); }
        }

        //PickupPoint
        private List<PickupPoint> allPickupPoint = PickiupPointService.GetAllPickupPoint();
        public List<PickupPoint> AllPickupPoint
        {
            get { return allPickupPoint; }
            set { allPickupPoint = value; NotifyPropertyChanged(nameof(AllPickupPoint));}
        }
        #endregion



        #region  City (open Create/Edit window, add, edit delete)
        //open add wnd
        private RelayCommand openAddCityWnd;
        public RelayCommand OpenAddCityWnd
        {
            get
            {
                return openAddCityWnd ?? new RelayCommand( obj =>
                {
                    OpenAddCityMethod();
                });
            }
        }
        private void OpenAddCityMethod()
        {
            AddCity winAddCity = new();
            winAddCity.ShowDialog();
        }

        //add
        private RelayCommand addNewCity;
        public RelayCommand AddNewCity
        {
            get
            {
                return addNewCity ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    if (NameCity is null || NameCity.Replace(" ", "").Length == 0)
                    {
                        ValidationsError(wnd, "tb_name");
                    }
                    else
                    {
                        bool result = CityService.AddCity(NameCity);
                        ShowMessageToUser(result);
                        GlobalUpdateView();
                        NameCity = null;
                        wnd.Close();
                    }                  
                });
            }
        }
        //edit
        private RelayCommand editCity;
        public RelayCommand EditCity
        {
            get
            {
                return editCity ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    bool result = false;
                    if(SelectedCity is not null && NameCity is not null)
                    {
                        result = CityService.EditCity(SelectedCity, NameCity);
                        ShowMessageToUser(result);
                        GlobalUpdateView();
                        NameCity = null;
                        wnd.Close();
                    }
                    else
                    {
                        ValidationsError(wnd, "tb_name");
                    }
                });
            }
        }
        private void OpenEditCityMethod(City city)
        {
            EditCity winEditCity = new(city);
            winEditCity.ShowDialog();
        }
        #endregion

        #region OrderStatus (open Create/Edit window, add, edit, delete)
        //open add wnd
        private RelayCommand openAddOrderStatusWnd;
        public RelayCommand OpenAddOrderStatusWnd
        {
            get
            {
                return openAddOrderStatusWnd ?? new RelayCommand(obj =>
                {
                    OpenAddOrderStatusMethod();
                });
            }
        }
        private void OpenAddOrderStatusMethod()
        {
            AddOrderStatus wndOrdStat = new();
            wndOrdStat.ShowDialog();
        }

        //add
        private RelayCommand addNewOrderStatus;
        public RelayCommand AddNewOrderStatus
        {
            get
            {
                return addNewOrderStatus ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    if (NameOrderStatus is null || NameOrderStatus.Replace(" ", "").Length == 0)
                    {
                        ValidationsError(wnd, "tb_name");
                    }
                    else
                    {
                        bool result = OrderStatusService.AddOrderStatus(NameOrderStatus);
                        ShowMessageToUser(result);
                        GlobalUpdateView();
                        NameOrderStatus = null;
                        wnd.Close();
                    }
                });
            }
        }

        //Edit
        private RelayCommand editOrderStatus;
        public RelayCommand EditOrderStatus
        {
            get
            {
                return editOrderStatus ?? new RelayCommand(obj => 
                {
                    Window wnd = obj as Window;
                    bool result = false;
                    if(SelectedOrderStatus is not null && NameOrderStatus is not null || NameOrderStatus.Replace(" ", "").Length != 0)
                    {
                        result = OrderStatusService.EditOrderStatus(SelectedOrderStatus, NameOrderStatus);
                        ShowMessageToUser(result);
                        GlobalUpdateView();
                        NameOrderStatus = null;
                        wnd.Close();
                    }
                    else
                    {
                        ValidationsError(wnd, "tb_name");
                    }
                });
            }
        }

        private void OpenEditOrderStatus(OrderStatus orderStatus)
        {
            EditOrderStatus winEdit = new(orderStatus);
            winEdit.ShowDialog();
        }
        #endregion

        #region PaymentMethod (open Create/Edit wnd, add, edit)
        //open add wnd
        private RelayCommand openAddPaymentMethod;
        public RelayCommand OpenAddPaymentMethod
        {
            get
            {
                return openAddPaymentMethod ?? new RelayCommand(obj =>
                {
                    OpenAddPaymentMethodMet();
                });
            }
        }
        private void OpenAddPaymentMethodMet()
        {
            AddPaymentMethod wnd = new();
            wnd.ShowDialog();   
        }

        //add
        private RelayCommand addNewPaymentMethod;
        public RelayCommand AddNewPaymentMethod
        {
            get
            {
                return addNewPaymentMethod ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    if (NamePaymentMethod is null || NamePaymentMethod.Replace(" ", "").Length == 0)
                    {
                        ValidationsError(wnd, "tb_name");
                    }
                    else
                    {
                        bool result = PaymentMethodService.AddPaymentMethod(NamePaymentMethod);
                        ShowMessageToUser(result);
                        GlobalUpdateView();
                        NamePaymentMethod = null;
                        wnd.Close();
                    }
                });
            }
        }

        //edit
        private RelayCommand editPaymentMethod;
        public RelayCommand EditPaymentMethod
        {
            get
            {
                return editPaymentMethod ?? new RelayCommand(obj => {
                    Window wnd = obj as Window;
                    bool result = false;
                    if (SelectedPaymentMethod is not null && NamePaymentMethod is not null || NamePaymentMethod.Replace(" ", "").Length != 0)
                    {
                        result = PaymentMethodService.EditPaymentMethod(SelectedPaymentMethod, NamePaymentMethod);
                        ShowMessageToUser(result);
                        GlobalUpdateView();
                        NamePaymentMethod = null;
                        wnd.Close();
                    }
                    else
                    {
                        ValidationsError(wnd, "tb_name");
                    }
                });
            }
        }
        private void OpenEditPaymentMethod (PaymentMethod paymentMethod)
        {
            EditPaymentMethod wnd = new(paymentMethod);
            wnd.ShowDialog();
        }
        #endregion

        #region PickupPoint
        //open add wnd
        private RelayCommand openAddPickupPoint;
        public RelayCommand OpenAddPickupPoint
        {
            get
            {
                return openAddPickupPoint ?? new RelayCommand(obj =>
                {
                    OpenAddPickupPointMethod();
                });
            }
        }
        private void OpenAddPickupPointMethod()
        {
            AddPickupPoint wnd = new();
            wnd.ShowDialog();
        }

        //add
        private RelayCommand addNewPickupPoint;
        public RelayCommand AddNewPickupPoint
        {
            get
            {
                return addNewPickupPoint ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    bool result = false;
                    if (NamePickupPoint is null || NamePickupPoint.Replace(" ", "").Length == 0)
                    {
                        ValidationsError(wnd, "tb_name");
                    }
                    else if (AddressPickupPoint is null || AddressPickupPoint.Replace(" ", "").Length == 0)
                    {
                        ValidationsError(wnd, "tb_address");
                    }
                    else if(SelectListCityPickupPoint is null)
                    {
                        MessageBox.Show("Укажите город");
                    }
                    else
                    {
                        result = PickiupPointService.AddPickupPoint(name: NamePickupPoint, address: AddressPickupPoint, _city: SelectListCityPickupPoint);
                        ShowMessageToUser(result);
                        GlobalUpdateView();
                        NamePickupPoint = null;
                        AddressPickupPoint = null;
                        SelectListCityPickupPoint = null;
                        wnd.Close();
                    }
                });
            }
        }

        //edit
        private RelayCommand editNewPicupPoint;
        public RelayCommand EditNewPicupPoint
        {
            get
            {
                return editNewPicupPoint ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    bool result = false;
                    if(SelectedPickupPoint is not null)
                    {
                        if (NamePickupPoint is null || NamePickupPoint.Replace(" ", "").Length == 0)
                        {
                            ValidationsError(wnd, "tb_name");
                        }
                        else if (AddressPickupPoint is null || AddressPickupPoint.Replace(" ", "").Length == 0)
                        {
                            ValidationsError(wnd, "tb_address");
                        }
                        else if (SelectListCityPickupPoint is null)
                        {
                            MessageBox.Show("Укажите город");
                        }
                        else
                        {
                            result = PickiupPointService.EditPickupPoint(pickupPoint:SelectedPickupPoint,name: NamePickupPoint, address: AddressPickupPoint, _city: SelectListCityPickupPoint);
                            ShowMessageToUser(result);
                            GlobalUpdateView();
                            NamePickupPoint = null;
                            AddressPickupPoint = null;
                            SelectListCityPickupPoint = null;
                            wnd.Close();
                        }
                    }
                });
            }
        }
        private void OpenEditPickupPointMethod(PickupPoint point)
        {
            EditPickupPoint wnd = new(point);
            wnd.ShowDialog();
        }
        #endregion




        #region Edit || DELETE COMMAND

        #region EDIT OPEN WIND
        private RelayCommand openEditItem;
        public RelayCommand OpenEditItem
        {
            get
            {
                return openEditItem ?? new RelayCommand(obj =>
                {
                    bool result = false;
                    //City
                    if (SelectedTab.Name == "CityTab" && SelectedCity is not null)
                    {
                        OpenEditCityMethod(SelectedCity);
                    }
                    //OrderStatus
                    if (SelectedTab.Name == "OrderStatusTab" && SelectedOrderStatus is not null)
                    {
                        OpenEditOrderStatus(SelectedOrderStatus);
                    }
                    //Payment
                    if (SelectedTab.Name == "PaymentMethodsTab" && SelectedPaymentMethod is not null)
                    {
                        OpenEditPaymentMethod(SelectedPaymentMethod);
                    }
                    //PickupPoint
                    if (SelectedTab.Name == "PickupTab" && SelectedPickupPoint is not null)
                    {
                        OpenEditPickupPointMethod(SelectedPickupPoint);
                    }
                });
            }
        }

       
        #endregion

        #region DELETE
        private RelayCommand deleteItem;
        public RelayCommand DeleteItem
        {
            get
            {
                return deleteItem ?? new RelayCommand(obj =>
                {
                    bool result = false;
                    //City
                    if (SelectedTab.Name == "CityTab" && SelectedCity is not null)
                    {
                         result = CityService.DeleteCity(SelectedCity.Id);
                        
                    }

                    //OrderStatus
                    if (SelectedTab.Name == "OrderStatusTab" && SelectedOrderStatus is not null)
                    {
                      result = OrderStatusService.DeleteOrderStatus(SelectedOrderStatus.Id);
                    }
                    //Payment
                    if (SelectedTab.Name == "PaymentMethodsTab" && SelectedPaymentMethod is not null)
                    {
                       result = PaymentMethodService.DeletePaymentMethod(SelectedPaymentMethod.Id);
                    }
                    //PickupPoint
                    if (SelectedTab.Name == "PickupTab" && SelectedPickupPoint is not null)
                    {
                        result = PickiupPointService.DeletePickupPoint(SelectedPickupPoint.Id);
                    }
                    GlobalUpdateView();
                    GlobalNullValueProp();
                    ShowMessageToUser(result);
                });
            }
        }
        #endregion

        #endregion

        #region WINDOWS SETTINGS
        private void OpenWindowCS(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ShowDialog();
        }
        private void GlobalNullValueProp()
        {
            //Global
           
            
            //City
            NameCity = null;
            SelectedCity = null;

            //OrederStat
            NameOrderStatus = null;
            SelectedOrderStatus = null;

            //Payment
            NamePaymentMethod = null;
            SelectedPaymentMethod = null;

            //PickupPoint
            NamePickupPoint = null;
            AddressPickupPoint = null;
            SelectListCityPickupPoint = null;
        }
        private void GlobalUpdateView()
        {
            UpdateTableInCityView();
            UpdateTableInOrderStatusView();
            UpdateTableInPaymentView();
            UpdateTableInPickupView();
        }

        private void UpdateTableInCityView()
        {
            AllCities = CityService.GetAllCities();
            AdminHomePage.AllCitiesLV.ItemsSource = null;
            AdminHomePage.AllCitiesLV.Items.Clear();
            AdminHomePage.AllCitiesLV.ItemsSource = AllCities;
            AdminHomePage.AllCitiesLV.Items.Refresh();
        }

        private void UpdateTableInOrderStatusView()
        {
            AllOrderStatuses = OrderStatusService.GetAllOrderStatus();
            AdminHomePage.AllOrderStatusLV.ItemsSource = null;
            AdminHomePage.AllOrderStatusLV.Items.Clear();
            AdminHomePage.AllOrderStatusLV.ItemsSource = AllOrderStatuses;
            AdminHomePage.AllOrderStatusLV.Items.Refresh();
        }
        private void UpdateTableInPaymentView()
        {
            AllPaymentMethods = PaymentMethodService.GetAllPaymentMethod();
            AdminHomePage.AllPaymentMethodLV.ItemsSource = null;
            AdminHomePage.AllPaymentMethodLV.Items.Clear();
            AdminHomePage.AllPaymentMethodLV.ItemsSource = AllPaymentMethods;
            AdminHomePage.AllPaymentMethodLV.Items.Refresh();
        }

        private void UpdateTableInPickupView()
        {
            AllPickupPoint = PickiupPointService.GetAllPickupPoint();
            AdminHomePage.AllPickupPointLV.ItemsSource = null;
            AdminHomePage.AllPickupPointLV.Items.Clear();
            AdminHomePage.AllPickupPointLV.ItemsSource = AllPickupPoint;
            AdminHomePage.AllPickupPointLV.Items.Refresh();
        }

        #endregion
        private void ShowMessageToUser (bool result)
        {
            
            if (result is true)
            {
                MessageView msView = new("Успех");
                OpenWindowCS(msView);
            }
            else
            {
                MessageView msView = new("Ошибка");
                OpenWindowCS(msView);
            }
        }
        private void ValidationsError (Window wnd, string blockName)
        {
            Control block = wnd.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Red;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged (String propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged (this, new PropertyChangedEventArgs (propName));
            }
        }
    }
}
