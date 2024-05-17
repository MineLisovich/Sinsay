using Sinsay.Models;
using Sinsay.Sevices;
using Sinsay.Sevices.CityService;
using Sinsay.Sevices.ClothesService;
using Sinsay.Sevices.OrderServices;
using Sinsay.Sevices.PaymentMethodService;
using Sinsay.Sevices.PickiupPointService;
using Sinsay.Sevices.UserServices;
using Sinsay.Views.Admin;
using Sinsay.Views.Admin.WindowsManagerData.WindowsChangesOrderStatus;
using Sinsay.Views.Admin.WindowsManagerData.WindowsCityData;
using Sinsay.Views.Admin.WindowsManagerData.WindowsClothesData;
using Sinsay.Views.Admin.WindowsManagerData.WindowsOrderStatusData;
using Sinsay.Views.Admin.WindowsManagerData.WindowsPaymentMethodData;
using Sinsay.Views.Admin.WindowsManagerData.WindowsPickupPointData;
using Sinsay.Views.Admin.WindowsManagerData.WindowsUserData;
using Sinsay.Views.ResultWindow;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using static System.Net.Mime.MediaTypeNames;

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
        public string SearchCity { get; set; }

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
        public static string SearchPickup { get; set; }

        //AppUser
        public static AppUser SelectedAppUser { get; set; }
        public static string UserEmail { get; set; }
        public static string UserName { get; set; }
        public static string UserPhoneNumber { get; set; }
        public static Role SelectListRolesUser { get; set; }
        public static string SearchUser {  get; set; }

        //Clothes
        public static Clothes SelectedClothes { get; set; }
        public static string ClothesName { get; set; }
        public static string ClothesDescription { get; set; }
        public static int ClothesCount { get; set; }
        public static decimal ClothesPrice { get; set; }
        public static string SearchClothes { get; set; }

        //orders
        public static Order SelectedOrder { get; set; }
        public static OrderStatus SelectListOrderStatus { get; set; }
        public static string SearchOrder {  get; set; }

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
            set { allPickupPoint = value; NotifyPropertyChanged(nameof(AllPickupPoint)); }
        }

        //AppUser
        private List<AppUser> allAppUsers = UserService.GetAllUsers();
        public List<AppUser> AllAppUsers
        {
            get { return allAppUsers; }
            set { allAppUsers = value; NotifyPropertyChanged(nameof(AllAppUsers)); }
        }
        //Roles
        private List<Role> allRoles = UserService.GetAllRoles();
        public List<Role> AllRoles
        {
            get { return allRoles; }
            set { allRoles = value; NotifyPropertyChanged(nameof(AllRoles)); }
        }

        //Clothes
        private List<Clothes> allClothes = ClothesService.GetAllClothes();
        public List<Clothes> AllClothes
        {
            get { return allClothes; }
            set { allClothes = value; NotifyPropertyChanged(nameof(AllClothes)); }
        }

        private List<Order> allOrders = OrderService.GetAllOrders();
        public List<Order> AllOrders
        {
            get {  return allOrders; }
            set { allOrders = value; NotifyPropertyChanged(nameof(AllOrders));}
        }
        #endregion

        #region  City (open Create/Edit window, add, edit delete)
        //open add wnd
        private RelayCommand openAddCityWnd;
        public RelayCommand OpenAddCityWnd
        {
            get
            {
                return openAddCityWnd ?? new RelayCommand(obj =>
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
                    if (SelectedCity is not null && NameCity is not null)
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

        //searh
        private RelayCommand searchCity;
        public RelayCommand SearchCityCom
        {
            get
            {
                return searchCity ?? new RelayCommand(obj =>
                {
                    AllCities = CityService.SearchCityList(SearchCity);
                    AdminHomePage.AllCitiesLV.ItemsSource = null;
                    AdminHomePage.AllCitiesLV.Items.Clear();
                    AdminHomePage.AllCitiesLV.ItemsSource = AllCities;
                    AdminHomePage.AllCitiesLV.Items.Refresh();
                });
            }
        }

        private RelayCommand clearSearchCityCom;
        public RelayCommand ClearSearchCityCom
        {
            get
            {
                return clearSearchCityCom ?? new RelayCommand(obj =>
                {
                    AllCities = CityService.GetAllCities();
                    AdminHomePage.AllCitiesLV.ItemsSource = null;
                    AdminHomePage.AllCitiesLV.Items.Clear();
                    AdminHomePage.AllCitiesLV.ItemsSource = AllCities;
                    AdminHomePage.AllCitiesLV.Items.Refresh();
                    SearchCity = null;
                });
            }
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
                    if (SelectedOrderStatus is not null && NameOrderStatus is not null || NameOrderStatus.Replace(" ", "").Length != 0)
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
                return editPaymentMethod ?? new RelayCommand(obj =>
                {
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
        private void OpenEditPaymentMethod(PaymentMethod paymentMethod)
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
                    else if (SelectListCityPickupPoint is null)
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
                    if (SelectedPickupPoint is not null)
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
                            result = PickiupPointService.EditPickupPoint(pickupPoint: SelectedPickupPoint, name: NamePickupPoint, address: AddressPickupPoint, _city: SelectListCityPickupPoint);
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

        //searh
        private RelayCommand searchPickupCom;
        public RelayCommand SearchPickupCom
        {
            get
            {
                return searchPickupCom ?? new RelayCommand(obj =>
                {
                    AllPickupPoint = PickiupPointService.SearchPickupPointList(SearchPickup);
                    AdminHomePage.AllPickupPointLV.ItemsSource = null;
                    AdminHomePage.AllPickupPointLV.Items.Clear();
                    AdminHomePage.AllPickupPointLV.ItemsSource = AllPickupPoint;
                    AdminHomePage.AllPickupPointLV.Items.Refresh();
                });
            }
        }

        private RelayCommand clearSearchPickupCom;
        public RelayCommand ClearSearchPickupCom
        {
            get
            {
                return clearSearchPickupCom ?? new RelayCommand(obj =>
                {
                    AllPickupPoint = PickiupPointService.GetAllPickupPoint();
                    AdminHomePage.AllPickupPointLV.ItemsSource = null;
                    AdminHomePage.AllPickupPointLV.Items.Clear();
                    AdminHomePage.AllPickupPointLV.ItemsSource = AllPickupPoint;
                    AdminHomePage.AllPickupPointLV.Items.Refresh();
                    SearchPickup = null;
                });
            }
        }
        #endregion

        #region AppUsers
        //open add wnd
        private RelayCommand openAddAppUser;
        public RelayCommand OpenAddAppUser
        {
            get
            {
                return openAddAppUser ?? new RelayCommand(obj =>
                {
                    OpenAddAppUserMethod();
                });
            }
        }
        private void OpenAddAppUserMethod()
        {
            AddUser wnd = new();
            wnd.ShowDialog();
        }
        //add
        private RelayCommand addNewAppUser;
        public RelayCommand AddNewAppUser
        {
            get
            {
                return addNewAppUser ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    bool result = false;

                    if (UserEmail is null || UserEmail.Replace(" ", "").Length == 0)
                    {
                        ValidationsError(wnd, "tb_email");
                    }
                    else if (UserName is null || UserName.Replace(" ", "").Length == 0)
                    {
                        ValidationsError(wnd, "tb_name");
                    }
                    else if (UserPhoneNumber is null || UserPhoneNumber.Replace(" ", "").Length == 0)
                    {
                        ValidationsError(wnd, "tb_phone");
                    }
                    else if (SelectListRolesUser is null)
                    {
                        MessageBox.Show("Укажите роль");
                    }
                    else
                    {
                        result = UserService.AddUser(email: UserEmail, username: UserName, phone: UserPhoneNumber, _role: SelectListRolesUser);
                        ShowMessageToUser(result);
                        GlobalUpdateView();
                        UserEmail = null;
                        UserName = null;
                        UserPhoneNumber = null;
                        SelectListRolesUser = null;
                        wnd.Close();
                    }

                });
            }
        }
        //Edit
        private RelayCommand editAppUser;
        public RelayCommand EditAppUser
        {
            get
            {
                return editAppUser ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    bool result = false;
                    if (SelectedAppUser is not null)
                    {
                        if (UserEmail is null || UserEmail.Replace(" ", "").Length == 0)
                        {
                            ValidationsError(wnd, "tb_email");
                        }
                        else if (UserName is null || UserName.Replace(" ", "").Length == 0)
                        {
                            ValidationsError(wnd, "tb_name");
                        }
                        else if (UserPhoneNumber is null || UserPhoneNumber.Replace(" ", "").Length == 0)
                        {
                            ValidationsError(wnd, "tb_phone");
                        }
                        else if (SelectListRolesUser is null)
                        {
                            MessageBox.Show("Укажите роль");
                        }
                        else
                        {
                            result = UserService.EditUser(user: SelectedAppUser, email: UserEmail, username: UserName, phone: UserPhoneNumber, _role: SelectListRolesUser, emailCurrUser: App.currentUser.Email);
                            ShowMessageToUser(result);
                            GlobalUpdateView();
                            UserEmail = null;
                            UserName = null;
                            UserPhoneNumber = null;
                            SelectListRolesUser = null;
                            wnd.Close();
                        }
                    }
                });
            }
        }
        private void OpenEditAppUserMethod(AppUser user)
        {
            EditUser wnd = new(user);
            wnd.ShowDialog();
        }

        //BlockUser
        private RelayCommand blockUser;
        public RelayCommand BlockUser
        {
            get
            {
                return blockUser ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    bool result = false;
                    
                    if (SelectedTab.Name == "UsersTab" && SelectedAppUser is not null)
                    {
                        result = UserService.BlockUnBlockUser(id:SelectedAppUser.Id,emailCurrUser:App.currentUser.Email, isblock:true);
                        //ShowMessageToUser(result);
                        GlobalUpdateView();
                    }
                });
            }
        }
        //UnBlockUser
        private RelayCommand unBlockUser;
        public RelayCommand UnBlockUser
        {
            get
            {
                return unBlockUser ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    bool result = false;

                    if (SelectedTab.Name == "UsersTab" && SelectedAppUser is not null)
                    {
                        result = UserService.BlockUnBlockUser(id: SelectedAppUser.Id, emailCurrUser: App.currentUser.Email, isblock: false);
                        //ShowMessageToUser(result);
                        GlobalUpdateView();
                    }
                });
            }
        }


        //searh
        private RelayCommand searchUserCom;
        public RelayCommand SearchUserCom
        {
            get
            {
                return searchUserCom ?? new RelayCommand(obj =>
                {
                    AllAppUsers = UserService.SearchUserList(SearchUser);
                    AdminHomePage.AllAppUsers.ItemsSource = null;
                    AdminHomePage.AllAppUsers.Items.Clear();
                    AdminHomePage.AllAppUsers.ItemsSource = AllAppUsers;
                    AdminHomePage.AllAppUsers.Items.Refresh();
                });
            }
        }

        private RelayCommand clearSearchUserCom;
        public RelayCommand ClearSearchUserCom
        {
            get
            {
                return clearSearchUserCom ?? new RelayCommand(obj =>
                {
                    AllAppUsers = UserService.GetAllUsers();
                    AdminHomePage.AllAppUsers.ItemsSource = null;
                    AdminHomePage.AllAppUsers.Items.Clear();
                    AdminHomePage.AllAppUsers.ItemsSource = AllAppUsers;
                    AdminHomePage.AllAppUsers.Items.Refresh();
                    SearchUser = null;
                });
            }
        }
        #endregion

        #region Clothes
        //open add wnd
        private RelayCommand openAddClothes;
        public RelayCommand OpenAddClothes
        {
            get
            {
                return openAddClothes ?? new RelayCommand(obj =>
                {
                    OpenAddClothesMethod();
                });
            }
        }
        private void OpenAddClothesMethod()
        {
            AddClothes wnd = new();
            wnd.ShowDialog();
        }

        //add
        private RelayCommand addClothes;
        public RelayCommand AddClothes
        {
            get
            {
                return addClothes ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    bool result = false;

                    if (ClothesName is null || ClothesName.Replace(" ", "").Length == 0)
                    {
                        ValidationsError(wnd, "tb_name");
                    }
                    else if (ClothesDescription is null || ClothesDescription.Replace(" ", "").Length == 0)
                    {
                        ValidationsError(wnd, "tb_description");
                    }
                    else if (ClothesCount <= 0)
                    {
                        ValidationsError(wnd, "tb_count");
                    }
                    else if (ClothesPrice <= 0)
                    {
                        ValidationsError(wnd, "tb_price");
                    }
                    else
                    {
                        result = ClothesService.AddClothes(name: ClothesName, descr: ClothesDescription, count: ClothesCount, price: ClothesPrice);
                        ShowMessageToUser(result);
                        GlobalUpdateView();
                        ClothesName = null;
                        ClothesDescription = null;
                        ClothesCount = 0;
                        ClothesPrice = 0m;
                        wnd.Close();
                    }
                });
            }
        }

        //edit
        private RelayCommand editClothes;
        public RelayCommand EditClothes
        {
            get 
            {
                return editClothes ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    bool result = false;
                    if(SelectedClothes is not null)
                    {
                        if (ClothesName is null || ClothesName.Replace(" ", "").Length == 0)
                        {
                            ValidationsError(wnd, "tb_name");
                        }
                        else if (ClothesDescription is null || ClothesDescription.Replace(" ", "").Length == 0)
                        {
                            ValidationsError(wnd, "tb_description");
                        }
                        else if (ClothesCount <= 0)
                        {
                            ValidationsError(wnd, "tb_count");
                        }
                        else if (ClothesPrice <= 0)
                        {
                            ValidationsError(wnd, "tb_price");
                        }
                        else
                        {
                            result = ClothesService.EditClothes(clothes: SelectedClothes, name: ClothesName, descr: ClothesDescription, count: ClothesCount, price: ClothesPrice);
                            ShowMessageToUser(result);
                            GlobalUpdateView();
                            ClothesName = null;
                            ClothesDescription = null;
                            ClothesCount = 0;
                            ClothesPrice = 0m;
                            wnd.Close();
                        }
                    }
                    
                });
            }
        }

        private void OpenEditClothesMethod(Clothes clothes)
        {
            EditClothes wnd = new EditClothes(clothes);
            wnd.ShowDialog();
        }

        //searh
        private RelayCommand searchClothesCom;
        public RelayCommand SearchClothesCom
        {
            get
            {
                return searchClothesCom ?? new RelayCommand(obj =>
                {
                    AllClothes = ClothesService.SearchClothesList(SearchClothes);
                    AdminHomePage.AllClothes.ItemsSource = null;
                    AdminHomePage.AllClothes.Items.Clear();
                    AdminHomePage.AllClothes.ItemsSource = AllClothes;
                    AdminHomePage.AllClothes.Items.Refresh();
                });
            }
        }

        private RelayCommand clearSearchClothesCom;
        public RelayCommand ClearSearchClothesCom
        {
            get
            {
                return clearSearchClothesCom ?? new RelayCommand(obj =>
                {
                    AllClothes = ClothesService.GetAllClothes();
                    AdminHomePage.AllClothes.ItemsSource = null;
                    AdminHomePage.AllClothes.Items.Clear();
                    AdminHomePage.AllClothes.ItemsSource = AllClothes;
                    AdminHomePage.AllClothes.Items.Refresh();
                    SearchClothes = null;
                });
            }
        }
        #endregion

        #region Orders
        //Open Change Order Stat Wnd
        private void OpenChangeOrderStatWndMet()
        {
            ChangeStatusOrder wnd = new();
            wnd.ShowDialog();
        }
        private RelayCommand openChangeOrderStatWnd;
        public RelayCommand OpenChangeOrderStatWnd
        {
            get
            {
                return openChangeOrderStatWnd ?? new RelayCommand(obj =>
                {
                    OpenChangeOrderStatWndMet();
                });
            }
        }

        //ChangeOrderStatusCOM
        private RelayCommand changeOrderStatusCOM;
        public RelayCommand ChangeOrderStatusCOM
        {
            get
            {
                return changeOrderStatusCOM ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    bool result = false;
                    if (SelectedOrder is not null)
                    {
                        if(SelectListOrderStatus is null)
                        {
                            MessageBox.Show("Выберите статус");
                        }
                        else
                        {
                            result = OrderService.ChangeOrderSatusForAdminArea(orderId: SelectedOrder.Id,_status:SelectListOrderStatus);
                            ShowMessageToUser(result);
                            GlobalUpdateView();
                            wnd.Close();
                        }
                    }
                });
            }
        }

        //search
        //searh
        private RelayCommand searchOrderCom;
        public RelayCommand SearchOrderCom
        {
            get
            {
                return searchOrderCom ?? new RelayCommand(obj =>
                {
                    AllOrders = OrderService.SearchOrderListForAdmin(SearchOrder);
                    AdminHomePage.AllOrdersLV.ItemsSource = null;
                    AdminHomePage.AllOrdersLV.Items.Clear();
                    AdminHomePage.AllOrdersLV.ItemsSource = AllOrders;
                    AdminHomePage.AllOrdersLV.Items.Refresh();
                });
            }
        }

        private RelayCommand clearSearchOrderCom;
        public RelayCommand ClearSearchOrderCom
        {
            get
            {
                return clearSearchOrderCom ?? new RelayCommand(obj =>
                {
                    AllOrders = OrderService.GetAllOrders();
                    AdminHomePage.AllOrdersLV.ItemsSource = null;
                    AdminHomePage.AllOrdersLV.Items.Clear();
                    AdminHomePage.AllOrdersLV.ItemsSource = AllOrders;
                    AdminHomePage.AllOrdersLV.Items.Refresh();
                    SearchOrder = null;
                });
            }
        }

        //Print ALL
        private RelayCommand printAll;
        public RelayCommand PrintAll
        {
            get
            {
                return printAll ?? new RelayCommand(obj =>
                {
                    FlowDocument fd = new FlowDocument();
                    string HEADER = "SINSAY\nСписок заказов\n";
                    fd.Blocks.Add(new Paragraph(new Run(HEADER)));

                    string convertDataToString = "";
                    foreach (var item in AllOrders)
                    {
                        convertDataToString = "Заказ номер: " +item.Id +"\nНаименование - "+ item.Name + "\nСтатус - " + item.OrderStatus.Name + "\nEmail пользователя - " + item.AppUser.Email + "\nИмя пользователя - "+item.AppUser.UserName+ "\nНомер телефона - " + item.AppUser.PhoneNumber + "\nДата заказа - " + item.OrderDate + "\nИтого - " + item.TotalPrice + "\nСпособ оплаты - " + item.PaymentMethod.Name + "\nПВЗ - " + item.PickupPoint.Name + "\nАдрес - " + item.PickupPoint.Address +"\n" +"-----------------------";
                        fd.Blocks.Add(new Paragraph(new Run(convertDataToString.ToString())));
                        convertDataToString = "";

                    }
                    PrintDialog pd = new PrintDialog();
                    if (pd.ShowDialog() != true) return;
                    fd.PageHeight = pd.PrintableAreaHeight;
                    fd.PageWidth = pd.PrintableAreaWidth;
                    IDocumentPaginatorSource idocument = fd as IDocumentPaginatorSource;
                    pd.PrintDocument(idocument.DocumentPaginator, "Печать документа...");
                });
            }
        }

        //Print Singl
        private RelayCommand printSingl;
        public RelayCommand PrintSingl
        {
            get
            {
                return printSingl ?? new RelayCommand(obj =>
                {
                    if (SelectedOrder is not null)
                    {
                        FlowDocument fd = new FlowDocument();
                        string HEADER = "SINSAY\nЭлектронный чек № "+ SelectedOrder.Id +"\n";
                        fd.Blocks.Add(new Paragraph(new Run(HEADER)));
                        string convertDataToString = "Наименование - " + SelectedOrder.Name + "\nСтатус - " + SelectedOrder.OrderStatus.Name + "\nEmail пользователя - " + SelectedOrder.AppUser.Email + "\nИмя пользователя - " + SelectedOrder.AppUser.UserName + "\nНомер телефона - " + SelectedOrder.AppUser.PhoneNumber + "\nДата заказа - " + SelectedOrder.OrderDate + "\nИтого - " + SelectedOrder.TotalPrice + "\nСпособ оплаты - " + SelectedOrder.PaymentMethod.Name + "\nПВЗ - " + SelectedOrder.PickupPoint.Name + "\nАдрес - " + SelectedOrder.PickupPoint.Address;
                        fd.Blocks.Add(new Paragraph(new Run(convertDataToString.ToString())));
                        PrintDialog pd = new PrintDialog();
                        if (pd.ShowDialog() != true) return;
                        fd.PageHeight = pd.PrintableAreaHeight;
                        fd.PageWidth = pd.PrintableAreaWidth;
                        IDocumentPaginatorSource idocument = fd as IDocumentPaginatorSource;
                        pd.PrintDocument(idocument.DocumentPaginator, "Печать документа...");
                    }
                });
            }
        }
        #endregion

        #region Edit && DELETE COMMAND

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
                    //AppUser
                    if (SelectedTab.Name == "UsersTab" && SelectedAppUser is not null)
                    {
                        OpenEditAppUserMethod(SelectedAppUser);
                    }
                    //Clothes
                    if (SelectedTab.Name == "ClothesTab" && SelectedClothes is not null)
                    {
                        OpenEditClothesMethod(SelectedClothes);
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
                    //AppUser
                    if (SelectedTab.Name == "UsersTab" && SelectedAppUser is not null)
                    {
                        result = UserService.DeleteUser(id:SelectedAppUser.Id, emailCurrUser:App.currentUser.Email);
                    }
                    //Clothes
                    if (SelectedTab.Name == "ClothesTab" && SelectedClothes is not null)
                    {
                       result = ClothesService.DeleteClothes(SelectedClothes.Id);
                    }
                    GlobalUpdateView();
                    GlobalNullValueProp();
                    //ShowMessageToUser(result);
                });
            }
        }
        #endregion

        #endregion

        #region WINDOWS SETTINGS
        private void OpenWindowCS(Window window)
        {
            window.Owner = System.Windows.Application.Current.MainWindow;
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


            //AppUser
            UserEmail = null;
            UserName = null;
            UserPhoneNumber = null;
            SelectListRolesUser = null;

            //Clothes
            ClothesName = null;
            ClothesDescription = null;
            ClothesCount = 0;
            ClothesPrice = 0m;
        }
        private void GlobalUpdateView()
        {
            UpdateTableInCityView();
            UpdateTableInOrderStatusView();
            UpdateTableInPaymentView();
            UpdateTableInPickupView();
            UpdateTableInAppUserView();
            UpdateTableInClothesView();
            UpdateTableInOrderView();
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

        private void UpdateTableInAppUserView()
        {
            AllAppUsers = UserService.GetAllUsers();
            AdminHomePage.AllAppUsers.ItemsSource = null;
            AdminHomePage.AllAppUsers.Items.Clear();
            AdminHomePage.AllAppUsers.ItemsSource = AllAppUsers;
            AdminHomePage.AllAppUsers.Items.Refresh();
        }
        private void UpdateTableInClothesView()
        {
            AllClothes = ClothesService.GetAllClothes();
            AdminHomePage.AllClothes.ItemsSource = null;
            AdminHomePage.AllClothes.Items.Clear();
            AdminHomePage.AllClothes.ItemsSource = AllClothes;
            AdminHomePage.AllClothes.Items.Refresh();
        }

        private void UpdateTableInOrderView()
        {
            AllOrders = OrderService.GetAllOrders();
            AdminHomePage.AllOrdersLV.ItemsSource = null;
            AdminHomePage.AllOrdersLV.Items.Clear();
            AdminHomePage.AllOrdersLV.ItemsSource = AllOrders;
            AdminHomePage.AllOrdersLV.Items.Refresh();
        }


        #endregion
        private void ShowMessageToUser(bool result)
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
        private void ValidationsError(Window wnd, string blockName)
        {
            Control block = wnd.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Red;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
