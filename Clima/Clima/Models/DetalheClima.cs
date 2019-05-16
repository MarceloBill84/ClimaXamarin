using System;
using System.Collections.Generic;
using System.Text;

namespace Clima.Models
{
    public class DetalheClima
    {
		public int Codigo { get; set; }
		public string Nome { get; set; }
		public float TemperaturaMinima { get; set; }
		public float TemperaturaMaxima { get; set; }
		public float TemperaturaAtual { get; set; }
		public string Clima { get; set; }
	}
}
