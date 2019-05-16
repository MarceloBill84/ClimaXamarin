using Clima.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Clima.Views
{
	public partial class MainPage : ContentPage
	{
		private MainPageViewModel ViewModel => BindingContext as MainPageViewModel;

		public MainPage()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			await ViewModel.CarregarCidades();
		}

		private async void Pesquisa_Clicked(object sender, EventArgs e)
		{
			await ViewModel.CarregarTelaPesquisa();
		}

		private async void CidadeList_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			if (e.Item == null)
				return;

			await ViewModel.AbrirDetalhe(e.Item);
		}
	}
}