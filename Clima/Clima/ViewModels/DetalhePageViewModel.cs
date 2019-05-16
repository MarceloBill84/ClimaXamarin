using Clima.Models;
using Clima.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clima.ViewModels
{
	public class DetalhePageViewModel : ViewModelBase
	{
		private readonly ICidadeService cidadeService;
		private readonly INavigationService navigationService;
		private int id, idFavorita;
		private string nome, clima;
		private float temperatura, maxima, minima;

		public int Id
		{
			get => id;
			set => SetProperty(ref id, value);
		}

		public string Nome
		{
			get => nome;
			set => SetProperty(ref nome, value);
		}

		public float Temperatura
		{
			get => temperatura;
			set => SetProperty(ref temperatura, value);
		}

		public string Clima
		{
			get => clima;
			set => SetProperty(ref clima, value);
		}

		public float Maxima
		{
			get => maxima;
			set => SetProperty(ref maxima, value);
		}

		public float Minima
		{
			get => minima;
			set => SetProperty(ref minima, value);
		}

		public int IdFavorita
		{
			get => idFavorita;
			set => SetProperty(ref idFavorita, value);
		}

		public DetalhePageViewModel(INavigationService navigationService, ICidadeService cidadeService) : base(navigationService)
        {
			Title = "Clima";
			this.cidadeService = cidadeService;
			this.navigationService = navigationService;
		}

		public override void OnNavigatedTo(INavigationParameters parameters)
		{
			base.OnNavigatedTo(parameters);
			
			var cidade = (int)parameters.First().Value;
			Task.Run(async () => IdFavorita = await cidadeService.ObterCidadeFavorita(cidade));
			Task.Run(async () => await CarregarClima(cidade));
		}

		public async Task CarregarClima(int codigo)
		{
			Busy = true;
			var model = await cidadeService.ObterDetalheClima(codigo);

			if (model == null)
				return;

			Id = codigo;
			Nome = model.Nome;
			Clima = model.Clima;
			Temperatura = model.TemperaturaAtual;
			Maxima = model.TemperaturaMaxima;
			Minima = model.TemperaturaMinima;
			Busy = false;
		}

		public async Task VoltarTelaAnterior()
		{
			await navigationService.GoBackAsync();
		}

		public async Task AdicionarFavoritos()
		{
			await cidadeService.AdicionarFavorito(new CidadeFavorita
			{
				Codigo = id
			});

			IdFavorita = id;
		}

		public async Task RemoverFavorito()
		{
			await cidadeService.RemoverFavorito(new CidadeFavorita
			{
				Codigo = id
			});

			IdFavorita = 0;
		}
	}
}
