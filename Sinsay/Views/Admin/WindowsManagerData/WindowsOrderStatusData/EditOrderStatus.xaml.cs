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

namespace Sinsay.Views.Admin.WindowsManagerData.WindowsOrderStatusData
{
    /// <summary>
    /// Interaction logic for EditOrderStatus.xaml
    /// </summary>
    public partial class EditOrderStatus : Window
    {
        public EditOrderStatus(OrderStatus status)
        {
            InitializeComponent();
            DataContext = new AdminDataManagerVM();
            AdminDataManagerVM.SelectedOrderStatus = status;
            AdminDataManagerVM.NameOrderStatus = status.Name;
        }
    }
}
