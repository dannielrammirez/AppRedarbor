using AppRedarbor.Models;
using AppRedarbor.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppRedarbor.Views
{
    public partial class UpdateEmployeePage : ContentPage
    {
        public UpdateEmployeePage()
        {
            InitializeComponent();
            BindingContext = new UpdateEmployeeViewModel();
        }
    }
}