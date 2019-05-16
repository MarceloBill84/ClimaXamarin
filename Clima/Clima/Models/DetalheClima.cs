using System;
using System.Collections.Generic;
using System.Text;

namespace Clima.Models
{
    public class DetalheClima
    {
		public int codigo { get; set; }
		public string nome { get; set; }
		public float temperaturaMinima { get; set; }
		public float temperaturaMaxima { get; set; }
		public float temperaturaAtual { get; set; }
		public string clima { get; set; }
	}
}
