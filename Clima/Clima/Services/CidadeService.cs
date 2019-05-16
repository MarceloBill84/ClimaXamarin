using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Clima.Models;
using Newtonsoft.Json;

namespace Clima.Services
{
	public class CidadeService : ICidadeService
	{
		private readonly string url = "http://api.openweathermap.org/data/2.5/weather?id={0}&appid=2bac87e0cb16557bff7d4ebcbaa89d2f&lang=pt&units=metric";

		public async Task<IList<Cidade>> ObterCidadesAsync()
		{
			var assembly = Assembly.GetExecutingAssembly();
			var stream = assembly.GetManifestResourceStream("Clima.Resource.city.list.json");

			using (StreamReader r = new StreamReader(stream))
			{
				var json = await r.ReadToEndAsync();
				return JsonConvert.DeserializeObject<List<Cidade>>(json);
			}
		}

		public async Task<IList<CidadeFavoritaModel>> ObterCidadesFavoritasAsync()
		{
			var favoritas = await App.SQLiteDb.GetItemsAsync();

			var retorno = new List<CidadeFavoritaModel>();

			foreach (var item in favoritas)
			{
				var clima = await ObterClimaAsync(item.Codigo);

				if (clima != null)
					retorno.Add(new CidadeFavoritaModel
					{
						Codigo = item.Codigo,
						Nome = clima.name,
						Clima = clima.weather[0].description,
						Temperatura = clima.main.temp
					});
			}

			return retorno;
		}

		public async Task<DetalheClima> ObterDetalheClima(int idCidade)
		{
			var informacaoClima = await ObterClimaAsync(idCidade);

			if (informacaoClima == null)
				return null;

			return new DetalheClima
			{
				Codigo = idCidade,
				Nome = informacaoClima.name,
				Clima = informacaoClima.weather[0].description,
				TemperaturaAtual = informacaoClima.main.temp,
				TemperaturaMinima = informacaoClima.main.temp_min,
				TemperaturaMaxima = informacaoClima.main.temp_max
			};
		}

		public async Task AdicionarFavorito(CidadeFavorita cidade)
		{
			await App.SQLiteDb.SaveItemAsync(cidade);
		}

		public async Task RemoverFavorito(CidadeFavorita cidade)
		{
			await App.SQLiteDb.DeleteItemAsync(cidade);
		}

		private async Task<InformacaoClima> ObterClimaAsync(int idCidade)
		{
			var endereco = string.Format(url, idCidade);

			using (var client = new HttpClient())
			{
				var json = await client.GetStringAsync(endereco);

				if (string.IsNullOrWhiteSpace(json))
					return null;

				return JsonConvert.DeserializeObject<InformacaoClima>(json);
			}
		}

		public async Task<int> ObterCidadeFavorita(int codigo)
		{
			var cidade = await App.SQLiteDb.GetItemAsync(codigo);

			if (cidade == null)
				return 0;

			return cidade.Codigo;
		}
	}
}
