using Clima.Models;
using Clima.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Clima.ViewModels
{
	public class PesquisaPageViewModel : ViewModelBase
	{
		private readonly ICidadeService cidadeService;
		private readonly INavigationService navigationService;


		private ObservableCollection<Cidade> cidades;

		public ObservableCollection<Cidade> Cidades
		{
			get => cidades;
			set => SetProperty(ref cidades, value);
		}

		public PesquisaPageViewModel(INavigationService navigationService, ICidadeService cidadeService)
			: base(navigationService)
		{
			Title = "Pesquisar Cidade";
			this.cidadeService = cidadeService;
			this.navigationService = navigationService;
		}

		public async Task CarregarCidades()
		{
			Busy = true;
			Cidades = new ObservableCollection<Cidade>(await cidadeService.ObterCidadesAsync());
			Busy = false;
		}

		public async Task RetornarFavoritos()
		{
			await navigationService.GoBackAsync();
		}

		public async Task AbrirDetalhe(object item)
		{
			var cidade = item as Cidade;

			if (cidade == null)
				return;

			var parametros = new NavigationParameters();
			parametros.Add("idCidade", cidade.Codigo);
			await navigationService.NavigateAsync("DetalhePage", parametros);
		}
	}
}
