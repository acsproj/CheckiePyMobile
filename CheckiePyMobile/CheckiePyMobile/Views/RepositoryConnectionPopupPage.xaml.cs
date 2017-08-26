﻿using CheckiePyMobile.Models;
using CheckiePyMobile.Services;
using CheckiePyMobile.ViewModels;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;

namespace CheckiePyMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RepositoryConnectionPopupPage : PopupPage
    {
        private RepositoryConnectionPopupViewModel _viewModel;

        private CodeStyleViewModel _codeStyleViewModel;

        public RepositoryModel Repository
        {
            get { return _viewModel.Repository; }
            set { _viewModel.Repository = value; }
        }

        public RepositoryConnectionPopupPage()
        {
            InitializeComponent();
            this.BindingContext = _viewModel = new RepositoryConnectionPopupViewModel(this, NetworkService.Instance);
            this.picker.BindingContext = _codeStyleViewModel = new CodeStyleViewModel(this, NetworkService.Instance);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _codeStyleViewModel.LoadCodeStylesAsync();
        }
    }
}