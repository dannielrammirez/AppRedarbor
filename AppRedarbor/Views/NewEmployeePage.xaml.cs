using AppRedarbor.Models;
using AppRedarbor.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppRedarbor.Views
{
    public partial class NewEmployeePage : ContentPage
    {
        public Employee Employee { get; set; }

        public NewEmployeePage()
        {
            InitializeComponent();
            BindingContext = new NewEmployeeViewModel();
        }
    }
}