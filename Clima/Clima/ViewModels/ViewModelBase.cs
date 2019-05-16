using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clima.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        private string _title;
		private bool busy;
		public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

		public bool Busy
		{
			get => busy;
			set => SetProperty(ref busy, value);
		}

		public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {
            
        }

        public virtual void Destroy()
        {
            
        }
    }
}
