using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Clima.Helpers
{
	public class LenghtToBollConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is int)
				return (int)value == 0;

			return false;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return 1;
		}
	}
}
