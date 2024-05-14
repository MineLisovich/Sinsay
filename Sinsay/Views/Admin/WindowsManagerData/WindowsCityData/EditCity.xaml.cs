﻿using Sinsay.Models;
using Sinsay.ViewsModels.AdminVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sinsay.Views.Admin.WindowsManagerData.WindowsCityData
{
    /// <summary>
    /// Interaction logic for EditCity.xaml
    /// </summary>
    public partial class EditCity : Window
    {
        public EditCity(City city)
        {
            InitializeComponent();
            DataContext = new AdminDataManagerVM();
            AdminDataManagerVM.SelectedCity = city;
            AdminDataManagerVM.NameCity = city.Name;
        }
    }
}