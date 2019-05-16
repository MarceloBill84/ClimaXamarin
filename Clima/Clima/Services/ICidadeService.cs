using Clima.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clima.Services
{
    public interface ICidadeService
    {
		Task<IList<Cidade>> ObterCidadesAsync();
		Task<IList<CidadeFavoritaModel>> ObterCidadesFavoritasAsync();
		Task<DetalheClima> ObterDetalheClima(int idCidade);
		Task AdicionarFavorito(CidadeFavorita cidade);
		Task RemoverFavorito(CidadeFavorita cidade);
		Task<int> ObterCidadeFavorita(int codigo);
	}
}
