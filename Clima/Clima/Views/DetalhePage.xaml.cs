using Clima.ViewModels;
using Xamarin.Forms;

namespace Clima.Views
{
    public partial class DetalhePage : ContentPage
    {
		private DetalhePageViewModel ViewModel => BindingContext as DetalhePageViewModel;

		public DetalhePage()
        {
            InitializeComponent();
        }

		private async void btnVoltar_Clicked(object sender, System.EventArgs e)
		{
			await ViewModel.VoltarTelaAnterior();
		}

		private async void btnAdicionar_Clicked(object sender, System.EventArgs e)
		{
			await ViewModel.AdicionarFavoritos();
		}

		private async void btnRemover_Clicked(object sender, System.EventArgs e)
		{
			await ViewModel.RemoverFavorito();
		}
	}
}
