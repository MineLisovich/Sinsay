using Sinsay.Models;
using Sinsay.Sevices;
using Sinsay.Sevices.CityService;
using Sinsay.Views.Admin;
using Sinsay.Views.Admin.WindowsManagerData.WindowsCityData;
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

        #region initialization data
        //City
        private List<City> allCities = CityService.GetAllCities();
        public List<City> AllCities
        {
            get { return allCities; }
            set { allCities = value; NotifyPropertyChanged("AllCities"); }
        }
        #endregion

        #region initialization prop
        public TabItem SelectedTab { get; set; }
        public static City SelectedCity { get; set; }
        public static string NameCity { get; set; }
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
                        UpdateTableInCityView();
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
                        UpdateTableInCityView();
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
                         GlobalUpdateView();
                    }
                   
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
        }
        private void GlobalUpdateView()
        {
            UpdateTableInCityView();
        }

        private void UpdateTableInCityView()
        {
            AllCities = CityService.GetAllCities();
            AdminHomePage.AllCitiesLV.ItemsSource = null;
            AdminHomePage.AllCitiesLV.Items.Clear();
            AdminHomePage.AllCitiesLV.ItemsSource = AllCities;
            AdminHomePage.AllCitiesLV.Items.Refresh();
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
