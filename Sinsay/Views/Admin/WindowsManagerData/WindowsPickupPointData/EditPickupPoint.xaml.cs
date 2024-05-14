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

namespace Sinsay.Views.Admin.WindowsManagerData.WindowsPickupPointData
{
    /// <summary>
    /// Interaction logic for EditPickupPoint.xaml
    /// </summary>
    public partial class EditPickupPoint : Window
    {
        public EditPickupPoint(PickupPoint point)
        {
            InitializeComponent();
            DataContext = new AdminDataManagerVM();
            AdminDataManagerVM.SelectedPickupPoint = point;
            AdminDataManagerVM.NamePickupPoint = point.Name;
            AdminDataManagerVM.AddressPickupPoint = point.Address;
            AdminDataManagerVM.SelectListCityPickupPoint = point.City;
        }
    }
}