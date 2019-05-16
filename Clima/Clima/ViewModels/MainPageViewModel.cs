using Clima.Models;
using Clima.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clima.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
		private readonly ICidadeService cidadeService;
		private readonly INavigationService navigationService;
		private ObservableCollection<CidadeFavoritaModel> cidades;

		public ObservableCollection<CidadeFavoritaModel> Cidades
		{
			get => cidades;
			set => SetProperty(ref cidades, value);
		}

        public MainPageViewModel(INavigationService navigationService, ICidadeService cidadeService) 
            : base (navigationService)
        {
            Title = "Cidades Favoritas";
			this.cidadeService = cidadeService;
			this.navigationService = navigationService;
			Cidades = new ObservableCollection<CidadeFavoritaModel>();
		}

		public async Task CarregarCidades()
		{
			Busy = true;
			Cidades = new ObservableCollection<CidadeFavoritaModel>(await cidadeService.ObterCidadesFavoritasAsync());
			Busy = false;
		}

		public async Task CarregarTelaPesquisa()
		{
			await navigationService.NavigateAsync("PesquisaPage");
		}

		public async Task AbrirDetalhe(object item)
		{
			var cidade = item as CidadeFavoritaModel;

			if (cidade == null)
				return;

			var parametros = new NavigationParameters();
			parametros.Add("idCidade", cidade.codigo);
			await navigationService.NavigateAsync("DetalhePage", parametros);
		}
	}
}
