﻿using Day1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Day1.View.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestApiPage : ContentPage
    {
        public RestApiPage()
        {
            InitializeComponent();
            BindingContext = new RestApiViewModel();

        }
    }
}
