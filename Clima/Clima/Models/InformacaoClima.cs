using System;
using System.Collections.Generic;
using System.Text;

namespace Clima.Models
{
	public class InformacaoClima
	{
		public Weather[] weather { get; set; }
		public Main main { get; set; }
		public string name { get; set; }
	}

	public class Main
	{
		public float temp { get; set; }
		public float temp_min { get; set; }
		public float temp_max { get; set; }
	}

	public class Weather
	{
		public int id { get; set; }
		public string main { get; set; }
		public string description { get; set; }
		public string icon { get; set; }
	}
}
