using Clima.ViewModels;
using System.Windows;
using Xamarin.Forms;

namespace Clima.Views
{
    /// <summary>
    /// Interaction logic for Pesquisa.xaml
    /// </summary>
    public partial class PesquisaPage : ContentPage
	{
		private PesquisaPageViewModel ViewModel => BindingContext as PesquisaPageViewModel;

		public PesquisaPage()
        {
            InitializeComponent();
        }

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			await ViewModel.CarregarCidades();
		}

		private async void Favoritos_Clicked(object sender, System.EventArgs e)
		{
			await ViewModel.RetornarFavoritos();
		}

		private async void CidadeList_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			if (e.Item == null)
				return;

			await ViewModel.AbrirDetalhe(e.Item);
		}
	}
}
