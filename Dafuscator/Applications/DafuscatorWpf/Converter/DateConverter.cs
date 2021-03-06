﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace WaveTech.Dafuscator.WpfApplication.Converter
{
	public class DateConverter:IValueConverter
	{
		#region IValueConverter Members

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is DateTime)
			{
				DateTime date = (DateTime)value;
				return date.ToShortDateString();
			}
			else return "";
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			DateTime date;
			if (DateTime.TryParse(value as string,out date)) return date; else return null;
		}

		#endregion
	}
}